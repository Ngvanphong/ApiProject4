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
            this.TagImportExcel = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewSchedule = new System.Windows.Forms.ListView();
            this.radioButtonOneFile = new System.Windows.Forms.RadioButton();
            this.radioButtonManyFile = new System.Windows.Forms.RadioButton();
            this.listViewElement = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFolerOutput = new System.Windows.Forms.TextBox();
            this.btnFolderOutput = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.tabControlExcel.SuspendLayout();
            this.tabExportExcel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabExportExcel.Controls.Add(this.groupBox2);
            this.tabExportExcel.Controls.Add(this.groupBox1);
            this.tabExportExcel.Location = new System.Drawing.Point(4, 22);
            this.tabExportExcel.Name = "tabExportExcel";
            this.tabExportExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabExportExcel.Size = new System.Drawing.Size(661, 478);
            this.tabExportExcel.TabIndex = 0;
            this.tabExportExcel.Text = "Export";
            // 
            // TagImportExcel
            // 
            this.TagImportExcel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TagImportExcel.Location = new System.Drawing.Point(4, 22);
            this.TagImportExcel.Name = "TagImportExcel";
            this.TagImportExcel.Padding = new System.Windows.Forms.Padding(3);
            this.TagImportExcel.Size = new System.Drawing.Size(661, 508);
            this.TagImportExcel.TabIndex = 1;
            this.TagImportExcel.Text = "Import";
            this.TagImportExcel.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonManyFile);
            this.groupBox1.Controls.Add(this.radioButtonOneFile);
            this.groupBox1.Controls.Add(this.listViewSchedule);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 222);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedules";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewElement);
            this.groupBox2.Location = new System.Drawing.Point(7, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 197);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Element";
            // 
            // listViewSchedule
            // 
            this.listViewSchedule.CheckBoxes = true;
            this.listViewSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewSchedule.Location = new System.Drawing.Point(6, 20);
            this.listViewSchedule.Name = "listViewSchedule";
            this.listViewSchedule.Size = new System.Drawing.Size(637, 165);
            this.listViewSchedule.TabIndex = 0;
            this.listViewSchedule.UseCompatibleStateImageBehavior = false;
            this.listViewSchedule.View = System.Windows.Forms.View.Details;
            // 
            // radioButtonOneFile
            // 
            this.radioButtonOneFile.AutoSize = true;
            this.radioButtonOneFile.Checked = true;
            this.radioButtonOneFile.Location = new System.Drawing.Point(7, 192);
            this.radioButtonOneFile.Name = "radioButtonOneFile";
            this.radioButtonOneFile.Size = new System.Drawing.Size(163, 17);
            this.radioButtonOneFile.TabIndex = 1;
            this.radioButtonOneFile.TabStop = true;
            this.radioButtonOneFile.Text = "One file excel for all schedule";
            this.radioButtonOneFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonManyFile
            // 
            this.radioButtonManyFile.AutoSize = true;
            this.radioButtonManyFile.Location = new System.Drawing.Point(176, 192);
            this.radioButtonManyFile.Name = "radioButtonManyFile";
            this.radioButtonManyFile.Size = new System.Drawing.Size(159, 17);
            this.radioButtonManyFile.TabIndex = 2;
            this.radioButtonManyFile.Text = "One file excel for a schedule";
            this.radioButtonManyFile.UseVisualStyleBackColor = true;
            // 
            // listViewElement
            // 
            this.listViewElement.CheckBoxes = true;
            this.listViewElement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewElement.Location = new System.Drawing.Point(7, 20);
            this.listViewElement.Name = "listViewElement";
            this.listViewElement.Size = new System.Drawing.Size(635, 171);
            this.listViewElement.TabIndex = 0;
            this.listViewElement.UseCompatibleStateImageBehavior = false;
            this.listViewElement.View = System.Windows.Forms.View.Details;
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
            // textBoxFolerOutput
            // 
            this.textBoxFolerOutput.Location = new System.Drawing.Point(74, 445);
            this.textBoxFolerOutput.Name = "textBoxFolerOutput";
            this.textBoxFolerOutput.Size = new System.Drawing.Size(193, 20);
            this.textBoxFolerOutput.TabIndex = 3;
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
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 656;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 646;
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
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(326, 446);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(174, 20);
            this.textBoxFileName.TabIndex = 3;
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
            this.tabControlExcel.ResumeLayout(false);
            this.tabExportExcel.ResumeLayout(false);
            this.tabExportExcel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabControl tabControlExcel;
        public System.Windows.Forms.TabPage TagImportExcel;
        public System.Windows.Forms.TabPage tabExportExcel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView listViewSchedule;
        public System.Windows.Forms.ListView listViewElement;
        public System.Windows.Forms.TextBox textBoxFolerOutput;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnFolderOutput;
        public System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RadioButton radioButtonOneFile;
        public System.Windows.Forms.RadioButton radioButtonManyFile;
    }
}