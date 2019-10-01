namespace ApiProject4.ExportExcel
{
    partial class frmExportExcel
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
            this.tabControlExcel = new System.Windows.Forms.TabControl();
            this.tabExportExcel = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnFolderOutput = new System.Windows.Forms.Button();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFolerOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonManyFile = new System.Windows.Forms.RadioButton();
            this.radioButtonOneFile = new System.Windows.Forms.RadioButton();
            this.listViewSchedule = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagImportExcel = new System.Windows.Forms.TabPage();
            this.listViewInputFile = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnImport = new System.Windows.Forms.Button();
            this.btnInputPath = new System.Windows.Forms.Button();
            this.textBoxInputFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlExcel.SuspendLayout();
            this.tabExportExcel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TagImportExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlExcel
            // 
            this.tabControlExcel.Controls.Add(this.tabExportExcel);
            this.tabControlExcel.Controls.Add(this.TagImportExcel);
            this.tabControlExcel.Location = new System.Drawing.Point(12, 12);
            this.tabControlExcel.Name = "tabControlExcel";
            this.tabControlExcel.SelectedIndex = 0;
            this.tabControlExcel.Size = new System.Drawing.Size(669, 504);
            this.tabControlExcel.TabIndex = 1;
            // 
            // tabExportExcel
            // 
            this.tabExportExcel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabExportExcel.Controls.Add(this.btnExport);
            this.tabExportExcel.Controls.Add(this.btnFolderOutput);
            this.tabExportExcel.Controls.Add(this.textBoxFileName);
            this.tabExportExcel.Controls.Add(this.label2);
            this.tabExportExcel.Controls.Add(this.textBoxFolerOutput);
            this.tabExportExcel.Controls.Add(this.label1);
            this.tabExportExcel.Controls.Add(this.groupBox1);
            this.tabExportExcel.Location = new System.Drawing.Point(4, 22);
            this.tabExportExcel.Name = "tabExportExcel";
            this.tabExportExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportExcel.Size = new System.Drawing.Size(661, 478);
            this.tabExportExcel.TabIndex = 0;
            this.tabExportExcel.Text = "Export";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(580, 441);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 29);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnFolderOutput
            // 
            this.btnFolderOutput.Location = new System.Drawing.Point(503, 441);
            this.btnFolderOutput.Name = "btnFolderOutput";
            this.btnFolderOutput.Size = new System.Drawing.Size(75, 29);
            this.btnFolderOutput.TabIndex = 4;
            this.btnFolderOutput.Text = "Folder";
            this.btnFolderOutput.UseVisualStyleBackColor = true;
            this.btnFolderOutput.Click += new System.EventHandler(this.btnFolderOutput_Click);
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(326, 446);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(174, 20);
            this.textBoxFileName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File Name:";
            // 
            // textBoxFolerOutput
            // 
            this.textBoxFolerOutput.Location = new System.Drawing.Point(74, 445);
            this.textBoxFolerOutput.Name = "textBoxFolerOutput";
            this.textBoxFolerOutput.Size = new System.Drawing.Size(193, 20);
            this.textBoxFolerOutput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder output:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonManyFile);
            this.groupBox1.Controls.Add(this.radioButtonOneFile);
            this.groupBox1.Controls.Add(this.listViewSchedule);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 429);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedules";
            // 
            // radioButtonManyFile
            // 
            this.radioButtonManyFile.AutoSize = true;
            this.radioButtonManyFile.Location = new System.Drawing.Point(175, 406);
            this.radioButtonManyFile.Name = "radioButtonManyFile";
            this.radioButtonManyFile.Size = new System.Drawing.Size(159, 17);
            this.radioButtonManyFile.TabIndex = 2;
            this.radioButtonManyFile.Text = "One file excel for a schedule";
            this.radioButtonManyFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonOneFile
            // 
            this.radioButtonOneFile.AutoSize = true;
            this.radioButtonOneFile.Checked = true;
            this.radioButtonOneFile.Location = new System.Drawing.Point(6, 406);
            this.radioButtonOneFile.Name = "radioButtonOneFile";
            this.radioButtonOneFile.Size = new System.Drawing.Size(163, 17);
            this.radioButtonOneFile.TabIndex = 1;
            this.radioButtonOneFile.TabStop = true;
            this.radioButtonOneFile.Text = "One file excel for all schedule";
            this.radioButtonOneFile.UseVisualStyleBackColor = true;
            // 
            // listViewSchedule
            // 
            this.listViewSchedule.CheckBoxes = true;
            this.listViewSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewSchedule.Location = new System.Drawing.Point(6, 20);
            this.listViewSchedule.Name = "listViewSchedule";
            this.listViewSchedule.Size = new System.Drawing.Size(637, 380);
            this.listViewSchedule.TabIndex = 0;
            this.listViewSchedule.UseCompatibleStateImageBehavior = false;
            this.listViewSchedule.View = System.Windows.Forms.View.Details;
            this.listViewSchedule.SelectedIndexChanged += new System.EventHandler(this.listViewSchedule_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 637;
            // 
            // TagImportExcel
            // 
            this.TagImportExcel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TagImportExcel.Controls.Add(this.listViewInputFile);
            this.TagImportExcel.Controls.Add(this.btnImport);
            this.TagImportExcel.Controls.Add(this.btnInputPath);
            this.TagImportExcel.Controls.Add(this.textBoxInputFile);
            this.TagImportExcel.Controls.Add(this.label3);
            this.TagImportExcel.Location = new System.Drawing.Point(4, 22);
            this.TagImportExcel.Name = "TagImportExcel";
            this.TagImportExcel.Padding = new System.Windows.Forms.Padding(3);
            this.TagImportExcel.Size = new System.Drawing.Size(661, 478);
            this.TagImportExcel.TabIndex = 1;
            this.TagImportExcel.Text = "Import";
            this.TagImportExcel.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // listViewInputFile
            // 
            this.listViewInputFile.CheckBoxes = true;
            this.listViewInputFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewInputFile.Location = new System.Drawing.Point(10, 62);
            this.listViewInputFile.Name = "listViewInputFile";
            this.listViewInputFile.Size = new System.Drawing.Size(645, 373);
            this.listViewInputFile.TabIndex = 5;
            this.listViewInputFile.UseCompatibleStateImageBehavior = false;
            this.listViewInputFile.View = System.Windows.Forms.View.Details;
            this.listViewInputFile.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewInputFile_ItemChecked);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Worksheet Name";
            this.columnHeader2.Width = 641;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(580, 441);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 31);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnInputPath
            // 
            this.btnInputPath.Location = new System.Drawing.Point(580, 20);
            this.btnInputPath.Name = "btnInputPath";
            this.btnInputPath.Size = new System.Drawing.Size(75, 23);
            this.btnInputPath.TabIndex = 2;
            this.btnInputPath.Text = "Input";
            this.btnInputPath.UseVisualStyleBackColor = true;
            this.btnInputPath.Click += new System.EventHandler(this.btnInputPath_Click);
            // 
            // textBoxInputFile
            // 
            this.textBoxInputFile.Location = new System.Drawing.Point(69, 22);
            this.textBoxInputFile.Name = "textBoxInputFile";
            this.textBoxInputFile.Size = new System.Drawing.Size(505, 20);
            this.textBoxInputFile.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File path:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // frmExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 527);
            this.Controls.Add(this.tabControlExcel);
            this.MaximizeBox = false;
            this.Name = "frmExportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportExcel";
            this.TopMost = true;
            this.tabControlExcel.ResumeLayout(false);
            this.tabExportExcel.ResumeLayout(false);
            this.tabExportExcel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TagImportExcel.ResumeLayout(false);
            this.TagImportExcel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabControl tabControlExcel;
        public System.Windows.Forms.TabPage TagImportExcel;
        public System.Windows.Forms.TabPage tabExportExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView listViewSchedule;
        public System.Windows.Forms.TextBox textBoxFolerOutput;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnFolderOutput;
        public System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton radioButtonOneFile;
        public System.Windows.Forms.RadioButton radioButtonManyFile;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnInputPath;
        public System.Windows.Forms.TextBox textBoxInputFile;
        public System.Windows.Forms.ListView listViewInputFile;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Button btnImport;
    }
}