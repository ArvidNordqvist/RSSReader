using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        ExceptionClass Ex;
        public Form1()
        {
            InitializeComponent();
            categoryController = new SuperController();
            Ex = new ExceptionClass();
            //FyllKategoriLista();
            //FillCategoryComboBox();
            FillCategorylist();
            FillFeedList();
            Thread obj1 = new Thread(timer);
            obj1.Start();
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
        private void CategoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void NewCategoryButton_Click(object sender, EventArgs e)
        {
            //checks so that the user is typing longer or 3 characters
            if (Ex.checkTextInput(CreateCategoryTextBox.Text))
            {
                //creates a Category
                categoryController.CreateCategory(CreateCategoryTextBox.Text);

                // fill categories and combobox
                FillCategorylist();


            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You did not enter 2 or more letters";
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



        private void FeedListaByCategory(String kategori)
        {
            dataGridView1.Rows.Clear();
            List<Super> aList = new List<Super>();
            aList = categoryController.GetAllSuper();

            foreach (Super v in aList)
            {
                if (v.DataType == "Feed")
                {
                    Feed obj = (Feed)v; //gör om objektet från super till feed för att få tillgång till category fältet
                    if (obj.category == kategori)
                    {

                        string title = obj.Name;
                        string frekvens = obj.frekvens;
                        string cat = obj.category;
                        dataGridView1.Rows.Add(title, frekvens, cat);
                    }
                }
            }

        }

        private void PlaceholderCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task deleteCatAsync()
        {
            //deletes the selected category and removes it from the xml file aswell as the list and combobox.
            string category = PlaceholderCategory.GetItemText(PlaceholderCategory.SelectedItem);
            categoryController.Delete(category);

            List<Super> alist = new List<Super>();
            alist = await Task.Run(() => categoryController.GetAllSuper());
            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].DataType == "Feed")
                {
                    Feed obj = (Feed)alist[i];
                    if (obj.category == category)
                    {
                        String name = alist[i].Name;
                        for (int x = 0; x < alist.Count; x++)
                        {
                            if (alist[x].DataType == "Episode")
                            {
                                Episode epi = (Episode)alist[x];
                                if (epi.pod == name)
                                {
                                    categoryController.Delete(epi.Name);
                                }
                            }
                        }
                        categoryController.Delete(name);
                    }


                }
            }
            FillCategorylist();
            FillFeedList();
            PlaceholderPod.Items.Clear();
        }
        private async void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            await deleteCatAsync();
        }

        private void NewPodButton_Click(object sender, EventArgs e)
        {
            if (Ex.checkTextInput(URLTextBox.Text) && Ex.checkTextInput(FrequencyComboBox.Text) && Ex.checkTextInput(CategoryComboBox.Text) && Ex.checkTextInput(NameTextBox.Text)) ;
            {
                //RSS reader
                ParseRSSdotnet();
            }
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


                string title = NameTextBox.Text;
                string frekvens = FrequencyComboBox.SelectedItem.ToString();
                string cat = CategoryComboBox.SelectedItem.ToString();
                dataGridView1.Rows.Add(title, frekvens, cat);

                categoryController.CreateFeed(title, frekvens, URLTextBox.Text, cat);
                foreach (SyndicationItem item in feed.Items)
                {
                    categoryController.CreateEpisode(item.Title.Text, item.Summary.Text, title);
                }

            }
        }

        private void FillFeedList()
        {
            dataGridView1.Rows.Clear();
            SyndicationFeed feed = null;
            List<Super> aList = new List<Super>();

            aList = categoryController.GetAllSuper();
            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].DataType == "Feed")
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


                            string title = obj.Name;
                            string frekvens = obj.frekvens;
                            string cat = obj.category;
                            dataGridView1.Rows.Add(title, frekvens, cat);
                        }
                    }
                    catch
                    {
                    } // TODO: Deal with unavailable resource.
                }
            }
        }







        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PlaceholderPod.Items.Clear();
            await episodeListPerPodcastAsync();
        }
        private async void DeletePodButton_Click(object sender, EventArgs e)
        {
            await DeleteFeedAsync();
        }

        private async Task DeleteFeedAsync()
        {
            List<Super> alist = new List<Super>();
            string dataCellItem = dataGridView1.CurrentCell.Value.ToString();
            alist = await Task.Run(() => categoryController.GetAllSuper());
            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].DataType == "Feed")
                {
                    String name = alist[i].Name;
                    if (name == dataCellItem)
                    {

                        for (int x = 0; x < alist.Count; x++)
                        {
                            if (alist[x].DataType == "Episode")
                            {
                                Episode epi = (Episode)alist[x];
                                if (epi.pod == name)
                                {
                                    categoryController.Delete(epi.Name);
                                }
                            }
                        }
                        categoryController.Delete(name);
                    }
                }
            }
            FillFeedList();
            PlaceholderPod.Items.Clear();
        }

        private async Task episodeListPerPodcastAsync()
        {

            List<Super> aList = new List<Super>();
            string dataCellItem = dataGridView1.CurrentCell.Value.ToString();

            aList = await Task.Run(() => categoryController.GetAllSuper());
            foreach (Super v in aList)
            {
                if (v.DataType == "Episode")
                {
                    Episode obj = (Episode)v;
                    if (obj.pod == dataCellItem)
                    {

                        PlaceholderPod.Items.Add(obj.Name);
                    }
                }
            }
        }


        private async void PlaceholderPod_Click(object sender, EventArgs e)
        {
            await ShowEpisodeDescriptionAsync();
        }

        private async Task ShowEpisodeDescriptionAsync()
        {
            if (PlaceholderPod.SelectedItem.ToString() == null)
            {
            }
            else
            {
                List<Super> aList = new List<Super>();
                string selectedItem = PlaceholderPod.SelectedItem.ToString();

                aList = await Task.Run(() => categoryController.GetAllSuper());
                for (int i = 0; i < aList.Count; i++)
                {
                    if (aList[i].DataType == "Category" || aList[i].DataType == "Feed")
                    {
                        continue;
                    }
                    Episode obj = (Episode)aList[i];
                    if (obj.Name == selectedItem)
                    {
                        episodeDescriptionLabel.Text = obj.Display();
                        description.Text = obj.description;
                    }
                }
            }
        }

        private async void timer()
        {
            List<Super> aList = new List<Super>();
            aList = await Task.Run(() => categoryController.GetAllSuper());
            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].DataType == "Feed")
                {
                    Feed obj = (Feed)aList[i];
                    if (obj.frekvens == "10 seconds")
                    {
                        Thread.Sleep(10000);
                    }
                    else if (obj.frekvens == "1 minute")
                    {
                        Thread.Sleep(60000);
                    }
                    else if (obj.frekvens == "10 minutes")
                    {
                        Thread.Sleep(600000);
                    }
                }

            }
        }

        private void PlaceholderCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String cat = PlaceholderCategory.SelectedItem.ToString();
            FeedListaByCategory(cat);
        }
    }

}
