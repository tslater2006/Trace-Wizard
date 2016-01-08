namespace TraceWizard.UI
{
    partial class SQLViewer
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sqlListView = new System.Windows.Forms.ListView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.sqlItemContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBindsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyResolvedStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.sqlItemContextStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.sqlListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(771, 533);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 0;
            // 
            // sqlListView
            // 
            this.sqlListView.ContextMenuStrip = this.sqlItemContextStrip;
            this.sqlListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlListView.FullRowSelect = true;
            this.sqlListView.GridLines = true;
            this.sqlListView.Location = new System.Drawing.Point(0, 0);
            this.sqlListView.Name = "sqlListView";
            this.sqlListView.Size = new System.Drawing.Size(771, 338);
            this.sqlListView.TabIndex = 0;
            this.sqlListView.UseCompatibleStateImageBehavior = false;
            this.sqlListView.View = System.Windows.Forms.View.Details;
            this.sqlListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.sqlListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(771, 191);
            this.listBox1.TabIndex = 0;
            // 
            // sqlItemContextStrip
            // 
            this.sqlItemContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyStatementToolStripMenuItem,
            this.copyBindsToolStripMenuItem,
            this.copyResolvedStatementToolStripMenuItem});
            this.sqlItemContextStrip.Name = "sqlItemContextStrip";
            this.sqlItemContextStrip.Size = new System.Drawing.Size(210, 92);
            this.sqlItemContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.sqlItemContextStrip_Opening);
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
            // copyResolvedStatementToolStripMenuItem
            // 
            this.copyResolvedStatementToolStripMenuItem.Name = "copyResolvedStatementToolStripMenuItem";
            this.copyResolvedStatementToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.copyResolvedStatementToolStripMenuItem.Text = "Copy Resolved Statement";
            this.copyResolvedStatementToolStripMenuItem.Click += new System.EventHandler(this.copyResolvedStatementToolStripMenuItem_Click);
            // 
            // SQLViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 533);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SQLViewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.sqlItemContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView sqlListView;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip sqlItemContextStrip;
        private System.Windows.Forms.ToolStripMenuItem copyStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBindsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyResolvedStatementToolStripMenuItem;
    }
}