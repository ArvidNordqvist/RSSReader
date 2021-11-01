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
        private Timer timer1 = new Timer();
        List<Super> aList = new List<Super>();
        int numberOfTimeUpdated = 0;
        public Form1()
        {
            InitializeComponent();
            categoryController = new SuperController();
            FillCategorylist();
            FillFeedList();
            timer1.Interval = 10000;
            aList = categoryController.GetAllSuper();
            timer1.Tick += Timer1_Tick;
            
            timer1.Start();

        }

        

        private void Timer1_Tick(object sender, EventArgs e)
        {
            SyndicationFeed feed = null;
            
            foreach (Super s in aList)
            {
                if (s.DataType == "Feed")
                {
                    Feed obj = (Feed)s;
                    if (obj.NeedsUpdate)
                    {
                        String name = s.Name;
                        for (int x = 0; x < aList.Count; x++)
                        {
                            if (aList[x].DataType == "Episode")
                            {
                                Episode epi = (Episode)aList[x];
                                if (epi.pod == name)
                                {
                                    categoryController.Delete(epi.Name);
                                }
                            }
                        }
                    }
                    try
                    {
                        using (var reader = XmlReader.Create(obj.URL))
                        {
                            feed = SyndicationFeed.Load(reader);
                        }
                        foreach (SyndicationItem item in feed.Items)
                        {
                            categoryController.CreateEpisode(item.Title.Text, item.Summary.Text, obj.Name);
                        }
                        FillFeedList();

                    }
                    catch
                    {

                    }
                }
            }
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
            if (string.IsNullOrEmpty(CreateCategoryTextBox.Text))
            {

                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "You did not enter 2 or more letters";
                string caption = "Error Detected in Input";

                // Displays the MessageBox.
                MessageBox.Show(message, caption);

            }
            else
            {
                //creates a Category
                categoryController.CreateCategory(CreateCategoryTextBox.Text);

                // fill categories and combobox
                FillCategorylist();

            }
        }



        private void FillCategorylist()
        {
            PlaceholderCategory.DataSource = null;
            CategoryComboBox.Items.Clear();
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
                        double frekvens = obj.frekvens;
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
            DialogResult result = MessageBox.Show("Do You Want to delete Category? All podcast within this caregory will also be deleted.", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
               await deleteCatAsync(); 
            }
            
        }

        private void NewPodButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(URLTextBox.Text) || FrequencyComboBox.SelectedItem == null || CategoryComboBox.SelectedItem == null || string.IsNullOrEmpty(NameTextBox.Text))
                {
                    throw new EmptyStringException();
                }
                else
                {
                   string frek =  FrequencyComboBox.SelectedItem.ToString();

                    double frekd = 0;
                   // ParseRSSdotnet(NameTextBox.Text, frekd, CategoryComboBox.SelectedItem.ToString(), URLTextBox.Text);
                    if (frek == "10 seconds")
                    {
                        frekd = 10000;
                        
                    }
                    if (frek == "1 minute")
                    {
                        frekd = 600000;
                        
                    }
                    if (frek == "10 minutes")
                    {
                        frekd = 6000000;
                        
                    }
                    ParseRSSdotnet(NameTextBox.Text, frekd, CategoryComboBox.SelectedItem.ToString(), URLTextBox.Text);


                    //RSS reader

                }

            }
            catch (EmptyStringException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ParseRSSdotnet(string newTitle, double newFrekvens, string newCat, string URL)
        {
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create(URL))
                {
                    feed = SyndicationFeed.Load(reader);
                }
                    string title = newTitle;
                    double frekvens = newFrekvens;
                    string cat = newCat;
                    
                    categoryController.CreateFeed(title, frekvens, URL, cat);
                    
                    
                    foreach (SyndicationItem item in feed.Items)
                    {
                        categoryController.CreateEpisode(item.Title.Text, item.Summary.Text, title);
                    }
                    FillFeedList();
                
            }
            catch
            {
            } // TODO: Deal with unavailable resource.
        }

        private void FillFeedList()
        {
            dataGridView1.Rows.Clear();
            List<Super> aList = new List<Super>();

            aList = categoryController.GetAllSuper();
            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].DataType == "Feed")
                {
                    try
                    {
                        Feed obj = (Feed)aList[i];
                        string title = obj.Name;
                        double frekvens = obj.frekvens;
                        string cat = obj.category;
                        dataGridView1.Rows.Add(title, frekvens, cat);

                    }
                    catch
                    {
                    } // TODO: Deal with unavailable resource.   
                }

                {


                }
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }







        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PlaceholderPod.Items.Clear();
            await episodeListPerPodcastAsync();
        }

        private async Task UppdateFeedAsync(string name)
        {
            List<Super> alist = new List<Super>();

            alist = await Task.Run(() => categoryController.GetAllSuper());

            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].DataType == "Feed")
                {
                    Feed f = (Feed)alist[i];
                    if (f.Name == name)
                    {
                        string frek = FrequencyComboBox.SelectedItem.ToString();
                        double frekd = 0;
                        if (frek == "10 seconds")
                        {
                            frekd = 10000;

                        }
                        if (frek == "1 minute")
                        {
                            frekd = 600000;

                        }
                        if (frek == "10 minutes")
                        {
                            frekd = 6000000;

                        }
                        Feed fe = new Feed(NameTextBox.Text, frekd, URLTextBox.Text, CategoryComboBox.Text);

                        categoryController.Update(alist[i].Name, fe);
                    }
                }
                if (alist[i].DataType == "Episode")
                {
                    Episode e = (Episode)alist[i];
                    if (e.pod == name)
                    {
                        Episode ep = new Episode(e.Name, e.description, NameTextBox.Text);

                        categoryController.Update(alist[i].Name, ep);
                    }
                }
            }
            FillCategorylist();
            FillFeedList();
        }

        private async Task UppdateCategoryAsync(string cat, string newCat)
        {
            List<Super> alist = new List<Super>();

            alist = await Task.Run(() => categoryController.GetAllSuper());

            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].Name == cat)
                {
                    Categories cate = new Categories(newCat);
                    categoryController.Update(alist[i].Name, cate);
                }
                if (alist[i].DataType == "Feed")
                {
                    Feed f = (Feed)alist[i];
                    if (f.category == cat)
                    {

                        Feed fe = new Feed(f.Name, f.frekvens, f.URL, newCat);
                        categoryController.Update(alist[i].Name, fe);
                    }
                }
            }
            FillCategorylist();
            FillFeedList();
        }

        private async void DeletePodButton_Click(object sender, EventArgs e)
        {
            await DeleteFeedAsync(dataGridView1.CurrentCell.Value.ToString());
            FillFeedList();
            PlaceholderPod.Items.Clear();
        }

        private async Task DeleteFeedAsync(string feedName)
        {
            List<Super> alist = new List<Super>();
            string dataCellItem = feedName;
            alist = await Task.Run(() => categoryController.GetAllSuper());
            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].DataType == "Feed")
                {
                    string name = alist[i].Name;
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

       

        private void PlaceholderCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            String cat = PlaceholderCategory.SelectedItem.ToString();
            FeedListaByCategory(cat);
        }

        private async void SaveCategoryButton_Click(object sender, EventArgs e)
        {
            String cat = PlaceholderCategory.SelectedItem.ToString();
            String newCat = CreateCategoryTextBox.Text;
            await UppdateCategoryAsync(cat, newCat);
            FillCategorylist();
            FillFeedList();
        }

        private async void SavePodButton_Click(object sender, EventArgs e)
        {
            await UppdateFeedAsync(dataGridView1.CurrentCell.Value.ToString());
        }

        private async void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<Super> aList = new List<Super>();
            string selectedItem = dataGridView1.CurrentCell.Value.ToString();
            aList = await Task.Run(() => categoryController.GetAllSuper());
            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].DataType == "Feed")
                {
                    Feed obj = (Feed)aList[i];
                    if (obj.Name == selectedItem)
                    {
                        

                        URLTextBox.Text = obj.URL;
                        CategoryComboBox.Text = obj.category;
                        FrequencyComboBox.Text = obj.frekvens.ToString();
                        NameTextBox.Text = obj.Name;
                    }
                }
               

                }
        }

    }
}
