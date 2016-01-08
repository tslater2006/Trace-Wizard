using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class SQLByWhere
    {
        public static uint NextID;

        public uint InternalID = NextID++;
        public double TotalTime;
        public long NumberOfCalls;
        public string WhereClause;
        public bool HasError;
    }
}
