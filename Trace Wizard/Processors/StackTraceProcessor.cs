using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TraceWizard.Data;

namespace TraceWizard.Processors
{
    public class StackTraceProcessor : ITraceProcessor
    {
        private bool _processingException = false;
        private StackTraceEntry currentStackTrace;
        private int _stackTraceBuffer = 5;
        public List<StackTraceEntry> StackTraces;

        public void ProcessorInit(TraceData data)
        {
            StackTraces = data.StackTraces;
        }

        public void ProcessorComplete(TraceData td)
        {
            td.Statistics.Add(new StatisticItem() { Category = "Execution Path", Label = "Stack Trace Count", Value = StackTraces.Count.ToString() });
        }

        public void ProcessLine(string line, long lineNumber)
        {
            
            if (_processingException)
            {
                Regex stackTraceContinue = new Regex("Called from:(.*)");

                var match = stackTraceContinue.Match(line);

                if (match.Success)
                {
                    currentStackTrace.StackTrace.Add(match.Groups[1].Value);
                    return;
                } else
                {
                    if (_stackTraceBuffer > 0)
                    {
                        _stackTraceBuffer--;
                        ProcessNewException(line,lineNumber);
                        return;
                    } else
                    {
                        _processingException = false;
                    }
                    
                }

            } else
            {
                ProcessNewException(line, lineNumber);
                return;
            }

        }
        private void ProcessNewException(string line, long lineNumber)
        {
            Regex exceptionStart = new Regex("Caught Exception:\\s+(.*?)\\s+\\(0,0\\)\\s+(.*)");

            var match = exceptionStart.Match(line);
            if (match.Success)
            {
                _processingException = true;
                currentStackTrace = new StackTraceEntry();

                currentStackTrace.LineNumber = lineNumber;
                currentStackTrace.Message = match.Groups[1].Value;
                currentStackTrace.Offender = match.Groups[2].Value;

                StackTraces.Add(currentStackTrace);
            }

        }
    }
}
