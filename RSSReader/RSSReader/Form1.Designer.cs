
namespace RSSReader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FrequencyComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.URLLabel = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.UppdateFrequencyLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.NewPodButton = new System.Windows.Forms.Button();
            this.SavePodButton = new System.Windows.Forms.Button();
            this.DeletePodButton = new System.Windows.Forms.Button();
            this.PlaceholderPod = new System.Windows.Forms.ListBox();
            this.PlaceholderCategory = new System.Windows.Forms.ListBox();
            this.CategoryListLabel = new System.Windows.Forms.Label();
            this.CreateCategoryTextBox = new System.Windows.Forms.TextBox();
            this.CreateCategoryLabel = new System.Windows.Forms.Label();
            this.NewCategoryButton = new System.Windows.Forms.Button();
            this.SaveCategoryButton = new System.Windows.Forms.Button();
            this.DeleteCategoryButton = new System.Windows.Forms.Button();
            this.episodeDescriptionLabel = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // FrequencyComboBox
            // 
            this.FrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FrequencyComboBox.FormattingEnabled = true;
            this.FrequencyComboBox.Items.AddRange(new object[] {
            "15 minutes",
            "30 minutes",
            "1 hour"});
            this.FrequencyComboBox.Location = new System.Drawing.Point(219, 179);
            this.FrequencyComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FrequencyComboBox.Name = "FrequencyComboBox";
            this.FrequencyComboBox.Size = new System.Drawing.Size(103, 23);
            this.FrequencyComboBox.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(10, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(546, 141);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // URLLabel
            // 
            this.URLLabel.AutoSize = true;
            this.URLLabel.Location = new System.Drawing.Point(19, 161);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(31, 15);
            this.URLLabel.TabIndex = 1;
            this.URLLabel.Text = "URL:";
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(19, 179);
            this.URLTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.PlaceholderText = "http;//.....";
            this.URLTextBox.Size = new System.Drawing.Size(184, 23);
            this.URLTextBox.TabIndex = 2;
            // 
            // UppdateFrequencyLabel
            // 
            this.UppdateFrequencyLabel.AutoSize = true;
            this.UppdateFrequencyLabel.Location = new System.Drawing.Point(219, 161);
            this.UppdateFrequencyLabel.Name = "UppdateFrequencyLabel";
            this.UppdateFrequencyLabel.Size = new System.Drawing.Size(103, 15);
            this.UppdateFrequencyLabel.TabIndex = 3;
            this.UppdateFrequencyLabel.Text = "Update Frequency";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(345, 161);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(55, 15);
            this.CategoryLabel.TabIndex = 5;
            this.CategoryLabel.Text = "Category";
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(345, 179);
            this.CategoryComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(82, 23);
            this.CategoryComboBox.TabIndex = 6;
            // 
            // NewPodButton
            // 
            this.NewPodButton.Location = new System.Drawing.Point(250, 206);
            this.NewPodButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewPodButton.Name = "NewPodButton";
            this.NewPodButton.Size = new System.Drawing.Size(82, 22);
            this.NewPodButton.TabIndex = 7;
            this.NewPodButton.Text = "New";
            this.NewPodButton.UseVisualStyleBackColor = true;
            this.NewPodButton.Click += new System.EventHandler(this.NewPodButton_Click);
            // 
            // SavePodButton
            // 
            this.SavePodButton.Location = new System.Drawing.Point(345, 206);
            this.SavePodButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SavePodButton.Name = "SavePodButton";
            this.SavePodButton.Size = new System.Drawing.Size(82, 22);
            this.SavePodButton.TabIndex = 8;
            this.SavePodButton.Text = "Save";
            this.SavePodButton.UseVisualStyleBackColor = true;
            this.SavePodButton.Click += new System.EventHandler(this.SavePodButton_Click);
            // 
            // DeletePodButton
            // 
            this.DeletePodButton.Location = new System.Drawing.Point(441, 206);
            this.DeletePodButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeletePodButton.Name = "DeletePodButton";
            this.DeletePodButton.Size = new System.Drawing.Size(82, 22);
            this.DeletePodButton.TabIndex = 9;
            this.DeletePodButton.Text = "Delete";
            this.DeletePodButton.UseVisualStyleBackColor = true;
            this.DeletePodButton.Click += new System.EventHandler(this.DeletePodButton_Click);
            // 
            // PlaceholderPod
            // 
            this.PlaceholderPod.FormattingEnabled = true;
            this.PlaceholderPod.ItemHeight = 15;
            this.PlaceholderPod.Location = new System.Drawing.Point(10, 256);
            this.PlaceholderPod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlaceholderPod.Name = "PlaceholderPod";
            this.PlaceholderPod.Size = new System.Drawing.Size(546, 124);
            this.PlaceholderPod.TabIndex = 10;
            this.PlaceholderPod.Click += new System.EventHandler(this.PlaceholderPod_Click);
            // 
            // PlaceholderCategory
            // 
            this.PlaceholderCategory.FormattingEnabled = true;
            this.PlaceholderCategory.ItemHeight = 15;
            this.PlaceholderCategory.Location = new System.Drawing.Point(577, 27);
            this.PlaceholderCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlaceholderCategory.Name = "PlaceholderCategory";
            this.PlaceholderCategory.Size = new System.Drawing.Size(408, 124);
            this.PlaceholderCategory.TabIndex = 11;
            this.PlaceholderCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PlaceholderCategory_MouseDoubleClick);
            // 
            // CategoryListLabel
            // 
            this.CategoryListLabel.AutoSize = true;
            this.CategoryListLabel.Location = new System.Drawing.Point(577, 7);
            this.CategoryListLabel.Name = "CategoryListLabel";
            this.CategoryListLabel.Size = new System.Drawing.Size(66, 15);
            this.CategoryListLabel.TabIndex = 12;
            this.CategoryListLabel.Text = "Categories:";
            // 
            // CreateCategoryTextBox
            // 
            this.CreateCategoryTextBox.Location = new System.Drawing.Point(577, 178);
            this.CreateCategoryTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateCategoryTextBox.Name = "CreateCategoryTextBox";
            this.CreateCategoryTextBox.PlaceholderText = "Name here...";
            this.CreateCategoryTextBox.Size = new System.Drawing.Size(408, 23);
            this.CreateCategoryTextBox.TabIndex = 13;
            // 
            // CreateCategoryLabel
            // 
            this.CreateCategoryLabel.AutoSize = true;
            this.CreateCategoryLabel.Location = new System.Drawing.Point(577, 161);
            this.CreateCategoryLabel.Name = "CreateCategoryLabel";
            this.CreateCategoryLabel.Size = new System.Drawing.Size(92, 15);
            this.CreateCategoryLabel.TabIndex = 14;
            this.CreateCategoryLabel.Text = "Create Category";
            // 
            // NewCategoryButton
            // 
            this.NewCategoryButton.Location = new System.Drawing.Point(577, 206);
            this.NewCategoryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewCategoryButton.Name = "NewCategoryButton";
            this.NewCategoryButton.Size = new System.Drawing.Size(82, 22);
            this.NewCategoryButton.TabIndex = 15;
            this.NewCategoryButton.Text = "New";
            this.NewCategoryButton.UseVisualStyleBackColor = true;
            this.NewCategoryButton.Click += new System.EventHandler(this.NewCategoryButton_Click);
            // 
            // SaveCategoryButton
            // 
            this.SaveCategoryButton.Location = new System.Drawing.Point(672, 206);
            this.SaveCategoryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveCategoryButton.Name = "SaveCategoryButton";
            this.SaveCategoryButton.Size = new System.Drawing.Size(82, 22);
            this.SaveCategoryButton.TabIndex = 16;
            this.SaveCategoryButton.Text = "Save";
            this.SaveCategoryButton.UseVisualStyleBackColor = true;
            this.SaveCategoryButton.Click += new System.EventHandler(this.SaveCategoryButton_Click);
            // 
            // DeleteCategoryButton
            // 
            this.DeleteCategoryButton.Location = new System.Drawing.Point(767, 206);
            this.DeleteCategoryButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteCategoryButton.Name = "DeleteCategoryButton";
            this.DeleteCategoryButton.Size = new System.Drawing.Size(82, 22);
            this.DeleteCategoryButton.TabIndex = 17;
            this.DeleteCategoryButton.Text = "Delete";
            this.DeleteCategoryButton.UseVisualStyleBackColor = true;
            this.DeleteCategoryButton.Click += new System.EventHandler(this.DeleteCategoryButton_Click);
            // 
            // episodeDescriptionLabel
            // 
            this.episodeDescriptionLabel.AutoSize = true;
            this.episodeDescriptionLabel.Location = new System.Drawing.Point(577, 256);
            this.episodeDescriptionLabel.Name = "episodeDescriptionLabel";
            this.episodeDescriptionLabel.Size = new System.Drawing.Size(0, 15);
            this.episodeDescriptionLabel.TabIndex = 18;
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Cursor = System.Windows.Forms.Cursors.Default;
            this.description.ForeColor = System.Drawing.SystemColors.GrayText;
            this.description.Location = new System.Drawing.Point(577, 271);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(281, 107);
            this.description.TabIndex = 19;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(441, 178);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PlaceholderText = "Name here....";
            this.NameTextBox.Size = new System.Drawing.Size(115, 23);
            this.NameTextBox.TabIndex = 20;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(441, 161);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(39, 15);
            this.nameLabel.TabIndex = 21;
            this.nameLabel.Text = "Name";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Frequency(m)";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Category";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(995, 388);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.description);
            this.Controls.Add(this.episodeDescriptionLabel);
            this.Controls.Add(this.DeleteCategoryButton);
            this.Controls.Add(this.SaveCategoryButton);
            this.Controls.Add(this.NewCategoryButton);
            this.Controls.Add(this.CreateCategoryLabel);
            this.Controls.Add(this.CreateCategoryTextBox);
            this.Controls.Add(this.CategoryListLabel);
            this.Controls.Add(this.PlaceholderCategory);
            this.Controls.Add(this.PlaceholderPod);
            this.Controls.Add(this.DeletePodButton);
            this.Controls.Add(this.SavePodButton);
            this.Controls.Add(this.NewPodButton);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.FrequencyComboBox);
            this.Controls.Add(this.UppdateFrequencyLabel);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.URLLabel);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Podcasts";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Label UppdateFrequencyLabel;
        private System.Windows.Forms.ComboBox FrequencyComboBox;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.Button NewPodButton;
        private System.Windows.Forms.Button SavePodButton;
        private System.Windows.Forms.Button DeletePodButton;
        private System.Windows.Forms.ListBox PlaceholderPod;
        private System.Windows.Forms.ListBox PlaceholderCategory;
        private System.Windows.Forms.Label CategoryListLabel;
        private System.Windows.Forms.TextBox CreateCategoryTextBox;
        private System.Windows.Forms.Label CreateCategoryLabel;
        private System.Windows.Forms.Button NewCategoryButton;
        private System.Windows.Forms.Button SaveCategoryButton;
        private System.Windows.Forms.Button DeleteCategoryButton;
        private System.Windows.Forms.Label episodeDescriptionLabel;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
