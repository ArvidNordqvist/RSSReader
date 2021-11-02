using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using Models;
using System.Linq;
using System.Timers;
using System.Threading.Tasks;
using System.ServiceModel.Syndication;
using System.Xml;

namespace BusinessLayer.Controllers
{
    public class SuperController
    {
        IRepository<Super> SuperRepository; //gets a IRepository Variable with the type of Super
        
        public SuperController()
        {
            SuperRepository = new SuperRepository(); //Instansiates the IRepository pattern.
        }
        public async Task CreateCategoryAsync(string name)
        {
            //creates a category from an input.
            Categories newCategory = new Categories(name);
            //puts the newly created category in the Super list that xml serializes.
            await Task.Run(() => SuperRepository.Create(newCategory));
        }

        public async Task CreateFeedAsync(string name, double frekvens, string URL, string Category)
        {
            //creates a feed based on the input.
            Feed newFeed = new Feed(name, frekvens, URL, Category);
            //puts it in the Super list that serializes.
            await Task.Run(() => SuperRepository.Create(newFeed));
        }

        public List<Super> GetAllSuper() //Method to retrieve a List of all Supers so that it can be iterated.
        {
            return SuperRepository.GetAll();
        }

        public async Task CreateEpisodeAsync(string name, string description, string pod)
        {
            //creates an episode based on input.
            Episode newEpisode = new Episode(name, description, pod);
            //Puts the newly created episode in the Super List.
            await Task.Run(() => SuperRepository.Create(newEpisode));
        }

        public async Task Update(string name, Super x)
        {
            //gets and updates the index of the Super list with the new Super object based on object name.
            int index = await Task.Run(() => SuperRepository.GetIndex(name));
            await Task.Run(() => SuperRepository.Update(index, x));
        }

        public async Task DeleteAsync(string name)
        {
            //gets and deletes the choosen index based on object name.
            int index = await Task.Run(() => SuperRepository.GetIndex(name));
            await Task.Run(() => SuperRepository.Delete(index));


        }

        public List<string> Categorylist()
        {
            //retrieves a string List of categories to later be itterated.
            List<Super> list = new List<Super>();
            List<string> listc = new List<string>();
            list = GetAllSuper();
            listc.AddRange(from Super obj in list
                           where obj.DataType == "Category"
                           select obj.Name);
            // returns a list of the dataType Category, using LINQ
            return listc;
        }

        public List<Super> FeedList()
        {
            //retrieves a Super List of feeds.
            List<Super> list = new List<Super>();
            List<Super> listf = new List<Super>();
            list = GetAllSuper();
            listf.AddRange(from Super obj in list
                           where obj.DataType == "Feed"
                           select obj);
            // returns a list of the dataType Feed, using LINQ
            return listf;
        }

    }
}
