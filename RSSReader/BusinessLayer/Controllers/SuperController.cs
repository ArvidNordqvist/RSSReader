using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using Models;
using System.Linq;

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

        public void CreateFeed(string name, string frekvens, string URL, string Category)
        {
            Feed newFeed = new Feed(name, frekvens, URL, Category);

            SuperRepository.Create(newFeed);
        }

        public List<Super> GetAllSuper()
        {
            return SuperRepository.GetAll();
        }

       



        //public string GetPoddDetailsByName(string name)
        //{
        //    //
        //    return SuperRepository.GetByName(name).Display()
        //}

        public void DeleteCategory(string name)
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

        

        //public string GetPoddDetailsByCategory(string kategori)
        //{
        //    return SuperRepository.GetByKategori(kategori).Display();
        //}
    }
}
