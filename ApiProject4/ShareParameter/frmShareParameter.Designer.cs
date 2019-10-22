namespace ApiProject4.ShareParameter
{
    partial class frmShareParameter
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TagShareParameterFile = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeViewSourceParameter = new System.Windows.Forms.TreeView();
            this.dropGroupBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathSourceSharedPamameter = new System.Windows.Forms.TextBox();
            this.btnFindSourceParameterFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteParameter = new System.Windows.Forms.Button();
            this.btnModifyParamter = new System.Windows.Forms.Button();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnRenameGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnSaveParameterFile = new System.Windows.Forms.Button();
            this.btnFindMasterFile = new System.Windows.Forms.Button();
            this.btnNewFileParamter = new System.Windows.Forms.Button();
            this.txtMasterPathShareParameterFile = new System.Windows.Forms.TextBox();
            this.treeViewMasterParameter = new System.Windows.Forms.TreeView();
            this.checkBoxShowOnly = new System.Windows.Forms.CheckBox();
            this.dropFilterParameterSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearValueParameter = new System.Windows.Forms.Button();
            this.txtValueSearchPamater = new System.Windows.Forms.TextBox();
            this.dropFilterParameters = new System.Windows.Forms.ComboBox();
            this.tagLoadParameterFile = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.TagShareParameterFile.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TagShareParameterFile);
            this.tabControl1.Controls.Add(this.tagLoadParameterFile);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // TagShareParameterFile
            // 
            this.TagShareParameterFile.Controls.Add(this.groupBox2);
            this.TagShareParameterFile.Controls.Add(this.groupBox1);
            this.TagShareParameterFile.Controls.Add(this.checkBoxShowOnly);
            this.TagShareParameterFile.Controls.Add(this.dropFilterParameterSource);
            this.TagShareParameterFile.Controls.Add(this.label1);
            this.TagShareParameterFile.Controls.Add(this.btnClearValueParameter);
            this.TagShareParameterFile.Controls.Add(this.txtValueSearchPamater);
            this.TagShareParameterFile.Controls.Add(this.dropFilterParameters);
            this.TagShareParameterFile.Location = new System.Drawing.Point(4, 22);
            this.TagShareParameterFile.Name = "TagShareParameterFile";
            this.TagShareParameterFile.Padding = new System.Windows.Forms.Padding(3);
            this.TagShareParameterFile.Size = new System.Drawing.Size(851, 493);
            this.TagShareParameterFile.TabIndex = 0;
            this.TagShareParameterFile.Text = "Shared Parameter File";
            this.TagShareParameterFile.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeViewSourceParameter);
            this.groupBox2.Controls.Add(this.dropGroupBy);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPathSourceSharedPamameter);
            this.groupBox2.Controls.Add(this.btnFindSourceParameterFile);
            this.groupBox2.Location = new System.Drawing.Point(494, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 443);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Shared Parameter File";
            // 
            // treeViewSourceParameter
            // 
            this.treeViewSourceParameter.Location = new System.Drawing.Point(7, 78);
            this.treeViewSourceParameter.Name = "treeViewSourceParameter";
            this.treeViewSourceParameter.Size = new System.Drawing.Size(338, 359);
            this.treeViewSourceParameter.TabIndex = 5;
            // 
            // dropGroupBy
            // 
            this.dropGroupBy.FormattingEnabled = true;
            this.dropGroupBy.Location = new System.Drawing.Point(66, 48);
            this.dropGroupBy.Name = "dropGroupBy";
            this.dropGroupBy.Size = new System.Drawing.Size(198, 21);
            this.dropGroupBy.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Group By:";
            // 
            // txtPathSourceSharedPamameter
            // 
            this.txtPathSourceSharedPamameter.Location = new System.Drawing.Point(6, 21);
            this.txtPathSourceSharedPamameter.Name = "txtPathSourceSharedPamameter";
            this.txtPathSourceSharedPamameter.Size = new System.Drawing.Size(258, 20);
            this.txtPathSourceSharedPamameter.TabIndex = 1;
            // 
            // btnFindSourceParameterFile
            // 
            this.btnFindSourceParameterFile.Location = new System.Drawing.Point(270, 19);
            this.btnFindSourceParameterFile.Name = "btnFindSourceParameterFile";
            this.btnFindSourceParameterFile.Size = new System.Drawing.Size(75, 23);
            this.btnFindSourceParameterFile.TabIndex = 2;
            this.btnFindSourceParameterFile.Text = "Browse...";
            this.btnFindSourceParameterFile.UseVisualStyleBackColor = true;
            this.btnFindSourceParameterFile.Click += new System.EventHandler(this.btnFindSourceParameterFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSaveParameterFile);
            this.groupBox1.Controls.Add(this.btnFindMasterFile);
            this.groupBox1.Controls.Add(this.btnNewFileParamter);
            this.groupBox1.Controls.Add(this.txtMasterPathShareParameterFile);
            this.groupBox1.Controls.Add(this.treeViewMasterParameter);
            this.groupBox1.Location = new System.Drawing.Point(7, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 444);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manager Shared Parameter File";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteParameter);
            this.groupBox4.Controls.Add(this.btnModifyParamter);
            this.groupBox4.Controls.Add(this.btnAddParameter);
            this.groupBox4.Location = new System.Drawing.Point(342, 79);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(108, 117);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // btnDeleteParameter
            // 
            this.btnDeleteParameter.Location = new System.Drawing.Point(15, 77);
            this.btnDeleteParameter.Name = "btnDeleteParameter";
            this.btnDeleteParameter.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteParameter.TabIndex = 0;
            this.btnDeleteParameter.Text = "Delete";
            this.btnDeleteParameter.UseVisualStyleBackColor = true;
            // 
            // btnModifyParamter
            // 
            this.btnModifyParamter.Location = new System.Drawing.Point(15, 48);
            this.btnModifyParamter.Name = "btnModifyParamter";
            this.btnModifyParamter.Size = new System.Drawing.Size(75, 23);
            this.btnModifyParamter.TabIndex = 0;
            this.btnModifyParamter.Text = "Modify";
            this.btnModifyParamter.UseVisualStyleBackColor = true;
            this.btnModifyParamter.Click += new System.EventHandler(this.btnModifyParamter_Click);
            // 
            // btnAddParameter
            // 
            this.btnAddParameter.Location = new System.Drawing.Point(15, 19);
            this.btnAddParameter.Name = "btnAddParameter";
            this.btnAddParameter.Size = new System.Drawing.Size(75, 23);
            this.btnAddParameter.TabIndex = 0;
            this.btnAddParameter.Text = "Add";
            this.btnAddParameter.UseVisualStyleBackColor = true;
            this.btnAddParameter.Click += new System.EventHandler(this.btnAddParameter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteGroup);
            this.groupBox3.Controls.Add(this.btnRenameGroup);
            this.groupBox3.Controls.Add(this.btnAddGroup);
            this.groupBox3.Location = new System.Drawing.Point(342, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(108, 117);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Groups";
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(15, 77);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteGroup.TabIndex = 0;
            this.btnDeleteGroup.Text = "Delete";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnRenameGroup
            // 
            this.btnRenameGroup.Location = new System.Drawing.Point(15, 48);
            this.btnRenameGroup.Name = "btnRenameGroup";
            this.btnRenameGroup.Size = new System.Drawing.Size(75, 23);
            this.btnRenameGroup.TabIndex = 0;
            this.btnRenameGroup.Text = "Rename";
            this.btnRenameGroup.UseVisualStyleBackColor = true;
            this.btnRenameGroup.Click += new System.EventHandler(this.btnRenameGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(15, 19);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(75, 23);
            this.btnAddGroup.TabIndex = 0;
            this.btnAddGroup.Text = "Add";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnSaveParameterFile
            // 
            this.btnSaveParameterFile.Location = new System.Drawing.Point(377, 19);
            this.btnSaveParameterFile.Name = "btnSaveParameterFile";
            this.btnSaveParameterFile.Size = new System.Drawing.Size(75, 23);
            this.btnSaveParameterFile.TabIndex = 3;
            this.btnSaveParameterFile.Text = "Save";
            this.btnSaveParameterFile.UseVisualStyleBackColor = true;
            // 
            // btnFindMasterFile
            // 
            this.btnFindMasterFile.Location = new System.Drawing.Point(296, 19);
            this.btnFindMasterFile.Name = "btnFindMasterFile";
            this.btnFindMasterFile.Size = new System.Drawing.Size(75, 23);
            this.btnFindMasterFile.TabIndex = 3;
            this.btnFindMasterFile.Text = "Browse...";
            this.btnFindMasterFile.UseVisualStyleBackColor = true;
            this.btnFindMasterFile.Click += new System.EventHandler(this.btnFindMasterFile_Click);
            // 
            // btnNewFileParamter
            // 
            this.btnNewFileParamter.Location = new System.Drawing.Point(215, 19);
            this.btnNewFileParamter.Name = "btnNewFileParamter";
            this.btnNewFileParamter.Size = new System.Drawing.Size(75, 23);
            this.btnNewFileParamter.TabIndex = 2;
            this.btnNewFileParamter.Text = "New";
            this.btnNewFileParamter.UseVisualStyleBackColor = true;
            this.btnNewFileParamter.Click += new System.EventHandler(this.btnNewFileParamter_Click);
            // 
            // txtMasterPathShareParameterFile
            // 
            this.txtMasterPathShareParameterFile.Location = new System.Drawing.Point(7, 21);
            this.txtMasterPathShareParameterFile.Name = "txtMasterPathShareParameterFile";
            this.txtMasterPathShareParameterFile.Size = new System.Drawing.Size(202, 20);
            this.txtMasterPathShareParameterFile.TabIndex = 1;
            // 
            // treeViewMasterParameter
            // 
            this.treeViewMasterParameter.Location = new System.Drawing.Point(7, 79);
            this.treeViewMasterParameter.Name = "treeViewMasterParameter";
            this.treeViewMasterParameter.Size = new System.Drawing.Size(329, 359);
            this.treeViewMasterParameter.TabIndex = 0;
            // 
            // checkBoxShowOnly
            // 
            this.checkBoxShowOnly.AutoSize = true;
            this.checkBoxShowOnly.Location = new System.Drawing.Point(765, 18);
            this.checkBoxShowOnly.Name = "checkBoxShowOnly";
            this.checkBoxShowOnly.Size = new System.Drawing.Size(77, 17);
            this.checkBoxShowOnly.TabIndex = 5;
            this.checkBoxShowOnly.Text = "Show Only";
            this.checkBoxShowOnly.UseVisualStyleBackColor = true;
            // 
            // dropFilterParameterSource
            // 
            this.dropFilterParameterSource.FormattingEnabled = true;
            this.dropFilterParameterSource.Location = new System.Drawing.Point(620, 14);
            this.dropFilterParameterSource.Name = "dropFilterParameterSource";
            this.dropFilterParameterSource.Size = new System.Drawing.Size(138, 21);
            this.dropFilterParameterSource.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter:";
            // 
            // btnClearValueParameter
            // 
            this.btnClearValueParameter.Location = new System.Drawing.Point(494, 14);
            this.btnClearValueParameter.Name = "btnClearValueParameter";
            this.btnClearValueParameter.Size = new System.Drawing.Size(75, 23);
            this.btnClearValueParameter.TabIndex = 2;
            this.btnClearValueParameter.Text = "Clear";
            this.btnClearValueParameter.UseVisualStyleBackColor = true;
            // 
            // txtValueSearchPamater
            // 
            this.txtValueSearchPamater.Location = new System.Drawing.Point(123, 16);
            this.txtValueSearchPamater.Name = "txtValueSearchPamater";
            this.txtValueSearchPamater.Size = new System.Drawing.Size(365, 20);
            this.txtValueSearchPamater.TabIndex = 1;
            // 
            // dropFilterParameters
            // 
            this.dropFilterParameters.FormattingEnabled = true;
            this.dropFilterParameters.Location = new System.Drawing.Point(7, 16);
            this.dropFilterParameters.Name = "dropFilterParameters";
            this.dropFilterParameters.Size = new System.Drawing.Size(109, 21);
            this.dropFilterParameters.TabIndex = 0;
            // 
            // tagLoadParameterFile
            // 
            this.tagLoadParameterFile.Location = new System.Drawing.Point(4, 22);
            this.tagLoadParameterFile.Name = "tagLoadParameterFile";
            this.tagLoadParameterFile.Padding = new System.Windows.Forms.Padding(3);
            this.tagLoadParameterFile.Size = new System.Drawing.Size(851, 493);
            this.tagLoadParameterFile.TabIndex = 1;
            this.tagLoadParameterFile.Text = "Load Shared Parameter";
            this.tagLoadParameterFile.UseVisualStyleBackColor = true;
            // 
            // frmShareParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 539);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmShareParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShareParameter";
            this.TopMost = true;
            this.tabControl1.ResumeLayout(false);
            this.TagShareParameterFile.ResumeLayout(false);
            this.TagShareParameterFile.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabPage TagShareParameterFile;
        public System.Windows.Forms.TabPage tagLoadParameterFile;
        public System.Windows.Forms.ComboBox dropFilterParameters;
        public System.Windows.Forms.TextBox txtValueSearchPamater;
        public System.Windows.Forms.Button btnClearValueParameter;
        public System.Windows.Forms.ComboBox dropFilterParameterSource;
        public System.Windows.Forms.CheckBox checkBoxShowOnly;
        public System.Windows.Forms.TextBox txtMasterPathShareParameterFile;
        public System.Windows.Forms.Button btnNewFileParamter;
        public System.Windows.Forms.Button btnFindMasterFile;
        public System.Windows.Forms.Button btnSaveParameterFile;
        public System.Windows.Forms.Button btnAddParameter;
        public System.Windows.Forms.Button btnModifyParamter;
        public System.Windows.Forms.Button btnDeleteParameter;
        public System.Windows.Forms.Button btnAddGroup;
        public System.Windows.Forms.Button btnRenameGroup;
        public System.Windows.Forms.Button btnDeleteGroup;
        public System.Windows.Forms.TextBox txtPathSourceSharedPamameter;
        public System.Windows.Forms.Button btnFindSourceParameterFile;
        public System.Windows.Forms.ComboBox dropGroupBy;
        public System.Windows.Forms.TreeView treeViewMasterParameter;
        public System.Windows.Forms.TreeView treeViewSourceParameter;
    }
}