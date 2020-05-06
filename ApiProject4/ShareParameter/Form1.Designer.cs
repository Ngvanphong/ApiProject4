namespace ApiProject4.ShareParameter
{
    partial class frmAddSharedParameter
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
            this.dropParameterGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dropParameterType = new System.Windows.Forms.ComboBox();
            this.dataGridViewCreateParameter = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreateParameter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDisciiplinePara = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCreateParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parameter Group:";
            // 
            // dropParameterGroup
            // 
            this.dropParameterGroup.FormattingEnabled = true;
            this.dropParameterGroup.Location = new System.Drawing.Point(115, 13);
            this.dropParameterGroup.Name = "dropParameterGroup";
            this.dropParameterGroup.Size = new System.Drawing.Size(311, 21);
            this.dropParameterGroup.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parameter Type:";
            // 
            // dropParameterType
            // 
            this.dropParameterType.FormattingEnabled = true;
            this.dropParameterType.Location = new System.Drawing.Point(115, 72);
            this.dropParameterType.Name = "dropParameterType";
            this.dropParameterType.Size = new System.Drawing.Size(311, 21);
            this.dropParameterType.TabIndex = 1;
            // 
            // dataGridViewCreateParameter
            // 
            this.dataGridViewCreateParameter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCreateParameter.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewCreateParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCreateParameter.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewCreateParameter.Location = new System.Drawing.Point(115, 104);
            this.dataGridViewCreateParameter.Name = "dataGridViewCreateParameter";
            this.dataGridViewCreateParameter.RowHeadersVisible = false;
            this.dataGridViewCreateParameter.Size = new System.Drawing.Size(311, 116);
            this.dataGridViewCreateParameter.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name Parameter";
            this.Column1.Name = "Column1";
            // 
            // btnCreateParameter
            // 
            this.btnCreateParameter.Location = new System.Drawing.Point(20, 194);
            this.btnCreateParameter.Name = "btnCreateParameter";
            this.btnCreateParameter.Size = new System.Drawing.Size(75, 26);
            this.btnCreateParameter.TabIndex = 3;
            this.btnCreateParameter.Text = "Create";
            this.btnCreateParameter.UseVisualStyleBackColor = true;
            this.btnCreateParameter.Click += new System.EventHandler(this.btnCreateParameter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 52);
            this.label5.TabIndex = 0;
            this.label5.Text = "\r\nEnter each new\r\nparameter name\r\non seperate line.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Discipline:";
            // 
            // comboBoxDisciiplinePara
            // 
            this.comboBoxDisciiplinePara.FormattingEnabled = true;
            this.comboBoxDisciiplinePara.Location = new System.Drawing.Point(115, 42);
            this.comboBoxDisciiplinePara.Name = "comboBoxDisciiplinePara";
            this.comboBoxDisciiplinePara.Size = new System.Drawing.Size(311, 21);
            this.comboBoxDisciiplinePara.TabIndex = 1;
            this.comboBoxDisciiplinePara.SelectedIndexChanged += new System.EventHandler(this.comboBoxDisciiplinePara_SelectedIndexChanged);
            // 
            // frmAddSharedParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 234);
            this.Controls.Add(this.btnCreateParameter);
            this.Controls.Add(this.dataGridViewCreateParameter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxDisciiplinePara);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dropParameterType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dropParameterGroup);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddSharedParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddParameters";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddSharedParameter_FormClosed);
            this.Load += new System.EventHandler(this.frmAddSharedParameter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCreateParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnCreateParameter;
        public System.Windows.Forms.ComboBox dropParameterGroup;
        public System.Windows.Forms.ComboBox dropParameterType;
        public System.Windows.Forms.DataGridView dataGridViewCreateParameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBoxDisciiplinePara;
    }
}