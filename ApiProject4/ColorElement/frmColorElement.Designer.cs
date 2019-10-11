namespace ApiProject4.ColorElement
{
    partial class frmColorElement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxParameter = new System.Windows.Forms.ListBox();
            this.listBoxCategory = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewValueParameter = new System.Windows.Forms.DataGridView();
            this.btnDefaultColor = new System.Windows.Forms.Button();
            this.buttonSchamaSave = new System.Windows.Forms.Button();
            this.btnClearSetColor = new System.Windows.Forms.Button();
            this.btnLoadSchema = new System.Windows.Forms.Button();
            this.btnApplyColor = new System.Windows.Forms.Button();
            this.checkBoxAutoColor = new System.Windows.Forms.CheckBox();
            this.btnCloseAppColor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValueParameter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBoxParameter);
            this.groupBox1.Controls.Add(this.listBoxCategory);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 436);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elements";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose catelogies:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parameters:";
            // 
            // listBoxParameter
            // 
            this.listBoxParameter.FormattingEnabled = true;
            this.listBoxParameter.Location = new System.Drawing.Point(6, 177);
            this.listBoxParameter.Name = "listBoxParameter";
            this.listBoxParameter.Size = new System.Drawing.Size(236, 251);
            this.listBoxParameter.TabIndex = 0;
            this.listBoxParameter.SelectedIndexChanged += new System.EventHandler(this.listBoxParameter_SelectedIndexChanged);
            // 
            // listBoxCategory
            // 
            this.listBoxCategory.FormattingEnabled = true;
            this.listBoxCategory.Location = new System.Drawing.Point(6, 37);
            this.listBoxCategory.Name = "listBoxCategory";
            this.listBoxCategory.Size = new System.Drawing.Size(236, 121);
            this.listBoxCategory.TabIndex = 0;
            this.listBoxCategory.SelectedIndexChanged += new System.EventHandler(this.listBoxCategory_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewValueParameter);
            this.groupBox2.Location = new System.Drawing.Point(267, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 389);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Value";
            // 
            // dataGridViewValueParameter
            // 
            this.dataGridViewValueParameter.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewValueParameter.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewValueParameter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewValueParameter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewValueParameter.Location = new System.Drawing.Point(6, 16);
            this.dataGridViewValueParameter.Name = "dataGridViewValueParameter";
            this.dataGridViewValueParameter.Size = new System.Drawing.Size(236, 367);
            this.dataGridViewValueParameter.TabIndex = 0;
            this.dataGridViewValueParameter.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewValueParameter_CellDoubleClick);
            this.dataGridViewValueParameter.SelectionChanged += new System.EventHandler(this.dataGridViewValueParameter_SelectionChanged);
            // 
            // btnDefaultColor
            // 
            this.btnDefaultColor.Location = new System.Drawing.Point(442, 407);
            this.btnDefaultColor.Name = "btnDefaultColor";
            this.btnDefaultColor.Size = new System.Drawing.Size(75, 30);
            this.btnDefaultColor.TabIndex = 2;
            this.btnDefaultColor.Text = "Default";
            this.btnDefaultColor.UseVisualStyleBackColor = true;
            this.btnDefaultColor.Click += new System.EventHandler(this.btnDefaultColor_Click);
            // 
            // buttonSchamaSave
            // 
            this.buttonSchamaSave.Location = new System.Drawing.Point(267, 441);
            this.buttonSchamaSave.Name = "buttonSchamaSave";
            this.buttonSchamaSave.Size = new System.Drawing.Size(90, 30);
            this.buttonSchamaSave.TabIndex = 1;
            this.buttonSchamaSave.Text = "Save schema";
            this.buttonSchamaSave.UseVisualStyleBackColor = true;
            // 
            // btnClearSetColor
            // 
            this.btnClearSetColor.Location = new System.Drawing.Point(363, 441);
            this.btnClearSetColor.Name = "btnClearSetColor";
            this.btnClearSetColor.Size = new System.Drawing.Size(73, 30);
            this.btnClearSetColor.TabIndex = 1;
            this.btnClearSetColor.Text = "Clear set";
            this.btnClearSetColor.UseVisualStyleBackColor = true;
            this.btnClearSetColor.Click += new System.EventHandler(this.btnClearSetColor_Click);
            // 
            // btnLoadSchema
            // 
            this.btnLoadSchema.Location = new System.Drawing.Point(267, 407);
            this.btnLoadSchema.Name = "btnLoadSchema";
            this.btnLoadSchema.Size = new System.Drawing.Size(90, 30);
            this.btnLoadSchema.TabIndex = 1;
            this.btnLoadSchema.Text = "Load schema";
            this.btnLoadSchema.UseVisualStyleBackColor = true;
            // 
            // btnApplyColor
            // 
            this.btnApplyColor.Location = new System.Drawing.Point(363, 407);
            this.btnApplyColor.Name = "btnApplyColor";
            this.btnApplyColor.Size = new System.Drawing.Size(73, 30);
            this.btnApplyColor.TabIndex = 1;
            this.btnApplyColor.Text = "Apply color";
            this.btnApplyColor.UseVisualStyleBackColor = true;
            this.btnApplyColor.Click += new System.EventHandler(this.btnApplyColor_Click);
            // 
            // checkBoxAutoColor
            // 
            this.checkBoxAutoColor.AutoSize = true;
            this.checkBoxAutoColor.Location = new System.Drawing.Point(18, 454);
            this.checkBoxAutoColor.Name = "checkBoxAutoColor";
            this.checkBoxAutoColor.Size = new System.Drawing.Size(181, 17);
            this.checkBoxAutoColor.TabIndex = 3;
            this.checkBoxAutoColor.Text = "Auto apply color when is drawing";
            this.checkBoxAutoColor.UseVisualStyleBackColor = true;
            this.checkBoxAutoColor.CheckedChanged += new System.EventHandler(this.checkBoxAutoColor_CheckedChanged);
            // 
            // btnCloseAppColor
            // 
            this.btnCloseAppColor.Location = new System.Drawing.Point(443, 441);
            this.btnCloseAppColor.Name = "btnCloseAppColor";
            this.btnCloseAppColor.Size = new System.Drawing.Size(73, 30);
            this.btnCloseAppColor.TabIndex = 1;
            this.btnCloseAppColor.Text = "Close";
            this.btnCloseAppColor.UseVisualStyleBackColor = true;
            this.btnCloseAppColor.Click += new System.EventHandler(this.btnCloseAppColor_Click);
            // 
            // frmColorElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 482);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxAutoColor);
            this.Controls.Add(this.btnDefaultColor);
            this.Controls.Add(this.btnLoadSchema);
            this.Controls.Add(this.btnApplyColor);
            this.Controls.Add(this.btnCloseAppColor);
            this.Controls.Add(this.btnClearSetColor);
            this.Controls.Add(this.buttonSchamaSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmColorElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmColorElement";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmColorElement_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValueParameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ListBox listBoxCategory;
        public System.Windows.Forms.ListBox listBoxParameter;
        public System.Windows.Forms.DataGridView dataGridViewValueParameter;
        public System.Windows.Forms.Button buttonSchamaSave;
        public System.Windows.Forms.Button btnLoadSchema;
        public System.Windows.Forms.Button btnDefaultColor;
        public System.Windows.Forms.Button btnApplyColor;
        public System.Windows.Forms.Button btnClearSetColor;
        public System.Windows.Forms.CheckBox checkBoxAutoColor;
        public System.Windows.Forms.Button btnCloseAppColor;
    }
}