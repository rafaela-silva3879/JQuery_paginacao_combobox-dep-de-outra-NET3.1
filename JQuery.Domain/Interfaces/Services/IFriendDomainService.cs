using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;
namespace JQuery.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para definir métodos de serviço de dominio para cliente
    /// </summary>
    public interface IFriendDomainService : IBaseDomainService<Friend>
    {
        List<Friend> GetByDataCadastro(DateTime dataMin, DateTime dataMax);
        Friend GetById(Guid id);
        List<Friend> GetByStateId(int idState);
    }
}
