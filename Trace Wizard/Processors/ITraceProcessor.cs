using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraceWizard.Data;

namespace TraceWizard.Processors
{
    public interface ITraceProcessor
    {
        void ProcessorInit(TraceData data);
        void ProcessLine(string line, long lineNumber);
        void ProcessorComplete(TraceData data);
    }
}
