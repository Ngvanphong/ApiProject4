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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewKeynote = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.btnDeleteKeynote = new System.Windows.Forms.Button();
            this.btnMoveKeynote = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddRowKeynote = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeynote)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1080, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.toolStripMenuItem1.Text = "Fille";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // dataGridViewKeynote
            // 
            this.dataGridViewKeynote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewKeynote.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewKeynote.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewKeynote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeynote.Location = new System.Drawing.Point(50, 62);
            this.dataGridViewKeynote.Name = "dataGridViewKeynote";
            this.dataGridViewKeynote.Size = new System.Drawing.Size(1030, 655);
            this.dataGridViewKeynote.TabIndex = 1;
            this.dataGridViewKeynote.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKeynote_CellContentClick);
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_add_tag_25;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(12, 243);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(31, 26);
            this.button5.TabIndex = 2;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnDeleteKeynote
            // 
            this.btnDeleteKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_delete_25;
            this.btnDeleteKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDeleteKeynote.FlatAppearance.BorderSize = 0;
            this.btnDeleteKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteKeynote.Location = new System.Drawing.Point(12, 140);
            this.btnDeleteKeynote.Name = "btnDeleteKeynote";
            this.btnDeleteKeynote.Size = new System.Drawing.Size(31, 26);
            this.btnDeleteKeynote.TabIndex = 2;
            this.btnDeleteKeynote.UseVisualStyleBackColor = true;
            // 
            // btnMoveKeynote
            // 
            this.btnMoveKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_transfer_25;
            this.btnMoveKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMoveKeynote.FlatAppearance.BorderSize = 0;
            this.btnMoveKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveKeynote.Location = new System.Drawing.Point(12, 108);
            this.btnMoveKeynote.Name = "btnMoveKeynote";
            this.btnMoveKeynote.Size = new System.Drawing.Size(31, 26);
            this.btnMoveKeynote.TabIndex = 2;
            this.btnMoveKeynote.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_save_as_25;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(12, 204);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 26);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAddRowKeynote
            // 
            this.btnAddRowKeynote.BackgroundImage = global::ApiProject4.Properties.Resources.icons8_add_25;
            this.btnAddRowKeynote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddRowKeynote.FlatAppearance.BorderSize = 0;
            this.btnAddRowKeynote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRowKeynote.Location = new System.Drawing.Point(13, 76);
            this.btnAddRowKeynote.Name = "btnAddRowKeynote";
            this.btnAddRowKeynote.Size = new System.Drawing.Size(31, 26);
            this.btnAddRowKeynote.TabIndex = 2;
            this.btnAddRowKeynote.UseVisualStyleBackColor = true;
            // 
            // frmKeynoteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 717);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnDeleteKeynote);
            this.Controls.Add(this.btnMoveKeynote);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddRowKeynote);
            this.Controls.Add(this.dataGridViewKeynote);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmKeynoteManager";
            this.Text = "frmKeynoteManager";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmKeynoteManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeynote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridViewKeynote;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button btnAddRowKeynote;
        public System.Windows.Forms.Button btnMoveKeynote;
        public System.Windows.Forms.Button btnDeleteKeynote;
    }
}