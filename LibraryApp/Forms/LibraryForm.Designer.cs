namespace LibraryApp
{
    partial class LibraryForm
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
            this.editBooksButton = new System.Windows.Forms.Button();
            this.newBookButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newMagazinebutton = new System.Windows.Forms.Button();
            this.editMagazinesbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.newNewspaperbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.editNewspapersbutton = new System.Windows.Forms.Button();
            this.magazinesDataGridView = new System.Windows.Forms.DataGridView();
            this.newspapersDataGridView = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.booksDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.magazinesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newspapersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // editBooksButton
            // 
            this.editBooksButton.Location = new System.Drawing.Point(312, 73);
            this.editBooksButton.Name = "editBooksButton";
            this.editBooksButton.Size = new System.Drawing.Size(131, 40);
            this.editBooksButton.TabIndex = 2;
            this.editBooksButton.Text = "Edit";
            this.editBooksButton.UseVisualStyleBackColor = true;
            this.editBooksButton.Click += new System.EventHandler(this.editBooksButton_Click);
            // 
            // newBookButton
            // 
            this.newBookButton.Location = new System.Drawing.Point(146, 73);
            this.newBookButton.Name = "newBookButton";
            this.newBookButton.Size = new System.Drawing.Size(131, 40);
            this.newBookButton.TabIndex = 3;
            this.newBookButton.Text = "New book";
            this.newBookButton.UseVisualStyleBackColor = true;
            this.newBookButton.Click += new System.EventHandler(this.newBookButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Books";
            // 
            // newMagazinebutton
            // 
            this.newMagazinebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newMagazinebutton.Location = new System.Drawing.Point(146, 398);
            this.newMagazinebutton.Name = "newMagazinebutton";
            this.newMagazinebutton.Size = new System.Drawing.Size(131, 40);
            this.newMagazinebutton.TabIndex = 5;
            this.newMagazinebutton.Text = "New magazine";
            this.newMagazinebutton.UseVisualStyleBackColor = true;
            this.newMagazinebutton.Click += new System.EventHandler(this.newMagazineButton_Click);
            // 
            // editMagazinesbutton
            // 
            this.editMagazinesbutton.Location = new System.Drawing.Point(312, 398);
            this.editMagazinesbutton.Name = "editMagazinesbutton";
            this.editMagazinesbutton.Size = new System.Drawing.Size(131, 40);
            this.editMagazinesbutton.TabIndex = 6;
            this.editMagazinesbutton.Text = "Edit";
            this.editMagazinesbutton.UseVisualStyleBackColor = true;
            this.editMagazinesbutton.Click += new System.EventHandler(this.editMagazinesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Magazines";
            // 
            // newNewspaperbutton
            // 
            this.newNewspaperbutton.Location = new System.Drawing.Point(146, 711);
            this.newNewspaperbutton.Name = "newNewspaperbutton";
            this.newNewspaperbutton.Size = new System.Drawing.Size(131, 40);
            this.newNewspaperbutton.TabIndex = 9;
            this.newNewspaperbutton.Text = "New newspaper";
            this.newNewspaperbutton.UseVisualStyleBackColor = true;
            this.newNewspaperbutton.Click += new System.EventHandler(this.newNewspaperbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 720);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Newspapers";
            // 
            // editNewspapersbutton
            // 
            this.editNewspapersbutton.Location = new System.Drawing.Point(312, 711);
            this.editNewspapersbutton.Name = "editNewspapersbutton";
            this.editNewspapersbutton.Size = new System.Drawing.Size(131, 40);
            this.editNewspapersbutton.TabIndex = 11;
            this.editNewspapersbutton.Text = "Edit";
            this.editNewspapersbutton.UseVisualStyleBackColor = true;
            this.editNewspapersbutton.Click += new System.EventHandler(this.editNewspapersbutton_Click);
            // 
            // magazinesDataGridView
            // 
            this.magazinesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.magazinesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.magazinesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.magazinesDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.magazinesDataGridView.Location = new System.Drawing.Point(16, 444);
            this.magazinesDataGridView.Name = "magazinesDataGridView";
            this.magazinesDataGridView.ReadOnly = true;
            this.magazinesDataGridView.RowTemplate.Height = 24;
            this.magazinesDataGridView.Size = new System.Drawing.Size(1293, 239);
            this.magazinesDataGridView.TabIndex = 13;
            // 
            // newspapersDataGridView
            // 
            this.newspapersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.newspapersDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.newspapersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newspapersDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.newspapersDataGridView.Location = new System.Drawing.Point(12, 757);
            this.newspapersDataGridView.Name = "newspapersDataGridView";
            this.newspapersDataGridView.ReadOnly = true;
            this.newspapersDataGridView.RowTemplate.Height = 24;
            this.newspapersDataGridView.Size = new System.Drawing.Size(1293, 249);
            this.newspapersDataGridView.TabIndex = 14;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(810, 16);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(129, 40);
            this.searchButton.TabIndex = 15;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(532, 22);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(227, 27);
            this.searchTextBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(452, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Author:";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(765, 16);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(39, 40);
            this.backButton.TabIndex = 18;
            this.backButton.Text = "⬅";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // booksDataGridView
            // 
            this.booksDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.booksDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.booksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksDataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.booksDataGridView.Location = new System.Drawing.Point(12, 119);
            this.booksDataGridView.Name = "booksDataGridView";
            this.booksDataGridView.RowTemplate.Height = 24;
            this.booksDataGridView.Size = new System.Drawing.Size(1297, 252);
            this.booksDataGridView.TabIndex = 19;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1321, 1013);
            this.Controls.Add(this.booksDataGridView);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.newspapersDataGridView);
            this.Controls.Add(this.magazinesDataGridView);
            this.Controls.Add(this.editNewspapersbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.newNewspaperbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editMagazinesbutton);
            this.Controls.Add(this.newMagazinebutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newBookButton);
            this.Controls.Add(this.editBooksButton);
            this.Name = "LibraryForm";
            this.Text = "Library Application";
            ((System.ComponentModel.ISupportInitialize)(this.magazinesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newspapersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.booksDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editBooksButton;
        private System.Windows.Forms.Button newBookButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newMagazinebutton;
        private System.Windows.Forms.Button editMagazinesbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button newNewspaperbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button editNewspapersbutton;
        private System.Windows.Forms.DataGridView magazinesDataGridView;
        private System.Windows.Forms.DataGridView newspapersDataGridView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridView booksDataGridView;
    }
}