namespace LibraryApp
{
    partial class EditBooksForm
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
            this.deleteButton = new System.Windows.Forms.Button();
            this.booksDataGridView = new System.Windows.Forms.DataGridView();
            this.editButton = new System.Windows.Forms.Button();
            this.beckButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteButton.Location = new System.Drawing.Point(656, 542);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(182, 50);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // booksDataGridView
            // 
            this.booksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.booksDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.booksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.booksDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.booksDataGridView.Location = new System.Drawing.Point(12, 27);
            this.booksDataGridView.Name = "booksDataGridView";
            this.booksDataGridView.RowTemplate.Height = 24;
            this.booksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.booksDataGridView.Size = new System.Drawing.Size(1050, 487);
            this.booksDataGridView.TabIndex = 3;
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editButton.Location = new System.Drawing.Point(887, 542);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(175, 50);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Save changes";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // beckButton
            // 
            this.beckButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.beckButton.Location = new System.Drawing.Point(12, 543);
            this.beckButton.Name = "beckButton";
            this.beckButton.Size = new System.Drawing.Size(182, 50);
            this.beckButton.TabIndex = 5;
            this.beckButton.Text = "⬅ Back";
            this.beckButton.UseVisualStyleBackColor = true;
            this.beckButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // EditBooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 619);
            this.Controls.Add(this.beckButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.booksDataGridView);
            this.Controls.Add(this.deleteButton);
            this.Name = "EditBooksForm";
            this.Text = "Edit Books";
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView booksDataGridView;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button beckButton;
    }
}