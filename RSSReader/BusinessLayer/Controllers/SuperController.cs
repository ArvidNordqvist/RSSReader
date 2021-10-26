using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using Models;
using System.Windows;

namespace BusinessLayer.Controllers
{
    public class SuperController
    {
        IRepository<Super> SuperRepository;
        List<Categories> category;

        public SuperController()
        {
            SuperRepository = new SuperRepository();
            category = new List<Categories>();
        }
        public void CreateCategory(string name)
        {
            Categories newCategory = new Categories(name);
            addCategory(newCategory);
            SuperRepository.Create(newCategory);
        }

        public void addCategory(Categories newCategory)
        {
            category.Add(newCategory);
        }

        public List<Categories> getCategory()
        {
            
            return category;
        }

        //public List<Podd> GetAllPodds()
        //{
        //    return poddRepository.GetAll();
        //}

        //public string GetPoddDetailsByName(string name)
        //{
        //    //
        //    return poddRepository.GetByName(name).Display()
        //}

        //public void DeletePodd(string name)
        //{
        //    int index = poddRepository.GetIndex(name);
        //    poddRepository.Delete(index);
        //}

        //public string GetPoddDetailsByAddress(string kategori)
        //{
        //    return poddRepository.GetByKategori(kategori).Display();
        //}
    }
}
