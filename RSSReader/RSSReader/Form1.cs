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
        SuperController superController;
        private Timer timer = new Timer();
        List<Super> aList = new List<Super>();
        EmptyStringException exception;

        public Form1()
        {
            InitializeComponent();
            superController = new SuperController();
            FillCategorylist();
            FillFeedList();
            exception = new EmptyStringException();
            timer.Interval = 60000; // timeinterval is 1 minute
            aList = superController.GetAllSuper();
            timer.Tick += Timer1_Tick;
            timer.Start();
        }



        private async void Timer1_Tick(object sender, EventArgs e)
        {
            SyndicationFeed feed = null;
            aList = superController.FeedList();
            foreach (Super s in aList) //check all the feeds if they need to uppdate (within their frequencey)
            {
                Feed obj = (Feed)s;
                if (obj.NeedsUpdate)
                {
                    string name = s.Name;
                    for (int x = 0; x < aList.Count; x++) // if it needs tp uppdate
                    {
                        if (aList[x].DataType == "Episode")
                        {
                            Episode epi = (Episode)aList[x];
                            if (epi.pod == name)
                            {
                                await superController.DeleteAsync(epi.Name); // remove all old epsiodes
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
                        await superController.CreateEpisodeAsync(item.Title.Text, item.Summary.Text, obj.Name); //adds all episodes, including new ones
                    }
                    FillFeedList();

                }
                catch
                {

                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


        private async void NewCategoryButton_Click(object sender, EventArgs e)
        {
            //checks so that the user is typing longer or 3 characters
            if (exception.textCheck(CreateCategoryTextBox.Text))
            {
                //creates a Category
                await superController.CreateCategoryAsync(CreateCategoryTextBox.Text);

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
            PlaceholderCategory.DataSource = null;
            CategoryComboBox.Items.Clear();
            PlaceholderCategory.DataSource = superController.Categorylist(); // retrives a list of all the categories
            foreach (string name in superController.Categorylist())
            {
                CategoryComboBox.Items.Add(name); //displays all the categories to the placeholder
            }
        }



        private async void FeedListaByCategory(string kategori)
        {
            dataGridView1.Rows.Clear();
            List<Super> aList = new List<Super>();
            aList = await Task.Run(() => superController.FeedList());

            foreach (Super v in aList)
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

        private async Task deleteCatAsync()
        {
            //deletes the selected category and removes it from the xml file aswell as the list and combobox.
            string category = PlaceholderCategory.GetItemText(PlaceholderCategory.SelectedItem);
            await superController.DeleteAsync(category);

            List<Super> alist = new List<Super>();
            alist = await Task.Run(() => superController.GetAllSuper());
            foreach (var name in from Super v in alist
                                 where v.DataType == "Feed"
                                 let obj = (Feed)v
                                 where obj.category == category
                                 let name = v.Name
                                 select name) //selects a feed name based on category using LINQ
            {
                foreach (var epi in from Super v in alist
                                    where v.DataType == "Episode"
                                    let epi = (Episode)v
                                    where epi.pod == name
                                    select epi) //selects an episode based on the selected feed name, using LINQ
                {
                    await superController.DeleteAsync(epi.Name);
                }

                await superController.DeleteAsync(name);
            }

            FillCategorylist();
            FillFeedList();
            PlaceholderPod.Items.Clear();
        }
        private async void DeleteCategoryButton_Click(object sender, EventArgs e)
        {
            // double checks if the user wants to delete the category and its feeds and episodes
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
                if (exception.textCheck(URLTextBox.Text) && FrequencyComboBox.SelectedItem != null && CategoryComboBox.SelectedItem != null && exception.textCheck(NameTextBox.Text))
                {
                    string frek = FrequencyComboBox.SelectedItem.ToString();

                    double frekd = 0;
                    //converts the value into milliseconds
                    if (frek == "15 minutes")
                    {
                        frekd = 15 * 60 * 1000;

                    }
                    if (frek == "30 minutes")
                    {
                        frekd = 30 * 60 * 1000;

                    }
                    if (frek == "1 hour")
                    {
                        frekd = 60 * 60 * 1000;

                    }
                    CreateFeed(NameTextBox.Text, frekd, CategoryComboBox.SelectedItem.ToString(), URLTextBox.Text);

                }
                else
                {
                    throw new EmptyStringException();
                }
            }
            catch (EmptyStringException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private async void CreateFeed(string newTitle, double newFrekvens, string newCat, string URL)
        {
            SyndicationFeed feed = null;

            try
            {
                using (var reader = XmlReader.Create(URL))
                {
                    feed = SyndicationFeed.Load(reader); // loads the URL
                }
                string title = newTitle;
                double frekvens = newFrekvens;
                string cat = newCat;
                await superController.CreateFeedAsync(title, frekvens, URL, cat);
                foreach (SyndicationItem item in feed.Items)
                {
                    await superController.CreateEpisodeAsync(item.Title.Text, item.Summary.Text, title); // add each episode using the XML reader
                }
                FillFeedList();

            }
            catch
            {
            }
        }

        private void FillFeedList()
        {
            dataGridView1.Rows.Clear();
            List<Super> aList = new List<Super>();
            aList = superController.FeedList();
            foreach (Super f in aList)
            {
                try
                {
                    Feed obj = (Feed)f;
                    string title = obj.Name;
                    double frekvens = obj.frekvens / (60 * 1000); //converts milliseconds to minutes
                    string cat = obj.category;
                    dataGridView1.Rows.Add(title, frekvens, cat);

                }
                catch
                {
                }
            }
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PlaceholderPod.Items.Clear();
            await episodeListPerPodcastAsync();
        }

        private async Task UppdateFeedAsync(string name)
        {
            List<Super> alist = new List<Super>();

            alist = await Task.Run(() => superController.GetAllSuper());
            try
            {
                for (int i = 0; i < alist.Count; i++)
                {
                    if (alist[i].DataType == "Feed")
                    {
                        Feed f = (Feed)alist[i]; // convert super object to feed if the datatype is Feed, to get its attributes
                        if (f.Name == name)
                        {
                            string frek = FrequencyComboBox.SelectedItem.ToString(); // selects the selected item from the frequency combobox and then converts it to a double-type
                            double frekd = 0;
                            // converts minutes to milliseconds
                            if (frek == "15 minutes")
                            {
                                frekd = 15 * 60 * 1000;

                            }
                            if (frek == "30 minutes")
                            {
                                frekd = 30 * 60 * 1000;

                            }
                            if (frek == "1 hour")
                            {
                                frekd = 60 * 60 * 1000;

                            }
                            Feed fe = new Feed(NameTextBox.Text, frekd, URLTextBox.Text, CategoryComboBox.Text); // creates new feed object

                            await Task.Run(() => superController.Update(alist[i].Name, fe)); //seralizes the new object 
                        }
                    }
                    if (alist[i].DataType == "Episode")
                    {
                        Episode e = (Episode)alist[i];
                        if (e.pod == name)
                        {
                            Episode ep = new Episode(e.Name, e.description, NameTextBox.Text); // creates new episode

                            await Task.Run(() => superController.Update(alist[i].Name, ep));//seralizes the new episode
                        }
                    }
                }
                FillCategorylist();
                FillFeedList();
            }
            catch { }
        }

        private async Task UppdateCategoryAsync(string cat, string newCat)
        {
            List<Super> alist = new List<Super>();

            alist = await Task.Run(() => superController.GetAllSuper());

            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].Name == cat) // uppdates the new category
                {
                    Categories cate = new Categories(newCat);
                    await superController.Update(alist[i].Name, cate);
                }
                if (alist[i].DataType == "Feed") // uppdates category field on feed object
                {
                    Feed f = (Feed)alist[i];
                    if (f.category == cat)
                    {

                        Feed fe = new Feed(f.Name, f.frekvens, f.URL, newCat);
                        await superController.Update(alist[i].Name, fe);
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
            alist = await Task.Run(() => superController.GetAllSuper());
            for (int i = 0; i < alist.Count; i++)
            {
                if (alist[i].DataType == "Feed")
                {
                    string name = alist[i].Name;
                    if (name == dataCellItem) // checks if it is the right feed to delete
                    {

                        for (int x = 0; x < alist.Count; x++) // deletes all of its episodes
                        {
                            if (alist[x].DataType == "Episode")
                            {
                                Episode epi = (Episode)alist[x];
                                if (epi.pod == name)
                                {
                                    await superController.DeleteAsync(epi.Name);
                                }
                            }
                        }
                        await superController.DeleteAsync(name); // deletes feed
                    }
                }
            }
        }

        private async Task episodeListPerPodcastAsync()
        {

            List<Super> aList = new List<Super>();
            string dataCellItem = dataGridView1.CurrentCell.Value.ToString();

            aList = await Task.Run(() => superController.GetAllSuper());
            foreach (var v in aList.Where(v => v.DataType == "Episode"))
            {
                Episode obj = (Episode)v;
                if (obj.pod == dataCellItem) // check if the episodes belongs to the right feed
                {

                    PlaceholderPod.Items.Add(obj.Name);
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
                aList = await Task.Run(() => superController.GetAllSuper());
                foreach (Super v in aList)
                {
                    if (v.DataType == "Episode")
                    {
                        Episode obj = (Episode)v;
                        if (obj.Name == selectedItem)
                        {
                            episodeDescriptionLabel.Text = obj.Display(); // runs episode method to display the description
                            description.Text = obj.description;
                        }
                    }
                }
            }
        }

        private void PlaceholderCategory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string cat = PlaceholderCategory.SelectedItem.ToString();
            FeedListaByCategory(cat);
        }

        private async void SaveCategoryButton_Click(object sender, EventArgs e)
        {
            if (exception.textCheck(CreateCategoryTextBox.Text)) // checks if the textfield is empty
            {
                string cat = PlaceholderCategory.SelectedItem.ToString();
                string newCat = CreateCategoryTextBox.Text;
                await UppdateCategoryAsync(cat, newCat);
                FillCategorylist();
                FillFeedList();
            }
            else
            {
                MessageBox.Show("You need fill in the category field");
            }
        }

        private async void SavePodButton_Click(object sender, EventArgs e)
        {
            try
            {
                // checks if all the fields is empty
                if (exception.textCheck(URLTextBox.Text) && FrequencyComboBox.SelectedItem != null && CategoryComboBox.SelectedItem != null && exception.textCheck(NameTextBox.Text))
                {
                    await UppdateFeedAsync(dataGridView1.CurrentCell.Value.ToString());
                }
                else
                {
                    throw new EmptyStringException();
                }
            }
            catch (EmptyStringException ex)
            {
                MessageBox.Show(ex.Message); //show message if any of the text fields is empty
            }

        }

        private async void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // fill feed textfields on  double click 
            List<Super> aList = new List<Super>();
            string selectedItem = dataGridView1.CurrentCell.Value.ToString();
            aList = await Task.Run(() => superController.GetAllSuper());
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
