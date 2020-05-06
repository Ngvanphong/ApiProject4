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
            this.btnAssignSourceToMaster = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHideSource = new System.Windows.Forms.Button();
            this.btnAutoMergePara = new System.Windows.Forms.Button();
            this.btnShowSource = new System.Windows.Forms.Button();
            this.treeViewSourceParameter = new System.Windows.Forms.TreeView();
            this.txtPathSourceSharedPamameter = new System.Windows.Forms.TextBox();
            this.btnFindSourceParameterFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHideMaster = new System.Windows.Forms.Button();
            this.btnShowMaster = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteParameter = new System.Windows.Forms.Button();
            this.btnModifyParamter = new System.Windows.Forms.Button();
            this.btnAddParameter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnRenameGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnFindMasterFile = new System.Windows.Forms.Button();
            this.btnNewFileParamter = new System.Windows.Forms.Button();
            this.txtMasterPathShareParameterFile = new System.Windows.Forms.TextBox();
            this.treeViewMasterParameter = new System.Windows.Forms.TreeView();
            this.dropFilterParameterSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchValueParameter = new System.Windows.Forms.Button();
            this.txtValueSearchPamater = new System.Windows.Forms.TextBox();
            this.dropSearchParameters = new System.Windows.Forms.ComboBox();
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
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.TagShareParameterFile);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 519);
            this.tabControl1.TabIndex = 0;
            // 
            // TagShareParameterFile
            // 
            this.TagShareParameterFile.Controls.Add(this.btnAssignSourceToMaster);
            this.TagShareParameterFile.Controls.Add(this.groupBox2);
            this.TagShareParameterFile.Controls.Add(this.groupBox1);
            this.TagShareParameterFile.Controls.Add(this.dropFilterParameterSource);
            this.TagShareParameterFile.Controls.Add(this.label1);
            this.TagShareParameterFile.Controls.Add(this.btnSearchValueParameter);
            this.TagShareParameterFile.Controls.Add(this.txtValueSearchPamater);
            this.TagShareParameterFile.Controls.Add(this.dropSearchParameters);
            this.TagShareParameterFile.Location = new System.Drawing.Point(4, 22);
            this.TagShareParameterFile.Name = "TagShareParameterFile";
            this.TagShareParameterFile.Padding = new System.Windows.Forms.Padding(3);
            this.TagShareParameterFile.Size = new System.Drawing.Size(851, 493);
            this.TagShareParameterFile.TabIndex = 0;
            this.TagShareParameterFile.Text = "Shared Parameter File";
            this.TagShareParameterFile.UseVisualStyleBackColor = true;
            // 
            // btnAssignSourceToMaster
            // 
            this.btnAssignSourceToMaster.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAssignSourceToMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAssignSourceToMaster.Location = new System.Drawing.Point(465, 94);
            this.btnAssignSourceToMaster.Name = "btnAssignSourceToMaster";
            this.btnAssignSourceToMaster.Size = new System.Drawing.Size(38, 21);
            this.btnAssignSourceToMaster.TabIndex = 7;
            this.btnAssignSourceToMaster.Text = "<<";
            this.btnAssignSourceToMaster.UseVisualStyleBackColor = false;
            this.btnAssignSourceToMaster.Click += new System.EventHandler(this.btnAssignSourceToMaster_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnHideSource);
            this.groupBox2.Controls.Add(this.btnAutoMergePara);
            this.groupBox2.Controls.Add(this.btnShowSource);
            this.groupBox2.Controls.Add(this.treeViewSourceParameter);
            this.groupBox2.Controls.Add(this.txtPathSourceSharedPamameter);
            this.groupBox2.Controls.Add(this.btnFindSourceParameterFile);
            this.groupBox2.Location = new System.Drawing.Point(509, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 443);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Source Shared Parameter File";
            // 
            // btnHideSource
            // 
            this.btnHideSource.BackColor = System.Drawing.Color.White;
            this.btnHideSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHideSource.Location = new System.Drawing.Point(234, 51);
            this.btnHideSource.Name = "btnHideSource";
            this.btnHideSource.Size = new System.Drawing.Size(45, 20);
            this.btnHideSource.TabIndex = 7;
            this.btnHideSource.Text = "Hide";
            this.btnHideSource.UseVisualStyleBackColor = false;
            this.btnHideSource.Click += new System.EventHandler(this.btnHideSource_Click);
            // 
            // btnAutoMergePara
            // 
            this.btnAutoMergePara.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnAutoMergePara.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAutoMergePara.Location = new System.Drawing.Point(111, 47);
            this.btnAutoMergePara.Name = "btnAutoMergePara";
            this.btnAutoMergePara.Size = new System.Drawing.Size(75, 23);
            this.btnAutoMergePara.TabIndex = 7;
            this.btnAutoMergePara.Text = "Auto Merge";
            this.btnAutoMergePara.UseVisualStyleBackColor = false;
            this.btnAutoMergePara.Click += new System.EventHandler(this.btnAutoMergePara_Click);
            // 
            // btnShowSource
            // 
            this.btnShowSource.BackColor = System.Drawing.Color.White;
            this.btnShowSource.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowSource.Location = new System.Drawing.Point(285, 51);
            this.btnShowSource.Name = "btnShowSource";
            this.btnShowSource.Size = new System.Drawing.Size(45, 20);
            this.btnShowSource.TabIndex = 7;
            this.btnShowSource.Text = "Show";
            this.btnShowSource.UseVisualStyleBackColor = false;
            this.btnShowSource.Click += new System.EventHandler(this.btnShowSource_Click);
            // 
            // treeViewSourceParameter
            // 
            this.treeViewSourceParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewSourceParameter.CheckBoxes = true;
            this.treeViewSourceParameter.Location = new System.Drawing.Point(7, 78);
            this.treeViewSourceParameter.Name = "treeViewSourceParameter";
            this.treeViewSourceParameter.Size = new System.Drawing.Size(323, 359);
            this.treeViewSourceParameter.TabIndex = 5;
            this.treeViewSourceParameter.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSourceParameter_AfterCheck);
            // 
            // txtPathSourceSharedPamameter
            // 
            this.txtPathSourceSharedPamameter.Location = new System.Drawing.Point(6, 21);
            this.txtPathSourceSharedPamameter.Name = "txtPathSourceSharedPamameter";
            this.txtPathSourceSharedPamameter.Size = new System.Drawing.Size(243, 20);
            this.txtPathSourceSharedPamameter.TabIndex = 1;
            // 
            // btnFindSourceParameterFile
            // 
            this.btnFindSourceParameterFile.Location = new System.Drawing.Point(255, 19);
            this.btnFindSourceParameterFile.Name = "btnFindSourceParameterFile";
            this.btnFindSourceParameterFile.Size = new System.Drawing.Size(75, 23);
            this.btnFindSourceParameterFile.TabIndex = 2;
            this.btnFindSourceParameterFile.Text = "Browse...";
            this.btnFindSourceParameterFile.UseVisualStyleBackColor = true;
            this.btnFindSourceParameterFile.Click += new System.EventHandler(this.btnFindSourceParameterFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnHideMaster);
            this.groupBox1.Controls.Add(this.btnShowMaster);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnFindMasterFile);
            this.groupBox1.Controls.Add(this.btnNewFileParamter);
            this.groupBox1.Controls.Add(this.txtMasterPathShareParameterFile);
            this.groupBox1.Controls.Add(this.treeViewMasterParameter);
            this.groupBox1.Location = new System.Drawing.Point(7, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 444);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manager Shared Parameter File";
            // 
            // btnHideMaster
            // 
            this.btnHideMaster.BackColor = System.Drawing.Color.White;
            this.btnHideMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHideMaster.Location = new System.Drawing.Point(234, 53);
            this.btnHideMaster.Name = "btnHideMaster";
            this.btnHideMaster.Size = new System.Drawing.Size(45, 20);
            this.btnHideMaster.TabIndex = 7;
            this.btnHideMaster.Text = "Hide";
            this.btnHideMaster.UseVisualStyleBackColor = false;
            this.btnHideMaster.Click += new System.EventHandler(this.btnHideMaster_Click);
            // 
            // btnShowMaster
            // 
            this.btnShowMaster.BackColor = System.Drawing.Color.White;
            this.btnShowMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnShowMaster.Location = new System.Drawing.Point(285, 53);
            this.btnShowMaster.Name = "btnShowMaster";
            this.btnShowMaster.Size = new System.Drawing.Size(45, 20);
            this.btnShowMaster.TabIndex = 7;
            this.btnShowMaster.Text = "Show";
            this.btnShowMaster.UseVisualStyleBackColor = false;
            this.btnShowMaster.Click += new System.EventHandler(this.btnShowMaster_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteParameter);
            this.groupBox4.Controls.Add(this.btnModifyParamter);
            this.groupBox4.Controls.Add(this.btnAddParameter);
            this.groupBox4.Location = new System.Drawing.Point(336, 79);
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
            this.btnDeleteParameter.Click += new System.EventHandler(this.btnDeleteParameter_Click);
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
            this.groupBox3.Location = new System.Drawing.Point(336, 202);
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
            // btnFindMasterFile
            // 
            this.btnFindMasterFile.Location = new System.Drawing.Point(369, 19);
            this.btnFindMasterFile.Name = "btnFindMasterFile";
            this.btnFindMasterFile.Size = new System.Drawing.Size(75, 23);
            this.btnFindMasterFile.TabIndex = 3;
            this.btnFindMasterFile.Text = "Browse...";
            this.btnFindMasterFile.UseVisualStyleBackColor = true;
            this.btnFindMasterFile.Click += new System.EventHandler(this.btnFindMasterFile_Click);
            // 
            // btnNewFileParamter
            // 
            this.btnNewFileParamter.Location = new System.Drawing.Point(288, 19);
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
            this.txtMasterPathShareParameterFile.Size = new System.Drawing.Size(272, 20);
            this.txtMasterPathShareParameterFile.TabIndex = 1;
            // 
            // treeViewMasterParameter
            // 
            this.treeViewMasterParameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewMasterParameter.Location = new System.Drawing.Point(7, 79);
            this.treeViewMasterParameter.Name = "treeViewMasterParameter";
            this.treeViewMasterParameter.Size = new System.Drawing.Size(323, 359);
            this.treeViewMasterParameter.TabIndex = 0;
            this.treeViewMasterParameter.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMasterParameter_AfterSelect);
            // 
            // dropFilterParameterSource
            // 
            this.dropFilterParameterSource.FormattingEnabled = true;
            this.dropFilterParameterSource.Location = new System.Drawing.Point(620, 14);
            this.dropFilterParameterSource.Name = "dropFilterParameterSource";
            this.dropFilterParameterSource.Size = new System.Drawing.Size(219, 21);
            this.dropFilterParameterSource.TabIndex = 4;
            this.dropFilterParameterSource.SelectedIndexChanged += new System.EventHandler(this.dropFilterParameterSource_SelectedIndexChanged);
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
            // btnSearchValueParameter
            // 
            this.btnSearchValueParameter.Location = new System.Drawing.Point(494, 14);
            this.btnSearchValueParameter.Name = "btnSearchValueParameter";
            this.btnSearchValueParameter.Size = new System.Drawing.Size(75, 23);
            this.btnSearchValueParameter.TabIndex = 2;
            this.btnSearchValueParameter.Text = "Search";
            this.btnSearchValueParameter.UseVisualStyleBackColor = true;
            this.btnSearchValueParameter.Click += new System.EventHandler(this.btnSearchValueParameter_Click);
            // 
            // txtValueSearchPamater
            // 
            this.txtValueSearchPamater.Location = new System.Drawing.Point(123, 16);
            this.txtValueSearchPamater.Name = "txtValueSearchPamater";
            this.txtValueSearchPamater.Size = new System.Drawing.Size(365, 20);
            this.txtValueSearchPamater.TabIndex = 1;
            // 
            // dropSearchParameters
            // 
            this.dropSearchParameters.FormattingEnabled = true;
            this.dropSearchParameters.Location = new System.Drawing.Point(8, 16);
            this.dropSearchParameters.Name = "dropSearchParameters";
            this.dropSearchParameters.Size = new System.Drawing.Size(109, 21);
            this.dropSearchParameters.TabIndex = 0;
            // 
            // frmShareParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 539);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "frmShareParameter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShareParameter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmShareParameter_Load);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TabPage TagShareParameterFile;
        public System.Windows.Forms.ComboBox dropSearchParameters;
        public System.Windows.Forms.TextBox txtValueSearchPamater;
        public System.Windows.Forms.Button btnSearchValueParameter;
        public System.Windows.Forms.ComboBox dropFilterParameterSource;
        public System.Windows.Forms.TextBox txtMasterPathShareParameterFile;
        public System.Windows.Forms.Button btnNewFileParamter;
        public System.Windows.Forms.Button btnFindMasterFile;
        public System.Windows.Forms.Button btnAddParameter;
        public System.Windows.Forms.Button btnModifyParamter;
        public System.Windows.Forms.Button btnDeleteParameter;
        public System.Windows.Forms.Button btnAddGroup;
        public System.Windows.Forms.Button btnRenameGroup;
        public System.Windows.Forms.Button btnDeleteGroup;
        public System.Windows.Forms.TextBox txtPathSourceSharedPamameter;
        public System.Windows.Forms.Button btnFindSourceParameterFile;
        public System.Windows.Forms.TreeView treeViewMasterParameter;
        public System.Windows.Forms.TreeView treeViewSourceParameter;
        public System.Windows.Forms.Button btnAssignSourceToMaster;
        public System.Windows.Forms.Button btnAutoMergePara;
        public System.Windows.Forms.Button btnShowMaster;
        public System.Windows.Forms.Button btnHideSource;
        public System.Windows.Forms.Button btnShowSource;
        public System.Windows.Forms.Button btnHideMaster;
    }
}