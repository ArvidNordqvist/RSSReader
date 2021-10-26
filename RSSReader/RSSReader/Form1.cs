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
        SuperController categoryController;
        public Form1()
        {
            InitializeComponent();
            categoryController = new SuperController();
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
        private void lista()
        {
            List<Super> list = new List<Super>();
            list = categoryController.GetAllSuper();
            foreach (Super obj in list)
            {
                Console.WriteLine(obj.Name);
            }

        }
        private void CategoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void NewCategoryButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Try");
            if (CreateCategoryTextBox.TextLength >= 3)
            {
                categoryController.CreateCategory(CreateCategoryTextBox.Text);
                lista();
            }
            else
            {
                CreateCategoryTextBox.PlaceholderText = "Please type a name";
                Console.WriteLine("failed");
            }
        }
    }
}
