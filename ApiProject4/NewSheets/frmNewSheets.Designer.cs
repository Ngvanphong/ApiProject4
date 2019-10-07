namespace ApiProject4.NewSheets
{
    partial class frmNewSheets
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
            this.textBoxQuantitySheet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSheetName = new System.Windows.Forms.TextBox();
            this.btnSheetNews = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumberStart = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sheet Quantity:";
            // 
            // textBoxQuantitySheet
            // 
            this.textBoxQuantitySheet.Location = new System.Drawing.Point(119, 67);
            this.textBoxQuantitySheet.Name = "textBoxQuantitySheet";
            this.textBoxQuantitySheet.Size = new System.Drawing.Size(171, 20);
            this.textBoxQuantitySheet.TabIndex = 1;
            this.textBoxQuantitySheet.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sheet Name:";
            // 
            // textBoxSheetName
            // 
            this.textBoxSheetName.Location = new System.Drawing.Point(119, 38);
            this.textBoxSheetName.Name = "textBoxSheetName";
            this.textBoxSheetName.Size = new System.Drawing.Size(273, 20);
            this.textBoxSheetName.TabIndex = 2;
            // 
            // btnSheetNews
            // 
            this.btnSheetNews.Location = new System.Drawing.Point(296, 64);
            this.btnSheetNews.Name = "btnSheetNews";
            this.btnSheetNews.Size = new System.Drawing.Size(95, 27);
            this.btnSheetNews.TabIndex = 3;
            this.btnSheetNews.Text = "Create";
            this.btnSheetNews.UseVisualStyleBackColor = true;
            this.btnSheetNews.Click += new System.EventHandler(this.btnSheetNews_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sheet Number Start:";
            // 
            // textBoxNumberStart
            // 
            this.textBoxNumberStart.Location = new System.Drawing.Point(118, 12);
            this.textBoxNumberStart.Name = "textBoxNumberStart";
            this.textBoxNumberStart.Size = new System.Drawing.Size(273, 20);
            this.textBoxNumberStart.TabIndex = 2;
            // 
            // frmNewSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 102);
            this.Controls.Add(this.btnSheetNews);
            this.Controls.Add(this.textBoxNumberStart);
            this.Controls.Add(this.textBoxSheetName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxQuantitySheet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmNewSheets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNewSheets";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxNumberStart;
        public System.Windows.Forms.TextBox textBoxSheetName;
        public System.Windows.Forms.TextBox textBoxQuantitySheet;
        public System.Windows.Forms.Button btnSheetNews;
    }
}