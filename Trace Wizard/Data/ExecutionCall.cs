using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class ExecutionCall
    {
        public static uint NextId;

        /* Only used for SQL type calls, this is hooked up in post-process */
        public SQLStatement SQLStatement;

        /* Only used if this call resulted in a StackTrace */
        public StackTraceEntry StackTrace;

        /* Used to hold PPC exceptions */
        public PPCException PPCException;

        public uint InternalID = NextId++;

        public bool HasError;
        public bool IsError;
        public int indentCount;
        public string Context;
        public string Nest;
        public string Function;

        public List<Tuple<string,string>> Parameters = new List<Tuple<string, string>>();

        protected double _duration;

        public double Duration
        {
            get
            {
                if (Type == ExecutionCallType.CALL)
                {
                    double total = 0;
                    foreach (var c in Children)
                    {
                        total += c.Duration;
                    }
                    return total;
                } else
                {
                    return _duration;
                }
                
            }
            set
            {
                _duration = value;
            }
        }

        public long StartLine;
        private long _stopLine;
        public long StopLine { get
            {
                if (Type != ExecutionCallType.CALL)
                {
                    return _stopLine;
                } else
                {
                    if (Children.Count > 0)
                    {
                        return Children.Last().StopLine;
                    }
                }
                return StartLine + 1;
            }
            set
            {
                if (Type != ExecutionCallType.CALL)
                {
                    _stopLine = value;
                }
            }
        }
        public ExecutionCallType Type;

        public ExecutionCall Parent;
        public List<ExecutionCall> Children = new List<ExecutionCall>();

        public List<Tuple<long, string>> GetStackTrace()
        {
            List<Tuple<long, string>> trace = new List<Tuple<long, string>>();
            var parent = Parent;
            while (parent != null)
            {
                trace.Add(Tuple.Create<long, string>(parent.StartLine, parent.Function));
                parent = parent.Parent;
            }

            trace.Reverse();
            return trace;
        }
    }

    public enum ExecutionCallType
    {
        NORMAL,EXTERNAL,CALL, SQL
    }
}
