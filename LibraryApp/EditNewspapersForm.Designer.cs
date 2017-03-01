namespace LibraryApp
{
    partial class EditNewspapersForm
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
            this.deleteNewspaperbutton = new System.Windows.Forms.Button();
            this.editNewspaperbutton = new System.Windows.Forms.Button();
            this.newspapersDataGridView = new System.Windows.Forms.DataGridView();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.newspapersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteNewspaperbutton
            // 
            this.deleteNewspaperbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteNewspaperbutton.Location = new System.Drawing.Point(715, 525);
            this.deleteNewspaperbutton.Name = "deleteNewspaperbutton";
            this.deleteNewspaperbutton.Size = new System.Drawing.Size(169, 46);
            this.deleteNewspaperbutton.TabIndex = 0;
            this.deleteNewspaperbutton.Text = "Delete";
            this.deleteNewspaperbutton.UseVisualStyleBackColor = true;
            this.deleteNewspaperbutton.Click += new System.EventHandler(this.deleteNewspaperbutton_Click);
            // 
            // editNewspaperbutton
            // 
            this.editNewspaperbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editNewspaperbutton.Location = new System.Drawing.Point(944, 525);
            this.editNewspaperbutton.Name = "editNewspaperbutton";
            this.editNewspaperbutton.Size = new System.Drawing.Size(169, 46);
            this.editNewspaperbutton.TabIndex = 1;
            this.editNewspaperbutton.Text = "Edit";
            this.editNewspaperbutton.UseVisualStyleBackColor = true;
            this.editNewspaperbutton.Click += new System.EventHandler(this.editNewspaperbutton_Click);
            // 
            // newspapersDataGridView
            // 
            this.newspapersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.newspapersDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.newspapersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newspapersDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.newspapersDataGridView.Location = new System.Drawing.Point(12, 26);
            this.newspapersDataGridView.Name = "newspapersDataGridView";
            this.newspapersDataGridView.RowTemplate.Height = 24;
            this.newspapersDataGridView.Size = new System.Drawing.Size(1101, 476);
            this.newspapersDataGridView.TabIndex = 2;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(12, 525);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(168, 46);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "⬅ Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // EditNewspapersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 583);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.newspapersDataGridView);
            this.Controls.Add(this.editNewspaperbutton);
            this.Controls.Add(this.deleteNewspaperbutton);
            this.Name = "EditNewspapersForm";
            this.Text = "Edit Newspapers";
            this.Load += new System.EventHandler(this.EditNewspapersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newspapersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteNewspaperbutton;
        private System.Windows.Forms.Button editNewspaperbutton;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView newspapersDataGridView;
        private System.Windows.Forms.Button backButton;
    }
}