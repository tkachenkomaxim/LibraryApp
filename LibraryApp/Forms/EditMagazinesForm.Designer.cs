namespace LibraryApp
{
    partial class EditMagazinesForm
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
            this.EditMagazinebutton = new System.Windows.Forms.Button();
            this.deleteMagazinebutton = new System.Windows.Forms.Button();
            this.magazinesDataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.magazinesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditMagazinebutton
            // 
            this.EditMagazinebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditMagazinebutton.Location = new System.Drawing.Point(885, 478);
            this.EditMagazinebutton.Name = "EditMagazinebutton";
            this.EditMagazinebutton.Size = new System.Drawing.Size(172, 46);
            this.EditMagazinebutton.TabIndex = 0;
            this.EditMagazinebutton.Text = "Save changes";
            this.EditMagazinebutton.UseVisualStyleBackColor = true;
            this.EditMagazinebutton.Click += new System.EventHandler(this.EditMagazinebutton_Click);
            // 
            // deleteMagazinebutton
            // 
            this.deleteMagazinebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteMagazinebutton.Location = new System.Drawing.Point(655, 478);
            this.deleteMagazinebutton.Name = "deleteMagazinebutton";
            this.deleteMagazinebutton.Size = new System.Drawing.Size(172, 46);
            this.deleteMagazinebutton.TabIndex = 1;
            this.deleteMagazinebutton.Text = "Delete";
            this.deleteMagazinebutton.UseVisualStyleBackColor = true;
            this.deleteMagazinebutton.Click += new System.EventHandler(this.deleteMagazinebutton_Click);
            // 
            // magazinesDataGridView
            // 
            this.magazinesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.magazinesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.magazinesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.magazinesDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.magazinesDataGridView.Location = new System.Drawing.Point(12, 29);
            this.magazinesDataGridView.Name = "magazinesDataGridView";
            this.magazinesDataGridView.RowTemplate.Height = 24;
            this.magazinesDataGridView.Size = new System.Drawing.Size(1045, 434);
            this.magazinesDataGridView.TabIndex = 2;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(12, 478);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(172, 46);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "⬅ Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // EditMagazinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 545);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.magazinesDataGridView);
            this.Controls.Add(this.deleteMagazinebutton);
            this.Controls.Add(this.EditMagazinebutton);
            this.Name = "EditMagazinesForm";
            this.Text = "Edit Magazines";
            ((System.ComponentModel.ISupportInitialize)(this.magazinesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditMagazinebutton;
        private System.Windows.Forms.Button deleteMagazinebutton;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView magazinesDataGridView;
        private System.Windows.Forms.Button backButton;
    }
}