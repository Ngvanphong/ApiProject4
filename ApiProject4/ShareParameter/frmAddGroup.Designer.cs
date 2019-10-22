namespace ApiProject4.ShareParameter
{
    partial class frmAddGroup
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
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewAddGroup = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(11, 137);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCreateGroup.TabIndex = 1;
            this.btnCreateGroup.Text = "OK";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 39);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter each new\r\ngroup name on\r\nseperable line.\r\n";
            // 
            // dataGridViewAddGroup
            // 
            this.dataGridViewAddGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAddGroup.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewAddGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAddGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewAddGroup.Location = new System.Drawing.Point(90, 13);
            this.dataGridViewAddGroup.Name = "dataGridViewAddGroup";
            this.dataGridViewAddGroup.RowHeadersVisible = false;
            this.dataGridViewAddGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewAddGroup.ShowEditingIcon = false;
            this.dataGridViewAddGroup.Size = new System.Drawing.Size(202, 147);
            this.dataGridViewAddGroup.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Group Name";
            this.Column1.Name = "Column1";
            // 
            // frmAddGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 168);
            this.Controls.Add(this.dataGridViewAddGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreateGroup);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddGroup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddGroup";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAddGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnCreateGroup;
        public System.Windows.Forms.DataGridView dataGridViewAddGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}