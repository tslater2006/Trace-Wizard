using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TraceWizard.Data
{
    [Serializable]
    public class TraceData
    {
        public List<SQLStatement> SQLStatements = new List<SQLStatement>();
        public List<SQLByWhere> SQLByWhere = new List<SQLByWhere>();
        public List<SQLByFrom> SQLByFrom = new List<SQLByFrom>();

        public List<ExecutionCall> ExecutionPath = new List<ExecutionCall>();
        public List<ExecutionCall> AllExecutionCalls = new List<ExecutionCall>();
        public List<StackTraceEntry> StackTraces = new List<StackTraceEntry>();

        public List<StatisticItem> Statistics = new List<StatisticItem>();

        public long MaxCallDepth;
    }

    
}
