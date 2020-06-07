namespace ApiProject4.ScopeBox
{
    partial class frmScopeBox
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
            this.button1 = new System.Windows.Forms.Button();
            this.listViewScopeBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewViewScopeBox = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "Assign";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewScopeBox
            // 
            this.listViewScopeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewScopeBox.CheckBoxes = true;
            this.listViewScopeBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewScopeBox.Location = new System.Drawing.Point(13, 27);
            this.listViewScopeBox.Name = "listViewScopeBox";
            this.listViewScopeBox.Size = new System.Drawing.Size(246, 371);
            this.listViewScopeBox.TabIndex = 3;
            this.listViewScopeBox.UseCompatibleStateImageBehavior = false;
            this.listViewScopeBox.View = System.Windows.Forms.View.Details;
            this.listViewScopeBox.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewScopeBox_ItemChecked);
            this.listViewScopeBox.SelectedIndexChanged += new System.EventHandler(this.listViewScopeBox_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Scope Box Name";
            this.columnHeader1.Width = 243;
            // 
            // listViewViewScopeBox
            // 
            this.listViewViewScopeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewViewScopeBox.CheckBoxes = true;
            this.listViewViewScopeBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewViewScopeBox.Location = new System.Drawing.Point(353, 27);
            this.listViewViewScopeBox.Name = "listViewViewScopeBox";
            this.listViewViewScopeBox.Size = new System.Drawing.Size(403, 371);
            this.listViewViewScopeBox.TabIndex = 4;
            this.listViewViewScopeBox.UseCompatibleStateImageBehavior = false;
            this.listViewViewScopeBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type/ViewName";
            this.columnHeader2.Width = 1500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose scope box:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose view assign:";
            // 
            // frmScopeBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewViewScopeBox);
            this.Controls.Add(this.listViewScopeBox);
            this.Controls.Add(this.button1);
            this.Name = "frmScopeBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScopeBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmScopeBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView listViewScopeBox;
        public System.Windows.Forms.ListView listViewViewScopeBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}