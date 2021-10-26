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
            Console.WriteLine("Try");
            if (CreateCategoryTextBox.TextLength >= 3)
            {
                categoryController.CreateCategory(CreateCategoryTextBox.Text);
                FyllKategoriLista();
            }
            else
            {
                CreateCategoryTextBox.PlaceholderText = "Please type a name";
                Console.WriteLine("failed");
            }
        }

        private void FyllKategoriLista()
        {
            List<Super> list = new List<Super>();
            list = categoryController.GetAllSuper();
            List<string> Category = new List<string>();
            foreach (Categories obj in list)
            {
                Category.Add(obj.Name);
            }
            PlaceholderCategory.DataSource = Category;
        }
    

        private void PlaceholderCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
          string category = PlaceholderCategory.GetItemText(PlaceholderCategory.SelectedItem);
            categoryController.DeleteCategory(category);
            FyllKategoriLista();
        }

        private void NewPodButton_Click(object sender, EventArgs e)
        {
            ParseRSSdotnet();
        }
        public void ParseRSSdotnet()
        {
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create("https://visualstudiomagazine.com/rss-feeds/news.aspx"))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch { } // TODO: Deal with unavailable resource.

            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    Console.WriteLine($"Title: {element.Title.Text}");
                    Console.WriteLine($"Summary: {element.Summary.Text}");
                }
            }
        }
    }
