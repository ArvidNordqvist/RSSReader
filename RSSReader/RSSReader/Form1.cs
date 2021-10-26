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
using System.Net.Http;
using System.Xml;
using System.ServiceModel.Syndication;

namespace RSSReader
{
    public partial class Form1 : Form
    {
        SuperController categoryController;
        public Form1()
        {
            InitializeComponent();
            categoryController = new SuperController();
            FyllKategoriLista();
            FillCategoryComboBox();
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
        private List<Super> lista()
        {
            List<Super> list = new List<Super>();
            list = categoryController.GetAllSuper();
            foreach (Super obj in list)
            {
                Console.WriteLine(obj.Name);
            }
            return list;

        }
        private void CategoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void NewCategoryButton_Click(object sender, EventArgs e)
        {

            if (CreateCategoryTextBox.TextLength >= 3)
            {
                categoryController.CreateCategory(CreateCategoryTextBox.Text);
                FyllKategoriLista();
                FillCategoryComboBox();
            }
            else
            {
                CreateCategoryTextBox.PlaceholderText = "Please type a name";

            }
        }

        private void FyllKategoriLista()
        {
            List<Super> list = new List<Super>();
            list = categoryController.GetAllSuper();
            List<string> Category = (from Categories obj in list
                                     select obj.Name).ToList();
            PlaceholderCategory.DataSource = Category;
        }

        private void FillCategoryComboBox()
        {
            List<Super> list = new List<Super>();
            list = categoryController.GetAllSuper();
            List<string> Category = (from Categories obj in list
                                     select obj.Name).ToList();
            foreach(string name in Category)
            {
                CategoryComboBox.Items.Add(name);
            }
        }

        private List<Feed> FeedListaByCategory(String kategori)
        {
            List<Super> list = new List<Super>();
        list = categoryController.GetAllSuper();
            return (from Feed obj in list
                    where obj.category.Equals(kategori)
                    select obj).ToList();
        }



        private void PlaceholderCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            string category = PlaceholderCategory.GetItemText(PlaceholderCategory.SelectedItem);
            categoryController.DeleteCategory(category);
            FyllKategoriLista();
            FillCategoryComboBox();
        }

        private void NewPodButton_Click(object sender, EventArgs e)
        {
            ParseRSSdotnet();
        }
        private void ParseRSSdotnet()
        {
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create(URLTextBox.Text))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch
            {
            } // TODO: Deal with unavailable resource.

            if (feed != null)
            {

                    string episode = $"Episodes: {feed.Items.ToList().Count}";
                    string title = NameTextBox.Text;
                    dataGridView1.Rows.Add(episode, title, FrequencyComboBox.SelectedItem.ToString() ,CategoryComboBox.Text);
                //Feed newFeed = new Feed(title, );
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
