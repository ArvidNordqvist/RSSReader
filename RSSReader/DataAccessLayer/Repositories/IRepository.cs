using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        
        void Update(int index, T entity);
        void Delete(int index);
        void SaveChanges();
        List<T> GetAll();

        public int GetIndex(String name);
    }
}
