#region License
// Copyright (c) 2016 Timothy Slater
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TraceWizard.Data;

namespace TraceWizard.Processors
{
    internal class ExecutionContext
    {
        internal string ContextID;

        internal List<ExecutionCall> allCalls = new List<ExecutionCall>();
        internal List<ExecutionCall> executionCalls = new List<ExecutionCall>();
        internal List<ExecutionCall> sqlCalls = new List<ExecutionCall>();

        Stack<ExecutionCall> callChain = new Stack<ExecutionCall>();

        internal int _maxCallDepth;
        internal long _ppcCodeCallCount;
        internal long _ppcExceptionCount;

        internal ExecutionContext(string contextID)
        {
            ContextID = contextID;
        }

        internal void ProcessCallMarker(Match match, long lineNumber)
        {
            _ppcCodeCallCount++;
            var call = new ExecutionCall() { Context = ContextID, Type = ExecutionCallType.CALL, StartLine = lineNumber, Function = match.Groups[3].Value + ": " + match.Groups[4].Value, indentCount = match.Groups[2].Value.Length };
            allCalls.Add(call);
            call.Duration = Double.Parse(match.Groups[1].Value);
            if (callChain.Count > 0 && callChain.Peek().indentCount == call.indentCount)
            {
                var popped = callChain.Pop();
                if (popped.StopLine == 0)
                {
                    popped.StopLine = lineNumber;
                }
            }

            if (callChain.Count > 0 && callChain.Peek().Type == ExecutionCallType.CALL)
            {
                while (callChain.Count > 0 && callChain.Peek().indentCount >= call.indentCount)
                {
                    var popped = callChain.Pop();
                    if (popped.StopLine == 0)
                    {
                        popped.StopLine = lineNumber;
                    }
                }
            }

            if (callChain.Count > 0)
            {
                callChain.Peek().Children.Add(call);
                call.Parent = callChain.Peek();
            }
            if (callChain.Count == 0)
            {
                executionCalls.Add(call);
            }
            callChain.Push(call);
            return;
        }

        internal void ProcessStartOrResume(Match match, long lineNumber)
        {
            _ppcCodeCallCount++;
            // we have the start of a function
            var call = new ExecutionCall() { Context = ContextID, Type = ExecutionCallType.NORMAL, StartLine = lineNumber, Nest = match.Groups[1].Value, Function = match.Groups[2].Value };
            allCalls.Add(call);
            if (callChain.Count == 0)
            {
                executionCalls.Add(call);
            }
            callChain.Push(call);

            if (callChain.Count > _maxCallDepth)
            {
                _maxCallDepth = callChain.Count;
            }
        }

        internal void ProcessEndOrReend(Match match, long lineNumber)
        {
            // we've reached the end of a call, we need to find it in the list and mark the ending line
            var nest = match.Groups[1].Value;
            var func = match.Groups[2].Value;
            var dur = match.Groups.Count == 4 ? match.Groups[3].Value : "0";

            bool callFound = false;
            ExecutionCall call = null;
            while (callFound == false)
            {
                call = callChain.Pop();
                if (call.Nest == nest && call.Function == func)
                {
                    callFound = true;
                    call.StopLine = lineNumber;
                    call.Duration = Double.Parse(dur);
                }

            }

            if (callChain.Count > 0)
            {
                /* If there are calls on the call chain                           *
                 * then we should associate the current call with its parent      *
                 */
                var parent = callChain.Peek();
                parent.Children.Add(call);
                call.Parent = parent;
            }
        }

        internal void ProcessStartExtMarker(Match match, long lineNumber)
        {
            _ppcCodeCallCount++;
            // we have the start of a function
            var call = new ExecutionCall() { Context = ContextID, Type = ExecutionCallType.EXTERNAL, StartLine = lineNumber, Nest = match.Groups[1].Value, Function = match.Groups[2].Value };
            allCalls.Add(call);
            if (callChain.Count == 0)
            {
                executionCalls.Add(call);
            }

            /* test */
            if (callChain.Count > 0 && callChain.Peek().Type == ExecutionCallType.CALL)
            {
                var parent = callChain.Pop();
                if (parent.StopLine == 0)
                {
                    parent.StopLine = lineNumber;
                }
                parent.Children.Add(call);
                call.Parent = parent;
            }

            callChain.Push(call);
            if (callChain.Count > _maxCallDepth)
            {
                _maxCallDepth = callChain.Count;
            }
        }

        internal void ProcessEndExtMarker(Match match, long lineNumber)
        {
            // we've reached the end of a call, we need to find it in the list and mark the ending line
            var nest = match.Groups[1].Value;
            var func = match.Groups[2].Value;
            var dur = match.Groups[3].Value;

            if (callChain.Count > 0 && callChain.Peek().Type == ExecutionCallType.CALL)
            {
                while (callChain.Peek().Type == ExecutionCallType.CALL || callChain.Peek().Nest != nest)
                {
                    var popped = callChain.Pop();
                    if (popped.StopLine == 0)
                    {
                        popped.StopLine = lineNumber;
                    }
                }
            }

            //var call = executionCalls.Where(p => p.Context.Equals(currentContextString) && p.Nest.Equals(nest) && p.Function.Equals(func) && p.StopLine == 0).First<ExecutionCall>();
            var call = callChain.Pop();
            call.StopLine = lineNumber;
            call.Duration = Double.Parse(dur);
        }

        internal void ProcessSQLStatement(Match match, long lineNumber)
        {
            var sqlCall = new ExecutionCall() { Context = ContextID, Type = ExecutionCallType.SQL, StartLine = lineNumber, StopLine = lineNumber, Function = "SQL" };
            allCalls.Add(sqlCall);
            if (callChain.Count > 0)
            {
                sqlCall.Parent = callChain.Peek();
                callChain.Peek().Children.Add(sqlCall);
            }
            else
            {
                executionCalls.Add(sqlCall);
            }
            sqlCalls.Add(sqlCall);
        }

        internal void ProcessPPCException(Match match, long lineNumber)
        {
            _ppcExceptionCount++;
            var exception = new PPCException() { Message = match.Groups[1].Value };
            if (callChain.Count > 0)
            {
                var call = callChain.Peek();
                call.PPCException = exception;
                call.IsError = true;
                var parent = call.Parent;
                while (parent != null)
                {
                    parent.HasError = true;
                    parent = parent.Parent;
                }
            }
        }
    }


    public class ExecutionPathProcessor : ITraceProcessor
    {
        Regex contextMarker = new Regex("PSAPPSRV\\.\\d+ \\(\\d+\\)");
        Regex startMarker = new Regex(">>> start\\s+Nest=(\\d+)\\s+(.*)");
        Regex startExtMarker = new Regex(">>> start-ext\\sNest=(\\d+)\\s(.*)");
        Regex endMarker = new Regex("<<< end\\s+Nest=(\\d+)\\s+(.*?)\\s+Dur=(\\d+\\.\\d+)");
        Regex endExtMarker = new Regex("<<< end-ext\\s+Nest=(\\d+)\\s+(.*?)\\s+Dur=(\\d+\\.\\d+)");
        Regex callMarker = new Regex("(\\d+\\.\\d+)(\\s+)call\\s+(.*?)\\s+(.*)");
        Regex sqlStatement = new Regex("RC=(\\d+) Dur=(\\d+\\.\\d+) COM Stmt=(.*)");
        Regex ppcExceptionStatement = new Regex("ErrorReturn->(.*)");
        Regex parameterStatement = new Regex("\\s+[^=]+\\=\\[^=]*");

        Regex resumeMarker = new Regex(">>> resume\\s+Nest=(\\d+)\\s+(.*)");
        Regex reendMarker = new Regex(">>> reend\\s+Nest=(\\d+)\\s+(.*)");

        Dictionary<string, ExecutionContext> contextMap = new Dictionary<string, ExecutionContext>();

        public void ProcessorInit(TraceData data)
        {
        }

        public void ProcessorComplete(TraceData td)
        {

            foreach (ExecutionContext ctx in contextMap.Values)
            {
                foreach (ExecutionCall call in ctx.sqlCalls)
                {
                    var lineNumber = call.StartLine;

                    var sqlStatement = td.SQLStatements.Where(s => s.LineNumber == lineNumber).First();

                    call.SQLStatement = sqlStatement;
                    sqlStatement.ParentCall = call.Parent;
                    call.Duration = sqlStatement.Duration;
                    if (sqlStatement.IsError)
                    {
                        call.HasError = true;
                        var parent = call.Parent;
                        while (parent != null)
                        {
                            parent.HasError = true;
                            parent = parent.Parent;
                        }
                    }
                }
            }



            /* process stack traces from TraceDatta */
            foreach (StackTraceEntry traceEntry in td.StackTraces)
            {
                var x = FindCallForLineNumber(traceEntry.LineNumber);
                if (x == null)
                {
                    // sometimes they get printed right after the exit, try 1 line number above
                    x = FindCallForLineNumber(traceEntry.LineNumber-1);
                }
                if (x != null)
                {
                    x.IsError = true;
                    x.StackTrace = traceEntry;
                    traceEntry.Parent = x;
                    var parent = x.Parent;
                    while (parent != null)
                    {
                        parent.HasError = true;
                        parent = parent.Parent;
                    }
                }
            }

            td.MaxCallDepth = contextMap.Values.Max(m=>m._maxCallDepth);

            td.Statistics.Add(new StatisticItem() { Category = "Execution Path", Label = "Maximum Call Depth", Value = td.MaxCallDepth.ToString() });
            td.Statistics.Add(new StatisticItem() { Category = "Execution Path", Label = "Total Calls", Value = contextMap.Values.Sum(c=>c._ppcCodeCallCount).ToString() });
            td.Statistics.Add(new StatisticItem() { Category = "Execution Path", Label = "PeopleCode Exceptions", Value = contextMap.Values.Sum(c => c._ppcExceptionCount).ToString() });


            /* copy all calls to the TraceData structure */
            /*executionCalls = data.ExecutionPath;
            allCalls = data.AllExecutionCalls;*/
            foreach(ExecutionContext ctx in contextMap.Values)
            {
                td.ExecutionPath.AddRange(ctx.executionCalls);
                td.AllExecutionCalls.AddRange(ctx.allCalls);
            }

        }

        ExecutionCall FindCallForLineNumber(long lineNumber)
        {
            ExecutionCall call = null;
            foreach (ExecutionContext ctx in contextMap.Values)
            {
                call = ctx.allCalls.Where(c => c.StartLine <= lineNumber && c.StopLine >= lineNumber).LastOrDefault();
                if (call != null)
                {
                    break;
                }
            }

            return call;
        }

        public void ProcessLine(string line, long lineNumber)
        {

            if (contextMarker.IsMatch(line) == false)
            {
                return;
            }
            var currentContextString = contextMarker.Match(line).Groups[0].Value;

            if (contextMap.ContainsKey(currentContextString) == false)
            {
                contextMap.Add(currentContextString, new ExecutionContext(currentContextString));
            }

            var context = contextMap[currentContextString];

            var match = callMarker.Match(line);
            if (match.Success)
            {
                context.ProcessCallMarker(match, lineNumber);
                return;
            }

            match = startMarker.Match(line);
            if (match.Success == false)
            {
                match = resumeMarker.Match(line);
            }
            /* Start marker, or Resume Marker */
            if (match.Success)
            {
                context.ProcessStartOrResume(match, lineNumber);
                return;
            }

            match = endMarker.Match(line);
            if (match.Success == false)
            {
                match = reendMarker.Match(line);
            }
            /* end marker or reend marker */
            if (match.Success)
            {
                context.ProcessEndOrReend(match, lineNumber);
                return;
            }

            match = startExtMarker.Match(line);
            if (match.Success)
            {
                context.ProcessStartExtMarker(match, lineNumber);
                return;
            }

            match = endExtMarker.Match(line);
            if (match.Success)
            {
                context.ProcessEndExtMarker(match, lineNumber);
                return;
            }

            match = sqlStatement.Match(line);
            if (match.Success)
            {
                context.ProcessSQLStatement(match, lineNumber);
                return;
            }
            match = ppcExceptionStatement.Match(line);
            if (match.Success)
            {
                context.ProcessPPCException(match, lineNumber);
                return;

            }
            return;
        }
    }
    
}
