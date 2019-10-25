namespace ApiProject4.ShareParameter
{
    partial class frmMergeGroup
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
            this.label1 = new System.Windows.Forms.Label();
            this.dropGroupMerge = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMergeParameterBind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Do you want to merge to other group\r\n or the sample name group of master file?";
            // 
            // dropGroupMerge
            // 
            this.dropGroupMerge.FormattingEnabled = true;
            this.dropGroupMerge.Location = new System.Drawing.Point(61, 47);
            this.dropGroupMerge.Name = "dropGroupMerge";
            this.dropGroupMerge.Size = new System.Drawing.Size(167, 21);
            this.dropGroupMerge.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Group to:";
            // 
            // btnMergeParameterBind
            // 
            this.btnMergeParameterBind.Location = new System.Drawing.Point(152, 74);
            this.btnMergeParameterBind.Name = "btnMergeParameterBind";
            this.btnMergeParameterBind.Size = new System.Drawing.Size(75, 24);
            this.btnMergeParameterBind.TabIndex = 3;
            this.btnMergeParameterBind.Text = "OK";
            this.btnMergeParameterBind.UseVisualStyleBackColor = true;
            this.btnMergeParameterBind.Click += new System.EventHandler(this.btnMergeParameterBind_Click);
            // 
            // frmMergeGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 108);
            this.Controls.Add(this.btnMergeParameterBind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dropGroupMerge);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMergeGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMergeParameter";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMergeGroup_FormClosed);
            this.Load += new System.EventHandler(this.frmMergeGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox dropGroupMerge;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnMergeParameterBind;
    }
}