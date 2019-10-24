namespace ApiProject4.ShareParameter
{
    partial class frmDeleteGroup
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
            this.label2 = new System.Windows.Forms.Label();
            this.dropGroupChooesDelete = new System.Windows.Forms.ComboBox();
            this.btnDeleteGoupOrMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Do you want to move shared paramters to\r\n other group before delete group?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Group:";
            // 
            // dropGroupChooesDelete
            // 
            this.dropGroupChooesDelete.FormattingEnabled = true;
            this.dropGroupChooesDelete.Location = new System.Drawing.Point(58, 52);
            this.dropGroupChooesDelete.Name = "dropGroupChooesDelete";
            this.dropGroupChooesDelete.Size = new System.Drawing.Size(201, 21);
            this.dropGroupChooesDelete.TabIndex = 2;
            // 
            // btnDeleteGoupOrMove
            // 
            this.btnDeleteGoupOrMove.Location = new System.Drawing.Point(184, 82);
            this.btnDeleteGoupOrMove.Name = "btnDeleteGoupOrMove";
            this.btnDeleteGoupOrMove.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteGoupOrMove.TabIndex = 3;
            this.btnDeleteGoupOrMove.Text = "Delete";
            this.btnDeleteGoupOrMove.UseVisualStyleBackColor = true;
            this.btnDeleteGoupOrMove.Click += new System.EventHandler(this.btnDeleteGoupOrMove_Click);
            // 
            // frmDeleteGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 117);
            this.Controls.Add(this.btnDeleteGoupOrMove);
            this.Controls.Add(this.dropGroupChooesDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDeleteGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDeleteGroup";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDeleteGroup_FormClosed);
            this.Load += new System.EventHandler(this.frmDeleteGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox dropGroupChooesDelete;
        public System.Windows.Forms.Button btnDeleteGoupOrMove;
    }
}