using JQuery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQuery.Domain.Interfaces.Repositories
{

    public interface IFriendRepository : IBaseRepository<Friend>
    {
        Friend GetByFriendName(string FriendName);
        Friend GetByPhone(string Phone);

        List<Friend> GetByDataCadastro(DateTime dataMin, DateTime dataMax);
        Friend GetById(Guid id);

        List<Friend> GetByStateId(int idState);
    }
}
