using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DataAccessLayer.Repositories
{
    public interface IFeedRepository<T> : IRepository<T> where T : Feed
    {
        
    }
}
