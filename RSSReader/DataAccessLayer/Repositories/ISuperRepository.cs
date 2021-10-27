using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataAccessLayer.Repositories
{
    public interface ISuperRepository<T> : IRepository<T> where T : Super
    {
        T GetByName(string name);

        
        int GetIndex(string name);

    }
}
