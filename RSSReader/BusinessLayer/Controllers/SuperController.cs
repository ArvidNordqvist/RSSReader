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
        IRepository<Super> SuperRepository;
        
        public SuperController()
        {
            SuperRepository = new SuperRepository();
        }
        public void CreateCategory(string name)
        {
            Categories newCategory = new Categories(name);

            SuperRepository.Create(newCategory);
        }

        public void CreateFeed(string name, double frekvens, string URL, string Category)
        {
            Feed newFeed = new Feed(name, frekvens, URL, Category);

            SuperRepository.Create(newFeed);
        }

        public List<Super> GetAllSuper()
        {
            return SuperRepository.GetAll();
        }

        public void CreateEpisode(string name, string description, string pod)
        {
            Episode newEpisode = new Episode(name, description, pod);

            SuperRepository.Create(newEpisode);
        }

        public void Update(string name, Super x)
        {
            int index = SuperRepository.GetIndex(name);
            SuperRepository.Update(index, x);
        }

        public void Delete(string name)
        {
            int index = SuperRepository.GetIndex(name);
            SuperRepository.Delete(index);


        }

        public List<string> Categorylist()
        {
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
