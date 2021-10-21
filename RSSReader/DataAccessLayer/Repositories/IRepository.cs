using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
        void create(T entity);
        T FindByID(int id);
        void Update(int index, T entity);
        void Delete(int index);
        void SaveChanges();
        List<T> GetAll();
    }
}
