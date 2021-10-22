using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : IRepository<Categories>
    {

        private DataManager dataManager;

        List<Categories> categories;

        public CategoryRepository()
        {
            dataManager = new DataManager();
            categories = new List<Categories>();
        }

        public void Create(Categories entity)
        {
            categories.Add(entity);
            SaveChanges();
        }

        
        public Categories FindByID(int id)
        {
            return categories[id];
        }
        public void Update(int index, Categories entity)
        {
            if (index >= 0 && index < categories.Count - 1)
            {
                categories[index] = entity;
                SaveChanges();
            }    
        }
        
        public List<Categories> GetAll()
        {
            List<Categories> tempCategories = new List<Categories>();
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
            categories.RemoveAt(index);
            SaveChanges();
        }
        public void SaveChanges()
        {
            dataManager.Serialize(categories);
        }
    }
}
