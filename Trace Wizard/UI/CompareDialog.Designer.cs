namespace TraceWizard.UI
{
    partial class CompareDialog
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
            this.execTreeLeft = new System.Windows.Forms.TreeView();
            this.execTreeRight = new System.Windows.Forms.TreeView();
            this.leftProgress = new System.Windows.Forms.ProgressBar();
            this.rightProgress = new System.Windows.Forms.ProgressBar();
            this.btnOpenLeft = new System.Windows.Forms.Button();
            this.btnOpenRight = new System.Windows.Forms.Button();
            this.btnCopyToRight = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLeftSelectAll = new System.Windows.Forms.Button();
            this.btnRightSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // execTreeLeft
            // 
            this.execTreeLeft.CheckBoxes = true;
            this.execTreeLeft.FullRowSelect = true;
            this.execTreeLeft.HideSelection = false;
            this.execTreeLeft.Location = new System.Drawing.Point(12, 43);
            this.execTreeLeft.Name = "execTreeLeft";
            this.execTreeLeft.Size = new System.Drawing.Size(330, 344);
            this.execTreeLeft.TabIndex = 2;
            this.execTreeLeft.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.execTree_AfterCheck);
            // 
            // execTreeRight
            // 
            this.execTreeRight.CheckBoxes = true;
            this.execTreeRight.HideSelection = false;
            this.execTreeRight.Location = new System.Drawing.Point(369, 43);
            this.execTreeRight.Name = "execTreeRight";
            this.execTreeRight.Size = new System.Drawing.Size(330, 344);
            this.execTreeRight.TabIndex = 3;
            this.execTreeRight.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.execTree_AfterCheck);
            // 
            // leftProgress
            // 
            this.leftProgress.Location = new System.Drawing.Point(12, 393);
            this.leftProgress.Name = "leftProgress";
            this.leftProgress.Size = new System.Drawing.Size(330, 23);
            this.leftProgress.TabIndex = 4;
            // 
            // rightProgress
            // 
            this.rightProgress.Location = new System.Drawing.Point(370, 393);
            this.rightProgress.Name = "rightProgress";
            this.rightProgress.Size = new System.Drawing.Size(330, 23);
            this.rightProgress.TabIndex = 5;
            // 
            // btnOpenLeft
            // 
            this.btnOpenLeft.Location = new System.Drawing.Point(12, 12);
            this.btnOpenLeft.Name = "btnOpenLeft";
            this.btnOpenLeft.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLeft.TabIndex = 6;
            this.btnOpenLeft.Text = "Open File";
            this.btnOpenLeft.UseVisualStyleBackColor = true;
            this.btnOpenLeft.Click += new System.EventHandler(this.btnOpenLeft_Click);
            // 
            // btnOpenRight
            // 
            this.btnOpenRight.Location = new System.Drawing.Point(370, 12);
            this.btnOpenRight.Name = "btnOpenRight";
            this.btnOpenRight.Size = new System.Drawing.Size(75, 23);
            this.btnOpenRight.TabIndex = 7;
            this.btnOpenRight.Text = "Open File";
            this.btnOpenRight.UseVisualStyleBackColor = true;
            this.btnOpenRight.Click += new System.EventHandler(this.btnOpenRight_Click);
            // 
            // btnCopyToRight
            // 
            this.btnCopyToRight.Enabled = false;
            this.btnCopyToRight.Location = new System.Drawing.Point(245, 12);
            this.btnCopyToRight.Name = "btnCopyToRight";
            this.btnCopyToRight.Size = new System.Drawing.Size(97, 23);
            this.btnCopyToRight.TabIndex = 8;
            this.btnCopyToRight.Text = "Copy To Right";
            this.btnCopyToRight.UseVisualStyleBackColor = true;
            this.btnCopyToRight.Click += new System.EventHandler(this.btnCopyToRight_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Enabled = false;
            this.btnCompare.Location = new System.Drawing.Point(315, 433);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 9;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLeftSelectAll
            // 
            this.btnLeftSelectAll.Enabled = false;
            this.btnLeftSelectAll.Location = new System.Drawing.Point(93, 12);
            this.btnLeftSelectAll.Name = "btnLeftSelectAll";
            this.btnLeftSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnLeftSelectAll.TabIndex = 10;
            this.btnLeftSelectAll.Text = "Select All";
            this.btnLeftSelectAll.UseVisualStyleBackColor = true;
            this.btnLeftSelectAll.Click += new System.EventHandler(this.btnLeftSelectAll_Click);
            // 
            // btnRightSelectAll
            // 
            this.btnRightSelectAll.Enabled = false;
            this.btnRightSelectAll.Location = new System.Drawing.Point(451, 12);
            this.btnRightSelectAll.Name = "btnRightSelectAll";
            this.btnRightSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnRightSelectAll.TabIndex = 11;
            this.btnRightSelectAll.Text = "Select All";
            this.btnRightSelectAll.UseVisualStyleBackColor = true;
            this.btnRightSelectAll.Click += new System.EventHandler(this.btnRightSelectAll_Click);
            // 
            // CompareDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 481);
            this.Controls.Add(this.btnRightSelectAll);
            this.Controls.Add(this.btnLeftSelectAll);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnCopyToRight);
            this.Controls.Add(this.btnOpenRight);
            this.Controls.Add(this.btnOpenLeft);
            this.Controls.Add(this.rightProgress);
            this.Controls.Add(this.leftProgress);
            this.Controls.Add(this.execTreeRight);
            this.Controls.Add(this.execTreeLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompareDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trace Compare";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView execTreeLeft;
        private System.Windows.Forms.TreeView execTreeRight;
        private System.Windows.Forms.ProgressBar leftProgress;
        private System.Windows.Forms.ProgressBar rightProgress;
        private System.Windows.Forms.Button btnOpenLeft;
        private System.Windows.Forms.Button btnOpenRight;
        private System.Windows.Forms.Button btnCopyToRight;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLeftSelectAll;
        private System.Windows.Forms.Button btnRightSelectAll;
    }
}