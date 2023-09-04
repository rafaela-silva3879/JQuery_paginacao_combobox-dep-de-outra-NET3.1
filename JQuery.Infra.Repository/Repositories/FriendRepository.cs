using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Repositories;
using JQuery.Infra.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
namespace JQuery.Infra.Repository.Repositories
{
    public class FriendRepository : BaseRepository<Friend>, IFriendRepository
    {
        private readonly SqlServerContext _context;

        //construtor para inicializar o atributo por meio de injeção de dependência
        public FriendRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Friend GetById(Guid id)
        {
            return _context.Set<Friend>()
               .Include(f => f.State)  // Incluir a entidade State relacionada
               .FirstOrDefault(f => f.IdFriend == id);
        }


        public Friend GetByFriendName(string FriendName)
        {
            return _context.Friend
                .FirstOrDefault(f => f.FriendName.Equals(FriendName));
        }

        public Friend GetByPhone(string Phone)
        {
            return _context.Friend
                .FirstOrDefault(f => f.Phone.Equals(Phone));
        }



        public List<Friend> GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            
            var friends= _context.Friend
                .Include(f => f.State)
                .Where(f => f.DataCadastro >= dataMin && f.DataCadastro <= dataMax)
                .OrderBy(f => f.DataCadastro)
                .ToList();
            return friends;
        }

        public List<Friend> GetByStateId(int idState) 
        {
            var friends = _context.Friend
                .Where(f=>f.IdState==idState)
                .OrderBy(f=>f.FriendName) 
                .ToList();
            return friends;
        }


    }
}
