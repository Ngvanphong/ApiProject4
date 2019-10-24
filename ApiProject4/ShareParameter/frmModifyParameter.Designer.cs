namespace ApiProject4.ShareParameter
{
    partial class frmModifyParameter
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
            this.txtNameParaModify = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxVisibleParameter = new System.Windows.Forms.CheckBox();
            this.btnModifyParameter = new System.Windows.Forms.Button();
            this.dropGroupParaModify = new System.Windows.Forms.ComboBox();
            this.dropTypeParaModify = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtNameParaModify
            // 
            this.txtNameParaModify.Location = new System.Drawing.Point(68, 13);
            this.txtNameParaModify.Name = "txtNameParaModify";
            this.txtNameParaModify.Size = new System.Drawing.Size(229, 20);
            this.txtNameParaModify.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Type:";
            // 
            // checkBoxVisibleParameter
            // 
            this.checkBoxVisibleParameter.AutoSize = true;
            this.checkBoxVisibleParameter.Location = new System.Drawing.Point(68, 100);
            this.checkBoxVisibleParameter.Name = "checkBoxVisibleParameter";
            this.checkBoxVisibleParameter.Size = new System.Drawing.Size(56, 17);
            this.checkBoxVisibleParameter.TabIndex = 2;
            this.checkBoxVisibleParameter.Text = "Visible";
            this.checkBoxVisibleParameter.UseVisualStyleBackColor = true;
            // 
            // btnModifyParameter
            // 
            this.btnModifyParameter.Location = new System.Drawing.Point(222, 96);
            this.btnModifyParameter.Name = "btnModifyParameter";
            this.btnModifyParameter.Size = new System.Drawing.Size(75, 23);
            this.btnModifyParameter.TabIndex = 3;
            this.btnModifyParameter.Text = "OK";
            this.btnModifyParameter.UseVisualStyleBackColor = true;
            this.btnModifyParameter.Click += new System.EventHandler(this.btnModifyParameter_Click);
            // 
            // dropGroupParaModify
            // 
            this.dropGroupParaModify.FormattingEnabled = true;
            this.dropGroupParaModify.Location = new System.Drawing.Point(68, 39);
            this.dropGroupParaModify.Name = "dropGroupParaModify";
            this.dropGroupParaModify.Size = new System.Drawing.Size(229, 21);
            this.dropGroupParaModify.TabIndex = 4;
            // 
            // dropTypeParaModify
            // 
            this.dropTypeParaModify.FormattingEnabled = true;
            this.dropTypeParaModify.Location = new System.Drawing.Point(68, 65);
            this.dropTypeParaModify.Name = "dropTypeParaModify";
            this.dropTypeParaModify.Size = new System.Drawing.Size(229, 21);
            this.dropTypeParaModify.TabIndex = 4;
            // 
            // frmModifyParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 131);
            this.Controls.Add(this.dropTypeParaModify);
            this.Controls.Add(this.dropGroupParaModify);
            this.Controls.Add(this.btnModifyParameter);
            this.Controls.Add(this.checkBoxVisibleParameter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNameParaModify);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmModifyParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModifyParameter";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNameParaModify;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox checkBoxVisibleParameter;
        public System.Windows.Forms.Button btnModifyParameter;
        public System.Windows.Forms.ComboBox dropGroupParaModify;
        public System.Windows.Forms.ComboBox dropTypeParaModify;
    }
}