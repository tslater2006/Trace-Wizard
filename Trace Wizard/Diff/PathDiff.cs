using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TraceWizard.Data;

namespace TraceWizard
{
    public class PathDiff
    {
        static SHA1Managed sha1 = new SHA1Managed();
        public static Dictionary<ExecutionCall,ExecutionCall> GeneratePathDiff(List<ExecutionCall> left, List<ExecutionCall> right)
        {
            Dictionary<ExecutionCall, ExecutionCall> sameMap = new Dictionary<ExecutionCall, ExecutionCall>();

            var flatLeft = FlattenPath(left);
            var flatRight = FlattenPath(right);

            StringBuilder sbLeft = new StringBuilder();
            foreach (var call in flatLeft)
            {
                SerializeCall(sbLeft, call);
            }

            StringBuilder sbRight = new StringBuilder();
            foreach (var call in flatRight)
            {
                SerializeCall(sbRight, call);
            }

            sbLeft.Length -= Environment.NewLine.Length;
            sbRight.Length -= Environment.NewLine.Length;

            var l = sbLeft.ToString();
            var r = sbRight.ToString();
            var diff = new Diff.Diff();
            var items = diff.DiffText(l, r);
            int pos = 0;

            List<int> diffItems = new List<int>();

            for (var n = 0; n < items.Length; n++)
            {
                Diff.Diff.Item i = items[n];
                while ((pos < i.StartB) && (pos < flatRight.Count))
                {
                    diffItems.Add(0);
                    pos++;
                }
                if (i.deletedA > 0)
                {
                    for (var m = 0; m < i.deletedA; m++)
                    {
                        diffItems.Add(-1);
                    }
                }
                if (pos < i.StartB + i.insertedB)
                {
                    while (pos < i.StartB + i.insertedB)
                    {
                        diffItems.Add(1);
                        pos++;
                    }
                }
            }

            while (pos < flatRight.Count)
            {
                diffItems.Add(0);
            }

            var leftPointer = 0;
            var rightPointer = 0;
            var lineIndex = 0;

            for (lineIndex = 0; lineIndex < diffItems.Count; lineIndex++)
            {
                var curDiff = diffItems[lineIndex];
                switch (curDiff)
                {
                    case 0:
                        sameMap.Add(flatLeft[leftPointer++], flatRight[rightPointer++]);
                        break;
                    case 1:
                        var call = flatRight[rightPointer++];
                        call.DiffStatus = DiffStatus.INSERT;
                        var parent = call.Parent;
                        while (parent != null)
                        {
                            if (parent.DiffStatus == DiffStatus.SAME)
                            {
                                parent.DiffStatus = DiffStatus.MODIFIED;
                            }
                            
                            parent = parent.Parent;
                        }
                        break;
                    case -1:
                        call = flatLeft[leftPointer++];
                        call.DiffStatus = DiffStatus.DELETE;
                        parent = call.Parent;
                        while (parent != null)
                        {
                            if (parent.DiffStatus == DiffStatus.SAME)
                            {
                                parent.DiffStatus = DiffStatus.MODIFIED;
                            }

                            parent = parent.Parent;
                        }
                        break;
                }
            }
            return sameMap;
        }
        

        public static List<ExecutionCall> FlattenPath (List<ExecutionCall> path)
        {
            List<ExecutionCall> flat = new List<ExecutionCall>();
            foreach(var call in path)
            {
                FlattenCall(call, flat);
            }

            return flat;
        }

        public static void FlattenCall(ExecutionCall call, List<ExecutionCall> flat)
        {
            flat.Add(call);
            foreach(var child in call.Children)
            {
                FlattenCall(child, flat);
            }
        }

        private static void SerializeCall(StringBuilder sb,  ExecutionCall call)
        {
            
            if (call.Type == ExecutionCallType.SQL)
            {
                var sqlSB = new StringBuilder();
                sqlSB.Append(call.SQLStatement.FetchCount).Append(call.SQLStatement.Statement);

                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(sqlSB.ToString()));
                sb.AppendLine(BitConverter.ToString(hash));
                //sb.AppendLine("SQL: " + call.SQLStatement.Statement);
            }

            else
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(call.Function));
                sb.AppendLine(BitConverter.ToString(hash));
                //sb.AppendLine("PPC: " + call.Function);
            }
        }
    }
}
