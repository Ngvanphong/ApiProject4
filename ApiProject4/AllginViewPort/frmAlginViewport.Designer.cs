namespace ApiProject4.AllginViewPort
{
    partial class frmAlginViewport
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
            this.listViewChooseSheet = new System.Windows.Forms.ListView();
            this.btnAlignViewportBinding = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCheckedNone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewChooseSheet
            // 
            this.listViewChooseSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewChooseSheet.CheckBoxes = true;
            this.listViewChooseSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewChooseSheet.Location = new System.Drawing.Point(3, 13);
            this.listViewChooseSheet.Name = "listViewChooseSheet";
            this.listViewChooseSheet.Size = new System.Drawing.Size(533, 410);
            this.listViewChooseSheet.TabIndex = 0;
            this.listViewChooseSheet.UseCompatibleStateImageBehavior = false;
            this.listViewChooseSheet.View = System.Windows.Forms.View.Details;
            // 
            // btnAlignViewportBinding
            // 
            this.btnAlignViewportBinding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlignViewportBinding.Location = new System.Drawing.Point(461, 429);
            this.btnAlignViewportBinding.Name = "btnAlignViewportBinding";
            this.btnAlignViewportBinding.Size = new System.Drawing.Size(75, 23);
            this.btnAlignViewportBinding.TabIndex = 1;
            this.btnAlignViewportBinding.Text = "OK";
            this.btnAlignViewportBinding.UseVisualStyleBackColor = true;
            this.btnAlignViewportBinding.Click += new System.EventHandler(this.btnAlignViewportBinding_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sheet Number";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sheet Name";
            this.columnHeader2.Width = 414;
            // 
            // btnCheckedNone
            // 
            this.btnCheckedNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckedNone.FlatAppearance.BorderSize = 0;
            this.btnCheckedNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckedNone.Image = global::ApiProject4.Properties.Resources.list;
            this.btnCheckedNone.Location = new System.Drawing.Point(423, 427);
            this.btnCheckedNone.Name = "btnCheckedNone";
            this.btnCheckedNone.Size = new System.Drawing.Size(32, 29);
            this.btnCheckedNone.TabIndex = 1;
            this.btnCheckedNone.UseVisualStyleBackColor = true;
            // 
            // frmAlginViewport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 457);
            this.Controls.Add(this.btnCheckedNone);
            this.Controls.Add(this.btnAlignViewportBinding);
            this.Controls.Add(this.listViewChooseSheet);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlginViewport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAlginViewport";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListView listViewChooseSheet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Button btnCheckedNone;
        public System.Windows.Forms.Button btnAlignViewportBinding;
    }
}