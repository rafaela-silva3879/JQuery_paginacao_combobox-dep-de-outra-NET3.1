using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;
namespace JQuery.Application.Interfaces
{
    public interface IFriendApplicationService : IBaseApplicationService<Friend>
    {       
        List<Friend> GetByDataCadastro(DateTime dataMin, DateTime dataMax);
        Friend GetById(Guid id);
        List<Friend> GetByStateId(int idState);
    }
}
