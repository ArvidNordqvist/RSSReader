using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using BusinessLayer.Controllers;

namespace RSSReader
{
    public partial class Form1 : Form
    {
        SuperController superController;
        public Form1()
        {
            InitializeComponent();
            superController = new SuperController();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void CategoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void NewCategoryButton_Click(object sender, EventArgs e)
        {
            if (CreateCategoryTextBox.TextLength >= 3)
            {
                superController.CreateCategory(CreateCategoryTextBox.Text);
            }
            else
            {
                CreateCategoryTextBox.PlaceholderText = "Please type a name";
            }

            List<Categories> cat = superController.getCategory();
            foreach(Categories item in cat)
            {
                PlaceholderCategory.Items.Add(item);
            }
        }

        private void PlaceholderCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
