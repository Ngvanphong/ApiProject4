namespace ApiProject4.KeynoteManager
{
    partial class frmMoveKeynote
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
            this.textBoxIdKeynote = new System.Windows.Forms.TextBox();
            this.btnKeynoteMoveBinding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id of keynote group:";
            // 
            // textBoxIdKeynote
            // 
            this.textBoxIdKeynote.Location = new System.Drawing.Point(118, 12);
            this.textBoxIdKeynote.Name = "textBoxIdKeynote";
            this.textBoxIdKeynote.Size = new System.Drawing.Size(288, 20);
            this.textBoxIdKeynote.TabIndex = 1;
            // 
            // btnKeynoteMoveBinding
            // 
            this.btnKeynoteMoveBinding.Location = new System.Drawing.Point(331, 38);
            this.btnKeynoteMoveBinding.Name = "btnKeynoteMoveBinding";
            this.btnKeynoteMoveBinding.Size = new System.Drawing.Size(75, 23);
            this.btnKeynoteMoveBinding.TabIndex = 2;
            this.btnKeynoteMoveBinding.Text = "OK";
            this.btnKeynoteMoveBinding.UseVisualStyleBackColor = true;
            this.btnKeynoteMoveBinding.Click += new System.EventHandler(this.btnKeynoteMoveBinding_Click);
            // 
            // frmMoveKeynote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 71);
            this.Controls.Add(this.btnKeynoteMoveBinding);
            this.Controls.Add(this.textBoxIdKeynote);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMoveKeynote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMoveKeynote";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMoveKeynote_FormClosed);
            this.Load += new System.EventHandler(this.frmMoveKeynote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIdKeynote;
        public System.Windows.Forms.Button btnKeynoteMoveBinding;
    }
}