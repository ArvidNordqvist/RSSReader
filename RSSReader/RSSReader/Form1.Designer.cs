
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLLabel = new System.Windows.Forms.Label();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.UppdateFrequencyLabel = new System.Windows.Forms.Label();
            this.FrequencyComboBox = new System.Windows.Forms.ComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            //
            // dataGridView1
            //
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(14, 17);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(780, 235);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            //
            // Column1
            //
            this.Column1.HeaderText = "Episode";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
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
            this.Column3.HeaderText = "Frequency";
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
            // URLLabel
            //
            this.URLLabel.AutoSize = true;
            this.URLLabel.Location = new System.Drawing.Point(27, 268);
            this.URLLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(47, 25);
            this.URLLabel.TabIndex = 1;
            this.URLLabel.Text = "URL:";
            //
            // URLTextBox
            //
            this.URLTextBox.Location = new System.Drawing.Point(27, 298);
            this.URLTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.PlaceholderText = "http;//.....";
            this.URLTextBox.Size = new System.Drawing.Size(261, 31);
            this.URLTextBox.TabIndex = 2;
            //
            // UppdateFrequencyLabel
            //
            this.UppdateFrequencyLabel.AutoSize = true;
            this.UppdateFrequencyLabel.Location = new System.Drawing.Point(313, 268);
            this.UppdateFrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UppdateFrequencyLabel.Name = "UppdateFrequencyLabel";
            this.UppdateFrequencyLabel.Size = new System.Drawing.Size(156, 25);
            this.UppdateFrequencyLabel.TabIndex = 3;
            this.UppdateFrequencyLabel.Text = "Update Frequency";
            //
            // FrequencyComboBox
            //
            this.FrequencyComboBox.FormattingEnabled = true;
            this.FrequencyComboBox.Items.AddRange(new object[] {
            "10 seconds",
            "1 minute",
            "10 minutes"});
            this.FrequencyComboBox.Location = new System.Drawing.Point(313, 298);
            this.FrequencyComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FrequencyComboBox.Name = "FrequencyComboBox";
            this.FrequencyComboBox.Size = new System.Drawing.Size(145, 33);
            this.FrequencyComboBox.TabIndex = 4;
            //
            // CategoryLabel
            //
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(493, 268);
            this.CategoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(84, 25);
            this.CategoryLabel.TabIndex = 5;
            this.CategoryLabel.Text = "Category";
            this.CategoryLabel.Click += new System.EventHandler(this.CategoryLabel_Click);
            //
            // CategoryComboBox
            //
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(493, 298);
            this.CategoryComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(115, 33);
            this.CategoryComboBox.TabIndex = 6;
            //
            // NewPodButton
            //
            this.NewPodButton.Location = new System.Drawing.Point(357, 343);
            this.NewPodButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NewPodButton.Name = "NewPodButton";
            this.NewPodButton.Size = new System.Drawing.Size(117, 37);
            this.NewPodButton.TabIndex = 7;
            this.NewPodButton.Text = "New";
            this.NewPodButton.UseVisualStyleBackColor = true;
            this.NewPodButton.Click += new System.EventHandler(this.NewPodButton_Click);
            //
            // SavePodButton
            //
            this.SavePodButton.Location = new System.Drawing.Point(493, 343);
            this.SavePodButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SavePodButton.Name = "SavePodButton";
            this.SavePodButton.Size = new System.Drawing.Size(117, 37);
            this.SavePodButton.TabIndex = 8;
            this.SavePodButton.Text = "Save";
            this.SavePodButton.UseVisualStyleBackColor = true;
            this.SavePodButton.Click += new System.EventHandler(this.SavePodButton_Click);
            //
            // DeletePodButton
            //
            this.DeletePodButton.Location = new System.Drawing.Point(630, 343);
            this.DeletePodButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeletePodButton.Name = "DeletePodButton";
            this.DeletePodButton.Size = new System.Drawing.Size(117, 37);
            this.DeletePodButton.TabIndex = 9;
            this.DeletePodButton.Text = "Delete";
            this.DeletePodButton.UseVisualStyleBackColor = true;
            this.DeletePodButton.Click += new System.EventHandler(this.DeletePodButton_Click);
            //
            // PlaceholderPod
            //
            this.PlaceholderPod.FormattingEnabled = true;
            this.PlaceholderPod.ItemHeight = 25;
            this.PlaceholderPod.Location = new System.Drawing.Point(14, 427);
            this.PlaceholderPod.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PlaceholderPod.Name = "PlaceholderPod";
            this.PlaceholderPod.Size = new System.Drawing.Size(778, 204);
            this.PlaceholderPod.TabIndex = 10;
            this.PlaceholderPod.Click += new System.EventHandler(this.PlaceholderPod_Click);
            //
            // PlaceholderCategory
            //
            this.PlaceholderCategory.FormattingEnabled = true;
            this.PlaceholderCategory.ItemHeight = 25;
            this.PlaceholderCategory.Location = new System.Drawing.Point(824, 45);
            this.PlaceholderCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PlaceholderCategory.Name = "PlaceholderCategory";
            this.PlaceholderCategory.Size = new System.Drawing.Size(581, 204);
            this.PlaceholderCategory.TabIndex = 11;
            this.PlaceholderCategory.SelectedIndexChanged += new System.EventHandler(this.PlaceholderCategory_SelectedIndexChanged);
            //
            // CategoryListLabel
            //
            this.CategoryListLabel.AutoSize = true;
            this.CategoryListLabel.Location = new System.Drawing.Point(824, 12);
            this.CategoryListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CategoryListLabel.Name = "CategoryListLabel";
            this.CategoryListLabel.Size = new System.Drawing.Size(100, 25);
            this.CategoryListLabel.TabIndex = 12;
            this.CategoryListLabel.Text = "Categories:";
            //
            // CreateCategoryTextBox
            //
            this.CreateCategoryTextBox.Location = new System.Drawing.Point(824, 297);
            this.CreateCategoryTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CreateCategoryTextBox.Name = "CreateCategoryTextBox";
            this.CreateCategoryTextBox.PlaceholderText = "Name here...";
            this.CreateCategoryTextBox.Size = new System.Drawing.Size(581, 31);
            this.CreateCategoryTextBox.TabIndex = 13;
            //
            // CreateCategoryLabel
            //
            this.CreateCategoryLabel.AutoSize = true;
            this.CreateCategoryLabel.Location = new System.Drawing.Point(824, 268);
            this.CreateCategoryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CreateCategoryLabel.Name = "CreateCategoryLabel";
            this.CreateCategoryLabel.Size = new System.Drawing.Size(139, 25);
            this.CreateCategoryLabel.TabIndex = 14;
            this.CreateCategoryLabel.Text = "Create Category";
            //
            // NewCategoryButton
            //
            this.NewCategoryButton.Location = new System.Drawing.Point(824, 343);
            this.NewCategoryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NewCategoryButton.Name = "NewCategoryButton";
            this.NewCategoryButton.Size = new System.Drawing.Size(117, 37);
            this.NewCategoryButton.TabIndex = 15;
            this.NewCategoryButton.Text = "New";
            this.NewCategoryButton.UseVisualStyleBackColor = true;
            this.NewCategoryButton.Click += new System.EventHandler(this.NewCategoryButton_Click);
            //
            // SaveCategoryButton
            //
            this.SaveCategoryButton.Location = new System.Drawing.Point(960, 343);
            this.SaveCategoryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SaveCategoryButton.Name = "SaveCategoryButton";
            this.SaveCategoryButton.Size = new System.Drawing.Size(117, 37);
            this.SaveCategoryButton.TabIndex = 16;
            this.SaveCategoryButton.Text = "Save";
            this.SaveCategoryButton.UseVisualStyleBackColor = true;
            //
            // DeleteCategoryButton
            //
            this.DeleteCategoryButton.Location = new System.Drawing.Point(1096, 343);
            this.DeleteCategoryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DeleteCategoryButton.Name = "DeleteCategoryButton";
            this.DeleteCategoryButton.Size = new System.Drawing.Size(117, 37);
            this.DeleteCategoryButton.TabIndex = 17;
            this.DeleteCategoryButton.Text = "Delete";
            this.DeleteCategoryButton.UseVisualStyleBackColor = true;
            this.DeleteCategoryButton.Click += new System.EventHandler(this.DeleteCategoryButton_Click);
            //
            // episodeDescriptionLabel
            //
            this.episodeDescriptionLabel.AutoSize = true;
            this.episodeDescriptionLabel.Location = new System.Drawing.Point(824, 427);
            this.episodeDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.episodeDescriptionLabel.Name = "episodeDescriptionLabel";
            this.episodeDescriptionLabel.Size = new System.Drawing.Size(0, 25);
            this.episodeDescriptionLabel.TabIndex = 18;
            this.episodeDescriptionLabel.Click += new System.EventHandler(this.label1_Click);
            //
            // description
            //
            this.description.BackColor = System.Drawing.Color.Transparent;
            this.description.Cursor = System.Windows.Forms.Cursors.Default;
            this.description.ForeColor = System.Drawing.SystemColors.GrayText;
            this.description.Location = new System.Drawing.Point(824, 452);
            this.description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(402, 179);
            this.description.TabIndex = 19;
            //
            // NameTextBox
            //
            this.NameTextBox.Location = new System.Drawing.Point(630, 297);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PlaceholderText = "Name here....";
            this.NameTextBox.Size = new System.Drawing.Size(163, 31);
            this.NameTextBox.TabIndex = 20;
            //
            // nameLabel
            //
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(630, 268);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 25);
            this.nameLabel.TabIndex = 21;
            this.nameLabel.Text = "Name";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1421, 647);
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
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label nameLabel;
    }
}
