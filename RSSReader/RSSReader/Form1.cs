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
            categoryController.Delete(category);

            List<Super> alist = new List<Super>();
            alist = categoryController.GetAllSuper();
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


        private void testListBoxPodcasts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testListBoxPodcasts_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PlaceholderPod.Items.Clear();
            await episodeListPerPodcastAsync();
        }

        private async Task episodeListPerPodcastAsync()
        {
            if (dataGridView1.CurrentCell.ToString() == null)
            {

            }
            else
            {
                List<Super> aList = new List<Super>();
                string dataCellItem = dataGridView1.CurrentCell.Value.ToString();

                aList = await Task.Run(() => categoryController.GetAllSuper());
                for (int i = 0; i < aList.Count; i++)
                {
                    if (aList[i].DataType == "Category" || aList[i].DataType == "Feed")
                    {
                        continue;
                    }
                    Episode obj = (Episode)aList[i];
                    if (obj.pod == dataCellItem)
                    {

                        PlaceholderPod.Items.Add(obj.Name);
                    }
                }
            }
        }

        private async void DeletePodButton_Click(object sender, EventArgs e)
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
    }
}


