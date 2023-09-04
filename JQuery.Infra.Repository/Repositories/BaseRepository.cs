using Microsoft.EntityFrameworkCore;
using JQuery.Domain.Interfaces.Repositories;
using JQuery.Infra.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQuery.Infra.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
            where T : class
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para inicialização do atributo (injeção de dependência)
        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Create(T obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(T obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

 

 
    }
}
