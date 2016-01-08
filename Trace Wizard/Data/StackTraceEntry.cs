using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class StackTraceEntry
    {
        public static uint NextID;

        public uint InternalID = NextID++;

        public long LineNumber;
        public string Message;
        public string Offender;
        public List<string> StackTrace = new List<string>();

        /* populated by the Execution Path Process in Post */
        public ExecutionCall Parent;
    }
}
