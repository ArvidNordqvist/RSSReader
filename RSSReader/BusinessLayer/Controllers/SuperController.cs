using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using Models;

namespace BusinessLayer.Controllers
{
    public class SuperController
    {
        IRepository<Super> categoryRepository;

        public SuperController()
        {
            categoryRepository = new CategoryRepository();
        }
        public void CreateCategory(string name)
        {
            Categories newCategory = new Categories(name);

            categoryRepository.Create(newCategory);
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
