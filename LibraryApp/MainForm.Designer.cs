namespace LibraryApp
{
    partial class MainForm
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
            this.ShowAllLibraryBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ShowAllLibraryBox
            // 
            this.ShowAllLibraryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowAllLibraryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShowAllLibraryBox.Font = new System.Drawing.Font("Helvetica-Normal", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowAllLibraryBox.Location = new System.Drawing.Point(24, 27);
            this.ShowAllLibraryBox.Multiline = true;
            this.ShowAllLibraryBox.Name = "ShowAllLibraryBox";
            this.ShowAllLibraryBox.ReadOnly = true;
            this.ShowAllLibraryBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ShowAllLibraryBox.Size = new System.Drawing.Size(640, 649);
            this.ShowAllLibraryBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 704);
            this.Controls.Add(this.ShowAllLibraryBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox ShowAllLibraryBox;
    }
}