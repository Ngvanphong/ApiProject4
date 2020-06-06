namespace ApiProject4.PrintSort
{
    partial class frmPrintSort
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
            this.listBoxSetPrinter = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNamePrinterSet = new System.Windows.Forms.TextBox();
            this.btnSetPrint = new System.Windows.Forms.Button();
            this.btnPrinterAction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPathExcel = new System.Windows.Forms.TextBox();
            this.btnImportPrint = new System.Windows.Forms.Button();
            this.btnExportPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonManualChoose = new System.Windows.Forms.RadioButton();
            this.radioButtonAutoSchedule = new System.Windows.Forms.RadioButton();
            this.btnSaveSet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSetPrinter
            // 
            this.listBoxSetPrinter.FormattingEnabled = true;
            this.listBoxSetPrinter.Location = new System.Drawing.Point(13, 17);
            this.listBoxSetPrinter.Name = "listBoxSetPrinter";
            this.listBoxSetPrinter.Size = new System.Drawing.Size(236, 134);
            this.listBoxSetPrinter.TabIndex = 0;
            this.listBoxSetPrinter.SelectedIndexChanged += new System.EventHandler(this.listBoxSetPrinter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a set printer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name set:";
            // 
            // textBoxNamePrinterSet
            // 
            this.textBoxNamePrinterSet.Location = new System.Drawing.Point(57, 157);
            this.textBoxNamePrinterSet.Name = "textBoxNamePrinterSet";
            this.textBoxNamePrinterSet.Size = new System.Drawing.Size(192, 20);
            this.textBoxNamePrinterSet.TabIndex = 3;
            // 
            // btnSetPrint
            // 
            this.btnSetPrint.Location = new System.Drawing.Point(191, 247);
            this.btnSetPrint.Name = "btnSetPrint";
            this.btnSetPrint.Size = new System.Drawing.Size(75, 23);
            this.btnSetPrint.TabIndex = 4;
            this.btnSetPrint.Text = "Set";
            this.btnSetPrint.UseVisualStyleBackColor = true;
            this.btnSetPrint.Click += new System.EventHandler(this.btnSetPrint_Click);
            // 
            // btnPrinterAction
            // 
            this.btnPrinterAction.Location = new System.Drawing.Point(351, 247);
            this.btnPrinterAction.Name = "btnPrinterAction";
            this.btnPrinterAction.Size = new System.Drawing.Size(75, 23);
            this.btnPrinterAction.TabIndex = 5;
            this.btnPrinterAction.Text = "Print Exit";
            this.btnPrinterAction.UseVisualStyleBackColor = true;
            this.btnPrinterAction.Click += new System.EventHandler(this.btnPrinterAction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Excel file:";
            // 
            // textBoxPathExcel
            // 
            this.textBoxPathExcel.Location = new System.Drawing.Point(71, 220);
            this.textBoxPathExcel.Name = "textBoxPathExcel";
            this.textBoxPathExcel.Size = new System.Drawing.Size(195, 20);
            this.textBoxPathExcel.TabIndex = 6;
            // 
            // btnImportPrint
            // 
            this.btnImportPrint.Location = new System.Drawing.Point(272, 218);
            this.btnImportPrint.Name = "btnImportPrint";
            this.btnImportPrint.Size = new System.Drawing.Size(75, 23);
            this.btnImportPrint.TabIndex = 7;
            this.btnImportPrint.Text = "Import";
            this.btnImportPrint.UseVisualStyleBackColor = true;
            this.btnImportPrint.Click += new System.EventHandler(this.btnImportPrint_Click);
            // 
            // btnExportPrint
            // 
            this.btnExportPrint.Location = new System.Drawing.Point(351, 218);
            this.btnExportPrint.Name = "btnExportPrint";
            this.btnExportPrint.Size = new System.Drawing.Size(75, 23);
            this.btnExportPrint.TabIndex = 7;
            this.btnExportPrint.Text = "Export";
            this.btnExportPrint.UseVisualStyleBackColor = true;
            this.btnExportPrint.Click += new System.EventHandler(this.btnExportPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxSetPrinter);
            this.groupBox1.Controls.Add(this.textBoxNamePrinterSet);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(170, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 183);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set print";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonManualChoose);
            this.groupBox2.Controls.Add(this.radioButtonAutoSchedule);
            this.groupBox2.Location = new System.Drawing.Point(6, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 183);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Method printing";
            // 
            // radioButtonManualChoose
            // 
            this.radioButtonManualChoose.AutoSize = true;
            this.radioButtonManualChoose.Checked = true;
            this.radioButtonManualChoose.Location = new System.Drawing.Point(6, 40);
            this.radioButtonManualChoose.Name = "radioButtonManualChoose";
            this.radioButtonManualChoose.Size = new System.Drawing.Size(133, 17);
            this.radioButtonManualChoose.TabIndex = 0;
            this.radioButtonManualChoose.TabStop = true;
            this.radioButtonManualChoose.Text = "Manual choose adding";
            this.radioButtonManualChoose.UseVisualStyleBackColor = true;
            // 
            // radioButtonAutoSchedule
            // 
            this.radioButtonAutoSchedule.AutoSize = true;
            this.radioButtonAutoSchedule.Location = new System.Drawing.Point(6, 17);
            this.radioButtonAutoSchedule.Name = "radioButtonAutoSchedule";
            this.radioButtonAutoSchedule.Size = new System.Drawing.Size(152, 17);
            this.radioButtonAutoSchedule.TabIndex = 0;
            this.radioButtonAutoSchedule.Text = "Auto follow schedule sheet";
            this.radioButtonAutoSchedule.UseVisualStyleBackColor = true;
            // 
            // btnSaveSet
            // 
            this.btnSaveSet.Location = new System.Drawing.Point(272, 247);
            this.btnSaveSet.Name = "btnSaveSet";
            this.btnSaveSet.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSet.TabIndex = 10;
            this.btnSaveSet.Text = "Save";
            this.btnSaveSet.UseVisualStyleBackColor = true;
            this.btnSaveSet.Click += new System.EventHandler(this.btnSaveSet_Click);
            // 
            // frmPrintSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 279);
            this.Controls.Add(this.btnSaveSet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportPrint);
            this.Controls.Add(this.btnSetPrint);
            this.Controls.Add(this.btnImportPrint);
            this.Controls.Add(this.textBoxPathExcel);
            this.Controls.Add(this.btnPrinterAction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintSort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrintSort";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPrintSort_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxSetPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxNamePrinterSet;
        public System.Windows.Forms.Button btnSetPrint;
        public System.Windows.Forms.Button btnPrinterAction;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnExportPrint;
        public System.Windows.Forms.Button btnImportPrint;
        public System.Windows.Forms.TextBox textBoxPathExcel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton radioButtonManualChoose;
        public System.Windows.Forms.RadioButton radioButtonAutoSchedule;
        private System.Windows.Forms.Button btnSaveSet;
    }
}