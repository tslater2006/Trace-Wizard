namespace TraceWizard.UI
{
    partial class CompareResult
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.diffLeft = new System.Windows.Forms.TreeView();
            this.diffRight = new System.Windows.Forms.TreeView();
            this.itemDetail = new System.Windows.Forms.ListBox();
            this.executionContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStackTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlItemContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyResolvedStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.copyStackTraceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.executionContextStrip.SuspendLayout();
            this.sqlItemContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(829, 527);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.itemDetail);
            this.splitContainer2.Size = new System.Drawing.Size(829, 527);
            this.splitContainer2.SplitterDistance = 398;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.diffLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.diffRight);
            this.splitContainer1.Size = new System.Drawing.Size(829, 398);
            this.splitContainer1.SplitterDistance = 427;
            this.splitContainer1.TabIndex = 0;
            // 
            // diffLeft
            // 
            this.diffLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diffLeft.HideSelection = false;
            this.diffLeft.Location = new System.Drawing.Point(0, 0);
            this.diffLeft.Name = "diffLeft";
            this.diffLeft.Size = new System.Drawing.Size(427, 398);
            this.diffLeft.TabIndex = 4;
            this.diffLeft.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.executionTree_BeforeExpand);
            this.diffLeft.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.executionTree_AfterExpand);
            this.diffLeft.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.executionTree_AfterSelect);
            this.diffLeft.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.execution_NodeClick);
            // 
            // diffRight
            // 
            this.diffRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diffRight.HideSelection = false;
            this.diffRight.Location = new System.Drawing.Point(0, 0);
            this.diffRight.Name = "diffRight";
            this.diffRight.Size = new System.Drawing.Size(398, 398);
            this.diffRight.TabIndex = 6;
            this.diffRight.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.executionTree_BeforeExpand);
            this.diffRight.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.executionTree_AfterExpand);
            this.diffRight.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.executionTree_AfterSelect);
            this.diffRight.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.execution_NodeClick);
            // 
            // itemDetail
            // 
            this.itemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDetail.FormattingEnabled = true;
            this.itemDetail.Location = new System.Drawing.Point(0, 0);
            this.itemDetail.Name = "itemDetail";
            this.itemDetail.Size = new System.Drawing.Size(829, 125);
            this.itemDetail.TabIndex = 0;
            // 
            // executionContextStrip
            // 
            this.executionContextStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.executionContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyStackTraceToolStripMenuItem});
            this.executionContextStrip.Name = "executionContextStrip";
            this.executionContextStrip.Size = new System.Drawing.Size(165, 26);
            // 
            // copyStackTraceToolStripMenuItem
            // 
            this.copyStackTraceToolStripMenuItem.Name = "copyStackTraceToolStripMenuItem";
            this.copyStackTraceToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyStackTraceToolStripMenuItem.Text = "Copy Stack Trace";
            this.copyStackTraceToolStripMenuItem.Click += new System.EventHandler(this.copyStackTraceToolStripMenuItem_Click);
            // 
            // sqlItemContextStrip
            // 
            this.sqlItemContextStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sqlItemContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyResolvedStatementToolStripMenuItem,
            this.copyStatementToolStripMenuItem,
            this.copyBindsToolStripMenuItem,
            this.toolStripSeparator2,
            this.copyStackTraceToolStripMenuItem1});
            this.sqlItemContextStrip.Name = "sqlItemContextStrip";
            this.sqlItemContextStrip.Size = new System.Drawing.Size(210, 98);
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
            // CompareResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 527);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompareResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CompareResult";
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.executionContextStrip.ResumeLayout(false);
            this.sqlItemContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView diffLeft;
        private System.Windows.Forms.TreeView diffRight;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox itemDetail;
        private System.Windows.Forms.ContextMenuStrip executionContextStrip;
        private System.Windows.Forms.ToolStripMenuItem copyStackTraceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip sqlItemContextStrip;
        private System.Windows.Forms.ToolStripMenuItem copyResolvedStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBindsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem copyStackTraceToolStripMenuItem1;
    }
}