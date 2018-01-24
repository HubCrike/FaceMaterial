namespace FaceMaterial {
    partial class IconTextBox {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.FaceIconBaseTextBox = new FaceMaterial.UI.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.IconBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconBox.Location = new System.Drawing.Point(0, 0);
            this.IconBox.Name = "pictureBox1";
            this.IconBox.Size = new System.Drawing.Size(28, 27);
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            // 
            // textBox1
            // 
            this.FaceIconBaseTextBox.AutoScaleByText = false;
            this.FaceIconBaseTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.FaceIconBaseTextBox.WaterMark = "Watermark";
            this.FaceIconBaseTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FaceIconBaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaceIconBaseTextBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.FaceIconBaseTextBox.Text = null;
            this.FaceIconBaseTextBox.LineColor = System.Drawing.Color.DodgerBlue;
            this.FaceIconBaseTextBox.LineHeight = 2;
            this.FaceIconBaseTextBox.LineMarginHorizontal = -1;
            this.FaceIconBaseTextBox.LineMarginLeft = 0;
            this.FaceIconBaseTextBox.LineMarginRight = 0;
            this.FaceIconBaseTextBox.LineMarginToText = 1;
            this.FaceIconBaseTextBox.Location = new System.Drawing.Point(28, 0);
            this.FaceIconBaseTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FaceIconBaseTextBox.Multiline = false;
            this.FaceIconBaseTextBox.Name = "textBox1";
            this.FaceIconBaseTextBox.Padding = new System.Windows.Forms.Padding(2, 0, 0, 3);
            this.FaceIconBaseTextBox.PasswortChar = '\0';
            this.FaceIconBaseTextBox.Size = new System.Drawing.Size(213, 27);
            this.FaceIconBaseTextBox.TabIndex = 1;
            this.FaceIconBaseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.FaceIconBaseTextBox.UseSystemPasswordChar = false;
            // 
            // IconTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.FaceIconBaseTextBox);
            this.Controls.Add(this.IconBox);
            this.Name = "IconTextBox";
            this.Size = new System.Drawing.Size(241, 27);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private UI.TextBox FaceIconBaseTextBox;
    }
}
