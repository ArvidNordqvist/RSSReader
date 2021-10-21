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
        CategoryController categoryController;
        public Form1()
        {
            InitializeComponent();
            categoryController = new CategoryController();
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
            categoryController.CreateCategory(CreateCategoryTextBox.Text);
        }
    }
}
