namespace TraceWizard
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.memoryUsage = new System.Windows.Forms.ToolStripStatusLabel();
            this.memoryUsageTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mainTabStrip = new System.Windows.Forms.TabControl();
            this.StatsTab = new System.Windows.Forms.TabPage();
            this.executionPathTab = new System.Windows.Forms.TabPage();
            this.execFindBox = new System.Windows.Forms.TextBox();
            this.executionTree = new System.Windows.Forms.TreeView();
            this.sqlStatementsTab = new System.Windows.Forms.TabPage();
            this.sqlFindBox = new System.Windows.Forms.TextBox();
            this.sqlListView = new System.Windows.Forms.ListView();
            this.sqlItemContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyResolvedStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyStackTraceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stackTraceTab = new System.Windows.Forms.TabPage();
            this.stackTraceFindBox = new System.Windows.Forms.TextBox();
            this.stackTraceListView = new System.Windows.Forms.ListView();
            this.detailsBox = new System.Windows.Forms.ListBox();
            this.sqlToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripAllSQL = new System.Windows.Forms.ToolStripButton();
            this.toolStripWhereSQL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSQLByFrom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSQLErrors = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.executionContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStackTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mainTabStrip.SuspendLayout();
            this.executionPathTab.SuspendLayout();
            this.sqlStatementsTab.SuspendLayout();
            this.sqlItemContextStrip.SuspendLayout();
            this.stackTraceTab.SuspendLayout();
            this.sqlToolStrip.SuspendLayout();
            this.executionContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.memoryUsage});
            this.statusStrip.Location = new System.Drawing.Point(0, 601);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1030, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.AutoSize = false;
            this.progressBar.Minimum = 100;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Step = 1;
            this.progressBar.Value = 100;
            // 
            // memoryUsage
            // 
            this.memoryUsage.Name = "memoryUsage";
            this.memoryUsage.Size = new System.Drawing.Size(99, 17);
            this.memoryUsage.Text = "Max: 100 Cur: 100";
            // 
            // memoryUsageTimer
            // 
            this.memoryUsageTimer.Enabled = true;
            this.memoryUsageTimer.Interval = 1000;
            this.memoryUsageTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1030, 538);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1030, 577);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.sqlToolStrip);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mainTabStrip);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detailsBox);
            this.splitContainer1.Size = new System.Drawing.Size(1030, 538);
            this.splitContainer1.SplitterDistance = 430;
            this.splitContainer1.TabIndex = 3;
            // 
            // mainTabStrip
            // 
            this.mainTabStrip.Controls.Add(this.StatsTab);
            this.mainTabStrip.Controls.Add(this.executionPathTab);
            this.mainTabStrip.Controls.Add(this.sqlStatementsTab);
            this.mainTabStrip.Controls.Add(this.stackTraceTab);
            this.mainTabStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabStrip.Location = new System.Drawing.Point(0, 0);
            this.mainTabStrip.Name = "mainTabStrip";
            this.mainTabStrip.SelectedIndex = 0;
            this.mainTabStrip.Size = new System.Drawing.Size(1030, 430);
            this.mainTabStrip.TabIndex = 3;
            this.mainTabStrip.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabStrip_Selected);
            this.mainTabStrip.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainTabStrip_KeyDown);
            this.mainTabStrip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            // 
            // StatsTab
            // 
            this.StatsTab.Location = new System.Drawing.Point(4, 22);
            this.StatsTab.Name = "StatsTab";
            this.StatsTab.Padding = new System.Windows.Forms.Padding(3);
            this.StatsTab.Size = new System.Drawing.Size(1022, 404);
            this.StatsTab.TabIndex = 0;
            this.StatsTab.Text = "Statistics";
            this.StatsTab.UseVisualStyleBackColor = true;
            // 
            // executionPathTab
            // 
            this.executionPathTab.Controls.Add(this.execFindBox);
            this.executionPathTab.Controls.Add(this.executionTree);
            this.executionPathTab.Location = new System.Drawing.Point(4, 22);
            this.executionPathTab.Name = "executionPathTab";
            this.executionPathTab.Padding = new System.Windows.Forms.Padding(3);
            this.executionPathTab.Size = new System.Drawing.Size(1022, 404);
            this.executionPathTab.TabIndex = 1;
            this.executionPathTab.Text = "Execution Path";
            this.executionPathTab.UseVisualStyleBackColor = true;
            // 
            // execFindBox
            // 
            this.execFindBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.execFindBox.Location = new System.Drawing.Point(3, 381);
            this.execFindBox.Name = "execFindBox";
            this.execFindBox.Size = new System.Drawing.Size(1016, 20);
            this.execFindBox.TabIndex = 2;
            this.execFindBox.Visible = false;
            this.execFindBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.executionSearchKeyDown);
            // 
            // executionTree
            // 
            this.executionTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executionTree.HideSelection = false;
            this.executionTree.Location = new System.Drawing.Point(3, 3);
            this.executionTree.Name = "executionTree";
            this.executionTree.Size = new System.Drawing.Size(1016, 398);
            this.executionTree.TabIndex = 1;
            this.executionTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.executionTree_NodeMouseClick);
            this.executionTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.executionSearchKeyDown);
            // 
            // sqlStatementsTab
            // 
            this.sqlStatementsTab.Controls.Add(this.sqlFindBox);
            this.sqlStatementsTab.Controls.Add(this.sqlListView);
            this.sqlStatementsTab.Location = new System.Drawing.Point(4, 22);
            this.sqlStatementsTab.Name = "sqlStatementsTab";
            this.sqlStatementsTab.Padding = new System.Windows.Forms.Padding(3);
            this.sqlStatementsTab.Size = new System.Drawing.Size(1022, 404);
            this.sqlStatementsTab.TabIndex = 2;
            this.sqlStatementsTab.Text = "SQL Statements";
            this.sqlStatementsTab.UseVisualStyleBackColor = true;
            // 
            // sqlFindBox
            // 
            this.sqlFindBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sqlFindBox.Location = new System.Drawing.Point(3, 381);
            this.sqlFindBox.Name = "sqlFindBox";
            this.sqlFindBox.Size = new System.Drawing.Size(1016, 20);
            this.sqlFindBox.TabIndex = 3;
            this.sqlFindBox.Visible = false;
            this.sqlFindBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sqlFindBox_KeyDown);
            // 
            // sqlListView
            // 
            this.sqlListView.ContextMenuStrip = this.sqlItemContextStrip;
            this.sqlListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlListView.Font = new System.Drawing.Font("Verdana", 9F);
            this.sqlListView.FullRowSelect = true;
            this.sqlListView.GridLines = true;
            this.sqlListView.HideSelection = false;
            this.sqlListView.Location = new System.Drawing.Point(3, 3);
            this.sqlListView.MultiSelect = false;
            this.sqlListView.Name = "sqlListView";
            this.sqlListView.Size = new System.Drawing.Size(1016, 398);
            this.sqlListView.TabIndex = 0;
            this.sqlListView.UseCompatibleStateImageBehavior = false;
            this.sqlListView.View = System.Windows.Forms.View.Details;
            this.sqlListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.sqlListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.sqlListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sqlFindBox_KeyDown);
            this.sqlListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // sqlItemContextStrip
            // 
            this.sqlItemContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyResolvedStatementToolStripMenuItem,
            this.copyStatementToolStripMenuItem,
            this.copyBindsToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyStackTraceToolStripMenuItem1});
            this.sqlItemContextStrip.Name = "sqlItemContextStrip";
            this.sqlItemContextStrip.Size = new System.Drawing.Size(210, 98);
            this.sqlItemContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.sqlItemContextStrip_Opening);
            // 
            // copyResolvedStatementToolStripMenuItem
            // 
            this.copyResolvedStatementToolStripMenuItem.Name = "copyResolvedStatementToolStripMenuItem";
            this.copyResolvedStatementToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.copyResolvedStatementToolStripMenuItem.Text = "Copy Resolved Statement";
            this.copyResolvedStatementToolStripMenuItem.Click += new System.EventHandler(this.copyResolvedStatementToolStripMenuItem_Click);
            // 
            // copyStatementToolStripMenuItem
            // 
            this.copyStatementToolStripMenuItem.Name = "copyStatementToolStripMenuItem";
            this.copyStatementToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.copyStatementToolStripMenuItem.Text = "Copy Statement";
            this.copyStatementToolStripMenuItem.Click += new System.EventHandler(this.copyStatementToolStripMenuItem_Click);
            // 
            // copyBindsToolStripMenuItem
            // 
            this.copyBindsToolStripMenuItem.Name = "copyBindsToolStripMenuItem";
            this.copyBindsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.copyBindsToolStripMenuItem.Text = "Copy Binds";
            this.copyBindsToolStripMenuItem.Click += new System.EventHandler(this.copyBindsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(206, 6);
            // 
            // copyStackTraceToolStripMenuItem1
            // 
            this.copyStackTraceToolStripMenuItem1.Name = "copyStackTraceToolStripMenuItem1";
            this.copyStackTraceToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.copyStackTraceToolStripMenuItem1.Text = "Copy Stack Trace";
            this.copyStackTraceToolStripMenuItem1.Click += new System.EventHandler(this.copyStackTraceToolStripMenuItem1_Click);
            // 
            // stackTraceTab
            // 
            this.stackTraceTab.Controls.Add(this.stackTraceFindBox);
            this.stackTraceTab.Controls.Add(this.stackTraceListView);
            this.stackTraceTab.Location = new System.Drawing.Point(4, 22);
            this.stackTraceTab.Name = "stackTraceTab";
            this.stackTraceTab.Padding = new System.Windows.Forms.Padding(3);
            this.stackTraceTab.Size = new System.Drawing.Size(1022, 404);
            this.stackTraceTab.TabIndex = 3;
            this.stackTraceTab.Text = "Stack Traces";
            this.stackTraceTab.UseVisualStyleBackColor = true;
            // 
            // stackTraceFindBox
            // 
            this.stackTraceFindBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stackTraceFindBox.Location = new System.Drawing.Point(3, 381);
            this.stackTraceFindBox.Name = "stackTraceFindBox";
            this.stackTraceFindBox.Size = new System.Drawing.Size(1016, 20);
            this.stackTraceFindBox.TabIndex = 4;
            this.stackTraceFindBox.Visible = false;
            // 
            // stackTraceListView
            // 
            this.stackTraceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackTraceListView.Font = new System.Drawing.Font("Verdana", 9F);
            this.stackTraceListView.FullRowSelect = true;
            this.stackTraceListView.GridLines = true;
            this.stackTraceListView.HideSelection = false;
            this.stackTraceListView.Location = new System.Drawing.Point(3, 3);
            this.stackTraceListView.MultiSelect = false;
            this.stackTraceListView.Name = "stackTraceListView";
            this.stackTraceListView.Size = new System.Drawing.Size(1016, 398);
            this.stackTraceListView.TabIndex = 1;
            this.stackTraceListView.UseCompatibleStateImageBehavior = false;
            this.stackTraceListView.View = System.Windows.Forms.View.Details;
            this.stackTraceListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.stackTraceListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.stackTraceListView_KeyDown);
            this.stackTraceListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.stackTraceListView_MouseDoubleClick);
            // 
            // detailsBox
            // 
            this.detailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsBox.FormattingEnabled = true;
            this.detailsBox.HorizontalScrollbar = true;
            this.detailsBox.Location = new System.Drawing.Point(0, 0);
            this.detailsBox.Name = "detailsBox";
            this.detailsBox.Size = new System.Drawing.Size(1030, 104);
            this.detailsBox.TabIndex = 0;
            // 
            // sqlToolStrip
            // 
            this.sqlToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.sqlToolStrip.Enabled = false;
            this.sqlToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.sqlToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAllSQL,
            this.toolStripWhereSQL,
            this.toolStripSQLByFrom,
            this.toolStripSQLErrors});
            this.sqlToolStrip.Location = new System.Drawing.Point(3, 0);
            this.sqlToolStrip.Name = "sqlToolStrip";
            this.sqlToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.sqlToolStrip.Size = new System.Drawing.Size(148, 39);
            this.sqlToolStrip.TabIndex = 0;
            // 
            // toolStripAllSQL
            // 
            this.toolStripAllSQL.CheckOnClick = true;
            this.toolStripAllSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripAllSQL.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAllSQL.Image")));
            this.toolStripAllSQL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripAllSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAllSQL.Name = "toolStripAllSQL";
            this.toolStripAllSQL.Size = new System.Drawing.Size(36, 36);
            this.toolStripAllSQL.Text = "Show All SQL";
            this.toolStripAllSQL.Click += new System.EventHandler(this.toolStripAllSQL_Click);
            // 
            // toolStripWhereSQL
            // 
            this.toolStripWhereSQL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripWhereSQL.Image = ((System.Drawing.Image)(resources.GetObject("toolStripWhereSQL.Image")));
            this.toolStripWhereSQL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripWhereSQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripWhereSQL.Name = "toolStripWhereSQL";
            this.toolStripWhereSQL.Size = new System.Drawing.Size(37, 36);
            this.toolStripWhereSQL.Text = "Show SQL By Where Clause";
            this.toolStripWhereSQL.Click += new System.EventHandler(this.toolStripWhereSQL_Click);
            // 
            // toolStripSQLByFrom
            // 
            this.toolStripSQLByFrom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSQLByFrom.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSQLByFrom.Image")));
            this.toolStripSQLByFrom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSQLByFrom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSQLByFrom.Name = "toolStripSQLByFrom";
            this.toolStripSQLByFrom.Size = new System.Drawing.Size(36, 36);
            this.toolStripSQLByFrom.Text = "Show SQL By From Clause";
            this.toolStripSQLByFrom.Click += new System.EventHandler(this.toolStripSQLByFrom_Click);
            // 
            // toolStripSQLErrors
            // 
            this.toolStripSQLErrors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSQLErrors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSQLErrors.Image")));
            this.toolStripSQLErrors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSQLErrors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSQLErrors.Name = "toolStripSQLErrors";
            this.toolStripSQLErrors.Size = new System.Drawing.Size(36, 36);
            this.toolStripSQLErrors.Text = "Only Show SQL Errors";
            this.toolStripSQLErrors.Click += new System.EventHandler(this.toolStripSQLErrors_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Trace Wizard Files|*.twiz";
            // 
            // executionContextStrip
            // 
            this.executionContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyStackTraceToolStripMenuItem});
            this.executionContextStrip.Name = "executionContextStrip";
            this.executionContextStrip.Size = new System.Drawing.Size(165, 26);
            this.executionContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.executionContextStrip_Opening);
            // 
            // copyStackTraceToolStripMenuItem
            // 
            this.copyStackTraceToolStripMenuItem.Name = "copyStackTraceToolStripMenuItem";
            this.copyStackTraceToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyStackTraceToolStripMenuItem.Text = "Copy Stack Trace";
            this.copyStackTraceToolStripMenuItem.Click += new System.EventHandler(this.copyStackTraceToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 623);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Trace Wizard";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.mainTabStrip.ResumeLayout(false);
            this.executionPathTab.ResumeLayout(false);
            this.executionPathTab.PerformLayout();
            this.sqlStatementsTab.ResumeLayout(false);
            this.sqlStatementsTab.PerformLayout();
            this.sqlItemContextStrip.ResumeLayout(false);
            this.stackTraceTab.ResumeLayout(false);
            this.stackTraceTab.PerformLayout();
            this.sqlToolStrip.ResumeLayout(false);
            this.sqlToolStrip.PerformLayout();
            this.executionContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel memoryUsage;
        private System.Windows.Forms.Timer memoryUsageTimer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl mainTabStrip;
        private System.Windows.Forms.TabPage StatsTab;
        private System.Windows.Forms.TabPage executionPathTab;
        private System.Windows.Forms.TreeView executionTree;
        private System.Windows.Forms.TabPage sqlStatementsTab;
        private System.Windows.Forms.ToolStrip sqlToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripAllSQL;
        private System.Windows.Forms.ToolStripButton toolStripWhereSQL;
        private System.Windows.Forms.ToolStripButton toolStripSQLByFrom;
        private System.Windows.Forms.ListBox detailsBox;
        private System.Windows.Forms.TabPage stackTraceTab;
        private System.Windows.Forms.ListView stackTraceListView;
        private System.Windows.Forms.ToolStripButton toolStripSQLErrors;
        private System.Windows.Forms.ListView sqlListView;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TextBox execFindBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox sqlFindBox;
        private System.Windows.Forms.TextBox stackTraceFindBox;
        private System.Windows.Forms.ContextMenuStrip sqlItemContextStrip;
        private System.Windows.Forms.ToolStripMenuItem copyStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBindsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyResolvedStatementToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip executionContextStrip;
        private System.Windows.Forms.ToolStripMenuItem copyStackTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyStackTraceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

