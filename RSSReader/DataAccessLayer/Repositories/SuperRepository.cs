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
        List<Super> listOfPersons;
        public SuperRepository()
        {
            dataManager = new DataManager();
            listOfPersons = new List<Super>();
            listOfPersons = GetAll();
        }
        public void Create(Super entity)
        {
            listOfPersons.Add(entity);
            SaveChanges();
        }

        public void Delete(int index)
        {
            listOfPersons.RemoveAt(index);
            SaveChanges();
        }

        public List<Super> GetAll()
        {
            List<Super> listOfPersonsDeserialized = new List<Super>();
            try
            {
                listOfPersonsDeserialized = dataManager.Deserialize();
            }
            catch (Exception)
            {


            }

            return listOfPersonsDeserialized;
        }



        public void SaveChanges()
        {
            dataManager.Serialize(listOfPersons);
        }

        public void Update(int index, Super entity)
        {
            if (index >= 0)
            {
                listOfPersons[index] = entity;
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
    }
}
