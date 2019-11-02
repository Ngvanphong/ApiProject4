namespace ApiProject4.KeynoteManager
{
    partial class frmAddKeyNote
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
            this.dataGridViewAddKeynote = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddKeynote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddKeynote)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAddKeynote
            // 
            this.dataGridViewAddKeynote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAddKeynote.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewAddKeynote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddKeynote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewAddKeynote.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewAddKeynote.Name = "dataGridViewAddKeynote";
            this.dataGridViewAddKeynote.RowHeadersVisible = false;
            this.dataGridViewAddKeynote.Size = new System.Drawing.Size(768, 206);
            this.dataGridViewAddKeynote.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ParentId";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Id";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Discription";
            this.Column3.Name = "Column3";
            // 
            // btnAddKeynote
            // 
            this.btnAddKeynote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddKeynote.Location = new System.Drawing.Point(705, 226);
            this.btnAddKeynote.Name = "btnAddKeynote";
            this.btnAddKeynote.Size = new System.Drawing.Size(75, 34);
            this.btnAddKeynote.TabIndex = 1;
            this.btnAddKeynote.Text = "OK";
            this.btnAddKeynote.UseVisualStyleBackColor = true;
            this.btnAddKeynote.Click += new System.EventHandler(this.btnAddKeynote_Click);
            // 
            // frmAddKeyNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 272);
            this.Controls.Add(this.btnAddKeynote);
            this.Controls.Add(this.dataGridViewAddKeynote);
            this.MinimizeBox = false;
            this.Name = "frmAddKeyNote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddKeyNote";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddKeyNote_FormClosed);
            this.Load += new System.EventHandler(this.frmAddKeyNote_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddKeynote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnAddKeynote;
        public System.Windows.Forms.DataGridView dataGridViewAddKeynote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}