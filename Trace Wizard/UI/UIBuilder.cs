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

    }
}
