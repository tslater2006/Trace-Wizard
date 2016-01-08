using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class PPCException
    {
        public static uint NextID;

        public uint InternalID = NextID++;

        public long LineNumber;
        public string Message;
    }
}
