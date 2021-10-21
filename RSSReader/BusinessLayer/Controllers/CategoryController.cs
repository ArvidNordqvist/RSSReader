using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Repositories;
using Models;

namespace BusinessLayer.Controllers
{
    public class CategoryController
    {
        IRepository<Categories> categoryRepository;

        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }
        public void CreateCategory(string name)
        {
            Categories newCategory = new Categories(name);

            categoryRepository.create(newCategory);
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
