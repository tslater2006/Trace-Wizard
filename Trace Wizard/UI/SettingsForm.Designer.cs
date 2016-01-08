namespace TraceWizard.UI
{
    partial class SettingsForm
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
            this.executionPathGroup = new System.Windows.Forms.GroupBox();
            this.longCallValue = new System.Windows.Forms.TextBox();
            this.longCallSetting = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.executionPathGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // executionPathGroup
            // 
            this.executionPathGroup.Controls.Add(this.longCallValue);
            this.executionPathGroup.Controls.Add(this.longCallSetting);
            this.executionPathGroup.Location = new System.Drawing.Point(15, 12);
            this.executionPathGroup.Name = "executionPathGroup";
            this.executionPathGroup.Size = new System.Drawing.Size(400, 65);
            this.executionPathGroup.TabIndex = 2;
            this.executionPathGroup.TabStop = false;
            this.executionPathGroup.Text = "Execution Path";
            // 
            // longCallValue
            // 
            this.longCallValue.Location = new System.Drawing.Point(63, 27);
            this.longCallValue.Name = "longCallValue";
            this.longCallValue.Size = new System.Drawing.Size(100, 20);
            this.longCallValue.TabIndex = 3;
            this.longCallValue.TextChanged += new System.EventHandler(this.longCallValue_TextChanged);
            // 
            // longCallSetting
            // 
            this.longCallSetting.AutoSize = true;
            this.longCallSetting.Location = new System.Drawing.Point(6, 30);
            this.longCallSetting.Name = "longCallSetting";
            this.longCallSetting.Size = new System.Drawing.Size(54, 13);
            this.longCallSetting.TabIndex = 2;
            this.longCallSetting.Text = "Long Call:";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(180, 277);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 312);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.executionPathGroup);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trace Wizard Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.executionPathGroup.ResumeLayout(false);
            this.executionPathGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox executionPathGroup;
        private System.Windows.Forms.TextBox longCallValue;
        private System.Windows.Forms.Label longCallSetting;
        private System.Windows.Forms.Button closeButton;
    }
}