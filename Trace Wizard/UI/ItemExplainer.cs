using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraceWizard.Data;

namespace TraceWizard.UI
{
    public class ItemExplainer
    {
        public static void UpdateExplanation(ListBox box, object item)
        {
            List<string> lines = new List<string>();
            box.BeginUpdate();
            box.Items.Clear();
            if (item.GetType().Equals(typeof(SQLStatement)))
            {
                // explain SQL statement
                var sql = (SQLStatement)item;
                lines.Add("Line #" + sql.LineNumber);
                lines.Add("Statement: " + sql.Statement);
                lines.Add(String.Format("Duration: {0}, Execute: {1}, Fetch: {2}.", sql.Duration, sql.ExecTime, sql.FetchTime));
                lines.Add("Fetched " + sql.FetchCount + " rows.");
                lines.Add("Bind count: " + sql.BindValues.Count);
                for (var x = 0; x < sql.BindValues.Count; x++)
                {
                    var index = sql.BindValues[x].Index;
                    var value = sql.BindValues[x].Value;
                    var typ = sql.BindValues[x].Type;
                    var length = sql.BindValues[x].Length;

                    lines.Add(String.Format("Bind #{0} - {1} ({2}) - {3}", index, typ, length, value));
                }
                lines.Add("Caller: " + (sql.ParentCall == null ? "None" : ("Line #" + sql.ParentCall.StartLine) + " " + sql.ParentCall.Function));

                /* handle error */
                if (sql.IsError)
                {
                    lines.Add("SQL Error:");
                    lines.Add("    Error Position: " + sql.ErrorInfo.ErrorPosition);
                    lines.Add("    Return Code: " + sql.ErrorInfo.ReturnCode);
                    lines.Add("    Message: " + sql.ErrorInfo.Message);
                }
            }
            else if (item.GetType().Equals(typeof(SQLByWhere)))
            {
                var sql = (SQLByWhere)item;
                lines.Add("Where: " + sql.WhereClause);
                // explain SQL Where
            }
            else if (item.GetType().Equals(typeof(SQLByFrom)))
            {
                var sql = (SQLByFrom)item;
                lines.Add("From: " + sql.FromClause);
                // explain SQL From
            }
            else if (item.GetType().Equals(typeof(ExecutionCall)))
            {
                // explain Execution Call
                var exec = (ExecutionCall)item;
                lines.Add(exec.Function);

                if (exec.HasError)
                {
                    // alert that somewhere below has an error
                    lines.Add("A call underneath this one experienced an error.");
                }

                if (exec.IsError)
                {
                    // this threw an error, explain the error.
                    if (exec.StackTrace != null)
                    {
                        lines.Add("Exception occured:");
                        lines.Add("    Line #" + exec.StackTrace.LineNumber);
                        lines.Add("    Message: " + exec.StackTrace.Message);
                        lines.Add("    Offender: " + exec.StackTrace.Offender);
                        for (var x = 1; x < exec.StackTrace.StackTrace.Count; x++)
                        {
                            lines.Add(new string(' ', (x + 4) * 2) + exec.StackTrace.StackTrace[x]);
                        }
                    }
                }

            } else if (item.GetType().Equals(typeof(StackTraceEntry))) {
                var st = (StackTraceEntry)item;
                lines.Add("Line #" + st.LineNumber);
                lines.Add("Message: " + st.Message);
                lines.Add("Offender: " + st.Offender);
                for (var x = 1; x < st.StackTrace.Count; x++)
                {
                    lines.Add(new string(' ', x * 2) + st.StackTrace[x]);
                }

            } else
            {
                lines.Add(item.ToString());
            }

            foreach (string s in lines)
            {
                box.Items.Add(s);
            }
            box.EndUpdate();
        }
    }
}
