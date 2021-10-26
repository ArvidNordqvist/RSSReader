using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using Models;

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

        public List<Super> GetAllSuper()
        {
            return SuperRepository.GetAll();
        }

        //public string GetPoddDetailsByName(string name)
        //{
        //    //
        //    return SuperRepository.GetByName(name).Display()
        //}

        //public void DeletePodd(string name)
        //{
        //    int index = SuperRepository.GetIndex(name);
        //    SuperRepository.Delete(index);
        //}

        //public string GetPoddDetailsByAddress(string kategori)
        //{
        //    return SuperRepository.GetByKategori(kategori).Display();
        //}
    }
}
