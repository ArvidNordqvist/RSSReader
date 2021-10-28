﻿using System;
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
            //FyllKategoriLista();
            //FillCategoryComboBox();
            FillCategorylist();
            FillFeedList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
            //checks so that the user is typing longer or 3 characters
            if (CreateCategoryTextBox.TextLength >= 3)
            {
                //creates a Category
                categoryController.CreateCategory(CreateCategoryTextBox.Text);

                // fill categories and combobox
                FillCategorylist();


            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You did not enter 3 or more letters";
                string caption = "Error Detected in Input";

                // Displays the MessageBox.
                MessageBox.Show(message, caption);

            }
        }








        private void FillCategorylist()
        {

            PlaceholderCategory.DataSource = categoryController.Categorylist();
            foreach (string name in categoryController.Categorylist())
            {
                CategoryComboBox.Items.Add(name);
            }
        }



        private List<Feed> FeedListaByCategory(String kategori)
        {
            List<Super> list = new List<Super>();
            list = categoryController.GetAllSuper();
            //return a list of feeds depending on the Category searched
            return (from Feed obj in list
                    where obj.category.Equals(kategori)
                    select obj).ToList();
        }

        private void PlaceholderCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            //deletes the selected category and removes it from the xml file aswell as the list and combobox.
            string category = PlaceholderCategory.GetItemText(PlaceholderCategory.SelectedItem);
            categoryController.DeleteCategory(category);
            FillCategorylist();
        }

        private void NewPodButton_Click(object sender, EventArgs e)
        {
            //RSS reader
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

                string episode = $"{feed.Items.ToList().Count}";
                string title = NameTextBox.Text;
                string frekvens = FrequencyComboBox.SelectedItem.ToString();
                string cat = CategoryComboBox.SelectedItem.ToString();
                dataGridView1.Rows.Add(episode, title, frekvens, cat);

                categoryController.CreateFeed(title, frekvens, URLTextBox.Text, cat);
            }
        }

        private void FillFeedList()
        {
            SyndicationFeed feed = null;
            List<Super> aList = new List<Super>();

            aList = categoryController.GetAllSuper();
            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].DataType == "Category" || aList[i].DataType == "Episode")
                {
                    continue;
                }

                {
                    try
                    {
                        Feed obj = (Feed)aList[i];
                        using (var reader = XmlReader.Create(obj.URL))
                        {
                            feed = SyndicationFeed.Load(reader);
                        }
                        if (feed != null)
                        {

                            string episode = $"{feed.Items.ToList().Count}";
                            string title = obj.Name;
                            string frekvens = obj.frekvens;
                            string cat = obj.category;
                            dataGridView1.Rows.Add(episode, title, frekvens, cat);

                        }

                    }
                    catch
                    {
                    } // TODO: Deal with unavailable resource.

                }
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private async Task episodeListPerPodcast()
        {
            if (dataGridView1.CurrentCell.ToString() == null)
            {

            }
            else
            {

                SyndicationFeed feed = null;
                List<Super> aList = new List<Super>();
                string dataCellItem = dataGridView1.CurrentCell.Value.ToString();

                aList = await Task.Run(() => categoryController.GetAllSuper());
                for (int i = 0; i < aList.Count; i++)
                {
                    if (aList[i].DataType == "Category" || aList[i].DataType == "Episode")
                    {
                        continue;
                    }

                    if (aList[i].Name == dataCellItem)
                    {
                        try
                        {
                            Feed obj = (Feed)aList[i];
                            using (var reader = XmlReader.Create(obj.URL))
                            {
                                feed = SyndicationFeed.Load(reader);
                            }
                            if (feed != null)
                            {

                                foreach (SyndicationItem item in feed.Items.Reverse())
                                {
                                    PlaceholderPod.Items.Add(item.Title.Text);
                                }

                            }
                        }
                        catch
                        {
                        } // TODO: Deal with unavailable resource.
                    }



                }
            }
        }

        private void testListBoxPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testListBoxPodcasts_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PlaceholderPod.Items.Clear();
            episodeListPerPodcast();
        }
    }

}




