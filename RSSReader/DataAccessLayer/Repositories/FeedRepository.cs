using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DataAccessLayer.Repositories
{
    public class FeedRepository : IFeedRepository<Feed>
    {
        DataManager dataManager;
        List<Feed> listOfFeeds;
        public FeedRepository()
        {
            dataManager = new DataManager();
            listOfFeeds = new List<Feed>();
            listOfFeeds = GetAll();
        }
        public List<Feed> GetAll()
        {
            List<Feed> listOfFeedDeserialized = new List<Feed>();
            try
            {
                listOfFeedDeserialized = dataManager.FeedDeserialize();
            }
            catch (Exception)
            {


            }
            return listOfFeedDeserialized;
        }

        public void Create(Feed entity)
        {
           
        }

        public void Delete(int index)
        {
            
        }

        

        public void SaveChanges()
        {
            
        }

        public void Update(int index, Feed entity)
        {
            if (index >= 0)
            {
                listOfFeeds[index] = entity;
            }
            SaveChanges();
        }
        public int GetIndex(string name)
        {
            return 0;
        }
    }
}

