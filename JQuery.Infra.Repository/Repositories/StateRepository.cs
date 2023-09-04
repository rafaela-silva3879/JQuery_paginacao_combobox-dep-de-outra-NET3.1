using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Repositories;
using JQuery.Infra.Repository.Contexts;
using System.Linq;
namespace JQuery.Infra.Repository.Repositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        private readonly SqlServerContext _context;

        //construtor para inicializar o atributo por meio de injeção de dependência
        public StateRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public State GetById(int id)
        {
            return _context.Set<State>().Find(id);
        }
    }
}
