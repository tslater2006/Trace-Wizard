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

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TraceWizard.Data;

namespace TraceWizard.UI
{
    public class UIBuilder
    {
        public static ListView view;
        public static TabControl BuildStatisticsPage(List<StatisticItem> items, MouseEventHandler doubleClickCallback)
        {
            var statGroups = items.GroupBy(s => s.Category);
            TabControl ctrl = new TabControl();
            List<TabPage> pages = new List<TabPage>();
            ctrl.Dock = DockStyle.Fill;
            foreach (var group in statGroups.OrderBy(g => g.Key))
            {
                var page = new TabPage(group.Key);
                ctrl.TabPages.Add(page);
                pages.Add(page);
                var listView = new ListView();
                UIBuilder.view = listView;
                page.Controls.Add(listView);
                listView.Dock = System.Windows.Forms.DockStyle.Fill;
                listView.Font = new System.Drawing.Font("Verdana", 9F);
                listView.FullRowSelect = true;
                listView.GridLines = true;
                listView.HideSelection = false;
                listView.Location = new System.Drawing.Point(3, 3);
                listView.UseCompatibleStateImageBehavior = false;
                listView.View = System.Windows.Forms.View.Details;
                listView.Columns.Add("Name");
                listView.Columns.Add("Value");
                listView.Columns.Add("Extra");

                listView.MouseDoubleClick += doubleClickCallback;

                foreach (var item in group)
                {
                    var listItem = new ListViewItem(item.Label);
                    listItem.SubItems.Add(item.Value);
                    listItem.SubItems.Add(item.Tag?.ToString());
                    listView.Items.Add(listItem);
                    listItem.Tag = item.Tag;
                }
                foreach (var c in listView.Columns)
                {
                    ((ColumnHeader)c).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }    
            }

            ctrl.SelectedIndex = 0;

            return ctrl;
        }
        
        public static void BuildAllSQLList(ListView view, List<SQLStatement> sqls)
        {
            view.BeginUpdate();
            view.Columns.Clear();
            view.Items.Clear();

            view.Columns.Add("Line #");
            view.Columns.Add("Duration");
            view.Columns.Add("Fetches");
            view.Columns.Add("SQL_ID");
            view.Columns.Add("Full SQL");

            view.ListViewItemSorter = new ListViewItemComparer(0,true);
            /* sort the SQLs */
            //sqls.Sort(new Comparison<SQLStatement>(sort));

            foreach (var sql in sqls)
            {
                ListViewItem item = new ListViewItem();
                if (sql.IsError)
                {
                    item.BackColor = System.Drawing.Color.Red;
                }
                item.Tag = sql;
                item.Text = sql.LineNumber.ToString();
                item.SubItems.Add(sql.Duration.ToString());
                item.SubItems.Add(sql.FetchCount.ToString());
                item.SubItems.Add(sql.SQLID);
                item.SubItems.Add(sql.Statement);

                view.Items.Add(item);
            }

            foreach (ColumnHeader header in view.Columns)
            {
                if (header.Text == "Fetches")
                {
                    header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else
                {
                    header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
                
            }
            view.EndUpdate();
        }

        public static void BuildWhereSQLList(ListView view, List<SQLByWhere> sqls)
        {
            view.BeginUpdate();
            view.Columns.Clear();
            view.Items.Clear();

            var totalHeader = view.Columns.Add("Total Time");
            var callCountHeader = view.Columns.Add("# of Calls");
            var whereHeader = view.Columns.Add("Where");

            foreach (var sql in sqls)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = sql;
                item.Text = sql.TotalTime.ToString();
                item.SubItems.Add(sql.NumberOfCalls.ToString());
                item.SubItems.Add(sql.WhereClause);

                if (sql.HasError)
                {
                    item.BackColor = System.Drawing.Color.Yellow;
                }

                view.Items.Add(item);
            }

            totalHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            callCountHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            whereHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            view.EndUpdate();
        }

        public static void BuildSQLTableList(ListView view, List<SQLStatement> statements)
        {
            view.BeginUpdate();
            view.Columns.Clear();
            view.Items.Clear();

            var typeHeader = view.Columns.Add("SQL Type");
            var tableHeader = view.Columns.Add("Table(s)");
            var countHeader = view.Columns.Add("Count");

            List<SQLStatement> selects = new List<SQLStatement>();
            List<SQLStatement> inserts = new List<SQLStatement>();
            List<SQLStatement> updates = new List<SQLStatement>();
            List<SQLStatement> deletes = new List<SQLStatement>();

            foreach(var statement in statements)
            {
                switch(statement.Type)
                {
                    case SQLType.SELECT:
                        selects.Add(statement);
                        break;
                    case SQLType.INSERT:
                        inserts.Add(statement);
                        break;
                    case SQLType.UPDATE:
                        updates.Add(statement);
                        break;
                    case SQLType.DELETE:
                        deletes.Add(statement);
                        break;
                }
            }

            var selectGroups = selects.GroupBy(s => string.Join(", ", s.Tables.ToArray()));
            foreach (var group in selectGroups)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = group;
                SQLStatement firstSQL = group.First();
                item.Text = firstSQL.Type.ToString();
                item.SubItems.Add(string.Join(", ", firstSQL.Tables.ToArray()));
                item.SubItems.Add(group.Count().ToString());
                view.Items.Add(item);
            }

            var insertGroup = inserts.GroupBy(s => string.Join(", ", s.Tables.ToArray()));
            foreach (var group in insertGroup)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = group;
                SQLStatement firstSQL = group.First();
                item.Text = firstSQL.Type.ToString();
                item.SubItems.Add(string.Join(", ", firstSQL.Tables.ToArray()));
                item.SubItems.Add(group.Count().ToString());
                view.Items.Add(item);
            }

            var updateGroup = updates.GroupBy(s => string.Join(", ", s.Tables.ToArray()));
            foreach (var group in updateGroup)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = group;
                SQLStatement firstSQL = group.First();
                item.Text = firstSQL.Type.ToString();
                item.SubItems.Add(string.Join(", ", firstSQL.Tables.ToArray()));
                item.SubItems.Add(group.Count().ToString());
                view.Items.Add(item);
            }

            var deleteGroup = deletes.GroupBy(s => string.Join(", ", s.Tables.ToArray()));
            foreach (var group in deleteGroup)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = group;
                SQLStatement firstSQL = group.First();
                item.Text = firstSQL.Type.ToString();
                item.SubItems.Add(string.Join(", ", firstSQL.Tables.ToArray()));
                item.SubItems.Add(group.Count().ToString());
                view.Items.Add(item);
            }
            typeHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            tableHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            countHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            view.EndUpdate();
        }

        public static void BuildFromSQLList(ListView view, List<SQLByFrom> sqls)
        {
            view.BeginUpdate();
            view.Columns.Clear();
            view.Items.Clear();

            var totalHeader = view.Columns.Add("Total Time");
            var callCountHeader = view.Columns.Add("# of Calls");
            var whereHeader = view.Columns.Add("From");

            foreach (var sql in sqls)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = sql;
                item.Text = sql.TotalTime.ToString();
                item.SubItems.Add(sql.NumberOfCalls.ToString());
                item.SubItems.Add(sql.FromClause);

                if (sql.HasError)
                {
                    item.BackColor = System.Drawing.Color.Yellow;
                }

                view.Items.Add(item);
            }

            totalHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            callCountHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            whereHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            view.EndUpdate();
        }

        public static void BuildStackTraceList(ListView view, List<StackTraceEntry> traces)
        {
            view.BeginUpdate();
            view.Columns.Clear();
            view.Items.Clear();

            view.Columns.Add("Line #");
            view.Columns.Add("Message");
            view.Columns.Add("Offender");

            traces.OrderBy(p => p.LineNumber);

            foreach (var t in traces)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = t;
                item.Text = t.LineNumber.ToString();
                item.SubItems.Add(t.Message);
                item.SubItems.Add(t.Offender);

                view.Items.Add(item);
            }

            foreach (ColumnHeader header in view.Columns)
            {
                if (header.Text == "Line #")
                {
                    header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else
                {
                    header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }

            }
            view.EndUpdate();

        }

        public static void BuildExecutionTree(TraceData traceData, TreeView executionTree, Dictionary<SQLStatement, TreeNode> SQLMapToTree, Dictionary<ExecutionCall, TreeNode> ExecCallToTree, bool showLoading = true)
        {
            
            if (traceData == null)
            {
                return;
            }
            var execList = traceData.ExecutionPath;
            var sqlList = traceData.SQLStatements;

            executionTree.Nodes.Clear();
            SQLMapToTree.Clear();
            ExecCallToTree.Clear();

            var contextList = execList.OrderBy(p => p.StartLine).Select(p => p.Context).Distinct().ToList();
            var contextNodeList = new List<TreeNode>();
            double totalTraceTime = 0;
            foreach (var ctx in contextList)
            {
                var ctxNode = new TreeNode(ctx);
                contextNodeList.Add(ctxNode);
                var rootExecCalls = execList.Where(p => p.Context.Equals(ctx)).OrderBy(p => p.StartLine);
                double contextTotalTime = 0;
                foreach (var exec in rootExecCalls)
                {
                    contextTotalTime += exec.Duration;
                    if (exec.HasError || exec.IsError)
                    {
                        ctxNode.BackColor = Color.Yellow;
                    }
                    else if (exec.Duration >= Properties.Settings.Default.LongCall)
                    {
                        ctxNode.BackColor = Color.LightGreen;
                    }
                    UIBuilder.BuildExecutionTree(ctxNode, exec,SQLMapToTree, ExecCallToTree, showLoading);
                }
                ctxNode.Text += " Dur: " + contextTotalTime;
                totalTraceTime += contextTotalTime;
            }
            foreach (var node in contextNodeList)
            {
                executionTree.Nodes.Add(node);
            }
        }

        public static void BuildExecutionTree(TreeNode root, ExecutionCall call, Dictionary<SQLStatement, TreeNode> SQLMapToTree, Dictionary<ExecutionCall, TreeNode> ExecCallToTree, bool showLoading)
        {
            TreeNode newRoot = null;
            if (call.Type == ExecutionCallType.SQL)
            {
                var sqlItem = call.SQLStatement;
                switch (sqlItem.Type)
                {
                    case SQLType.SELECT:
                        newRoot = root.Nodes.Add("SELECT FROM " + sqlItem.FromClause + "Fetched=" + sqlItem.FetchCount + " Dur=" + sqlItem.Duration);
                        break;
                    case SQLType.UPDATE:
                        newRoot = root.Nodes.Add("UPDATE " + sqlItem.FromClause + " Dur=" + sqlItem.Duration);
                        break;
                    case SQLType.INSERT:
                        newRoot = root.Nodes.Add("INSERT INTO " + sqlItem.FromClause + " Dur=" + sqlItem.Duration);
                        break;
                    case SQLType.DELETE:
                        newRoot = root.Nodes.Add("DELETE FROM " + sqlItem.FromClause + " Dur=" + sqlItem.Duration);
                        break;
                }

                SQLMapToTree.Add(sqlItem, newRoot);
                newRoot.Tag = sqlItem;
                if (sqlItem.IsError)
                {
                    newRoot.BackColor = Color.Red;
                }
            }
            else
            {
                newRoot = root.Nodes.Add(call.Function + "  Dur: " + (call.Duration));
                ExecCallToTree.Add(call, newRoot);
                if (call.HasError)
                {
                    newRoot.BackColor = Color.Yellow;
                }
                else if (call.IsError)
                {
                    newRoot.BackColor = Color.Red;
                }
                else if (call.Duration >= Properties.Settings.Default.LongCall)
                {
                    newRoot.BackColor = Color.LightGreen;
                }
                newRoot.Tag = call;
                if (showLoading)
                {
                    newRoot.Nodes.Add("Loading...");
                }
            }

        }

    }
}
