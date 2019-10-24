namespace ApiProject4.ShareParameter
{
    partial class frmRenameGroup
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
            this.dataGridViewRenameGroup = new System.Windows.Forms.DataGridView();
            this.btnRenameGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRenameGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRenameGroup
            // 
            this.dataGridViewRenameGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRenameGroup.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewRenameGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRenameGroup.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRenameGroup.Name = "dataGridViewRenameGroup";
            this.dataGridViewRenameGroup.RowHeadersVisible = false;
            this.dataGridViewRenameGroup.Size = new System.Drawing.Size(260, 141);
            this.dataGridViewRenameGroup.TabIndex = 0;
            // 
            // btnRenameGroup
            // 
            this.btnRenameGroup.Location = new System.Drawing.Point(197, 159);
            this.btnRenameGroup.Name = "btnRenameGroup";
            this.btnRenameGroup.Size = new System.Drawing.Size(75, 29);
            this.btnRenameGroup.TabIndex = 1;
            this.btnRenameGroup.Text = "OK";
            this.btnRenameGroup.UseVisualStyleBackColor = true;
            this.btnRenameGroup.Click += new System.EventHandler(this.btnRenameGroup_Click);
            // 
            // frmRenameGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 194);
            this.Controls.Add(this.btnRenameGroup);
            this.Controls.Add(this.dataGridViewRenameGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenameGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRenameGroup";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRenameGroup_FormClosed);
            this.Load += new System.EventHandler(this.frmRenameGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRenameGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnRenameGroup;
        public System.Windows.Forms.DataGridView dataGridViewRenameGroup;
    }
}