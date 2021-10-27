using System;
using System.Collections.Generic;
using System.Text;
using DataAccesLayer;
using Models;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class SuperRepository : ISuperRepository<Super>
    {


        DataManager dataManager;
        List<Super> listOfSupers;
        public SuperRepository()
        {
            dataManager = new DataManager();
            listOfSupers = new List<Super>();
            listOfSupers = GetAll();
        }
        public void Create(Super entity)
        {
            listOfSupers.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            listOfSupers.RemoveAt(index);
            SaveChanges();
        }

        public List<Super> GetAll()
        {
            List<Super> listOfSuperDeserialized = new List<Super>();
            try
            {
                listOfSuperDeserialized = dataManager.Deserialize();
            }
            catch (Exception)
            {


            }

            return listOfSuperDeserialized;
        }




        public void SaveChanges()
        {
            dataManager.Serialize(listOfSupers);
        }

        public void Update(int index, Super entity)
        {
            if (index >= 0)
            {
                listOfSupers[index] = entity;
            }
            SaveChanges();
        }


        public Super GetByName(string name)
        {
            return GetAll().FirstOrDefault(p => p.Name.Equals(name));
        }



        public int GetIndex(string name)
        {
            return GetAll().FindIndex(e => e.Name.Equals(name));
        }

        //public List<Super> GetListOfSuperByCategory(string name)
        //{
        //    List<Super> list = new List<Super>();
        //    list = GetAll();
        //    list.Find(x => x.PartName.Contains("seat")));
        //    return GetAll().Contains();
        //}
    }
}
