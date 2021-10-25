using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataAccessLayer.Repositories
{
    public class SuperRepository : IRepository<Super>
    {

        private DataManager dataManager;

        List<Super> Super;

        public SuperRepository()
        {
            dataManager = new DataManager();
            Super = new List<Super>();
        }

        public void Create(Super entity)
        {
            Super.Add(entity);
            SaveChanges();
        }

        
        public Super FindByID(int id)
        {
            return Super[id];
        }
        public void Update(int index, Super entity)
        {
            if (index >= 0 && index < Super.Count - 1)
            {
                Super[index] = entity;
                SaveChanges();
            }    
        }
        
        public List<Super> GetAll()
        {
            List<Super> tempCategories = new List<Super>();
            try
            {
                tempCategories = dataManager.Deserialize();
            }
            catch (Exception)
            {
                
            }
            return tempCategories;
        }
        public void Delete(int index)
        {
            Super.RemoveAt(index);
            SaveChanges();
        }
        public void SaveChanges()
        {
            dataManager.Serialize(Super);
        }
    }
}
