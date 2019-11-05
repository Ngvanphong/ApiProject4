namespace ApiProject4.KeynoteManager
{
    partial class frmKeynoteManager
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
            this.dataGridViewKeynote = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDeleteKeynote = new System.Windows.Forms.Button();
            this.btnMoveKeynote = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddRowKeynote = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxSearchKeynote = new System.Windows.Forms.ComboBox();
            this.textBoxSearchKeynote = new System.Windows.Forms.TextBox();
            this.btnSearchKeynote = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dropChangeTypeKeynote = new System.Windows.Forms.ComboBox();
            this.bttEditKeynote = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeynote)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewKeynote
            // 
            this.dataGridViewKeynote.AllowDrop = true;
            this.dataGridViewKeynote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewKeynote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewKeynote.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewKeynote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeynote.Location = new System.Drawing.Point(50, 44);
            this.dataGridViewKeynote.Name = "dataGridViewKeynote";
            this.dataGridViewKeynote.Size = new System.Drawing.Size(892, 759);
            this.dataGridViewKeynote.TabIndex = 1;
            this.dataGridViewKeynote.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKeynote_CellContentClick);
            this.dataGridViewKeynote.SelectionChanged += new System.EventHandler(this.dataGridViewKeynote_SelectionChanged);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_add_tag_25;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(13, 226);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 26);
            this.button5.TabIndex = 2;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnDeleteKeynote
            // 
            this.btnDeleteKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_delete_25;
            this.btnDeleteKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeleteKeynote.FlatAppearance.BorderSize = 0;
            this.btnDeleteKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteKeynote.Location = new System.Drawing.Point(12, 119);
            this.btnDeleteKeynote.Name = "btnDeleteKeynote";
            this.btnDeleteKeynote.Size = new System.Drawing.Size(31, 26);
            this.btnDeleteKeynote.TabIndex = 2;
            this.btnDeleteKeynote.UseVisualStyleBackColor = true;
            this.btnDeleteKeynote.Click += new System.EventHandler(this.btnDeleteKeynote_Click);
            // 
            // btnMoveKeynote
            // 
            this.btnMoveKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_transfer_25;
            this.btnMoveKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMoveKeynote.FlatAppearance.BorderSize = 0;
            this.btnMoveKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveKeynote.Location = new System.Drawing.Point(12, 87);
            this.btnMoveKeynote.Name = "btnMoveKeynote";
            this.btnMoveKeynote.Size = new System.Drawing.Size(31, 26);
            this.btnMoveKeynote.TabIndex = 2;
            this.btnMoveKeynote.UseVisualStyleBackColor = true;
            this.btnMoveKeynote.Click += new System.EventHandler(this.btnMoveKeynote_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_save_as_25;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(13, 157);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 26);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddRowKeynote
            // 
            this.btnAddRowKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_add_25;
            this.btnAddRowKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddRowKeynote.FlatAppearance.BorderSize = 0;
            this.btnAddRowKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRowKeynote.Location = new System.Drawing.Point(13, 55);
            this.btnAddRowKeynote.Name = "btnAddRowKeynote";
            this.btnAddRowKeynote.Size = new System.Drawing.Size(31, 26);
            this.btnAddRowKeynote.TabIndex = 2;
            this.btnAddRowKeynote.UseVisualStyleBackColor = true;
            this.btnAddRowKeynote.Click += new System.EventHandler(this.btnAddRowKeynote_Click);
            // 
            // btn1
            // 
            this.btn1.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_collapse_25;
            this.btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Location = new System.Drawing.Point(54, 12);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(31, 26);
            this.btn1.TabIndex = 2;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_expand_25;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(91, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 26);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxSearchKeynote
            // 
            this.comboBoxSearchKeynote.FormattingEnabled = true;
            this.comboBoxSearchKeynote.Location = new System.Drawing.Point(140, 12);
            this.comboBoxSearchKeynote.Name = "comboBoxSearchKeynote";
            this.comboBoxSearchKeynote.Size = new System.Drawing.Size(132, 21);
            this.comboBoxSearchKeynote.TabIndex = 3;
            // 
            // textBoxSearchKeynote
            // 
            this.textBoxSearchKeynote.Location = new System.Drawing.Point(292, 12);
            this.textBoxSearchKeynote.Name = "textBoxSearchKeynote";
            this.textBoxSearchKeynote.Size = new System.Drawing.Size(295, 20);
            this.textBoxSearchKeynote.TabIndex = 4;
            // 
            // btnSearchKeynote
            // 
            this.btnSearchKeynote.Location = new System.Drawing.Point(593, 10);
            this.btnSearchKeynote.Name = "btnSearchKeynote";
            this.btnSearchKeynote.Size = new System.Drawing.Size(75, 23);
            this.btnSearchKeynote.TabIndex = 5;
            this.btnSearchKeynote.Text = "Search";
            this.btnSearchKeynote.UseVisualStyleBackColor = true;
            this.btnSearchKeynote.Click += new System.EventHandler(this.btnSearchKeynote_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_save_as_25;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(12, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 26);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(691, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Type:";
            // 
            // dropChangeTypeKeynote
            // 
            this.dropChangeTypeKeynote.FormattingEnabled = true;
            this.dropChangeTypeKeynote.Location = new System.Drawing.Point(731, 11);
            this.dropChangeTypeKeynote.Name = "dropChangeTypeKeynote";
            this.dropChangeTypeKeynote.Size = new System.Drawing.Size(185, 21);
            this.dropChangeTypeKeynote.TabIndex = 7;
            // 
            // bttEditKeynote
            // 
            this.bttEditKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_edit_property_25;
            this.bttEditKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bttEditKeynote.FlatAppearance.BorderSize = 0;
            this.bttEditKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttEditKeynote.Location = new System.Drawing.Point(13, 266);
            this.bttEditKeynote.Name = "bttEditKeynote";
            this.bttEditKeynote.Size = new System.Drawing.Size(31, 26);
            this.bttEditKeynote.TabIndex = 2;
            this.bttEditKeynote.UseVisualStyleBackColor = true;
            this.bttEditKeynote.Click += new System.EventHandler(this.bttEditKeynote_Click);
            // 
            // frmKeynoteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 803);
            this.Controls.Add(this.dropChangeTypeKeynote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchKeynote);
            this.Controls.Add(this.textBoxSearchKeynote);
            this.Controls.Add(this.comboBoxSearchKeynote);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.bttEditKeynote);
            this.Controls.Add(this.btnDeleteKeynote);
            this.Controls.Add(this.btnMoveKeynote);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddRowKeynote);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.dataGridViewKeynote);
            this.Name = "frmKeynoteManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKeynoteManager";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKeynoteManager_FormClosed);
            this.Load += new System.EventHandler(this.frmKeynoteManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeynote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridViewKeynote;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button btn1;
        public System.Windows.Forms.Button btnMoveKeynote;
        public System.Windows.Forms.Button btnDeleteKeynote;
        public System.Windows.Forms.Button btnAddRowKeynote;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox textBoxSearchKeynote;
        public System.Windows.Forms.Button btnSearchKeynote;
        public System.Windows.Forms.ComboBox comboBoxSearchKeynote;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox dropChangeTypeKeynote;
        public System.Windows.Forms.Button bttEditKeynote;
    }
}