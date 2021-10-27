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
        IRepository<Feed> FeedRepository;

        public SuperController()
        {
            SuperRepository = new SuperRepository();
            FeedRepository = new FeedRepository();
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

        public List<Feed> Feedlist()
        {
            //List<Super> list = new List<Super>();
            //List<Feed> listc = new List<Feed>();
            ////list.AddRange(from Super obj in GetAllSuper()
            ////              where obj.DataType == "Feed"
            ////              select obj);

            //foreach (Super obj in list)
            //{

            //    if(obj.DataType == "Feed")
            //    {
            //        List<string> listObj = new List<string>();
            //        listObj = obj.Value();
            //        Feed x = new Feed(listObj[0], listObj[1], listObj[2], listObj[3]);
            //        listc.Add(x);
            //    }
            //}
            //return listc;
            List<Feed> list = new List<Feed>();
            list = FeedRepository.GetAll();
            // returns a list of the dataType Category, using LINQ
            return list;
        }

        //private List<Feed>

        //public string GetPoddDetailsByCategory(string kategori)
        //{
        //    return SuperRepository.GetByKategori(kategori).Display();
        //}
    } 
}
//public List<Super> Feedlist()
//{
//    List<Super> list = new List<Super>();
//    List<Super> listc = new List<Super>();
//    list = GetAllSuper();
//    foreach (Super obj in list)
//    {
//        if (obj.DataType == "Feed")
//        {
//            listc.Add(obj);
//        }
//    }
//    return listc;
//}