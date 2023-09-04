using System;
using System.Collections.Generic;
using System.Text;

namespace JQuery.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();
       
    
    }
}
