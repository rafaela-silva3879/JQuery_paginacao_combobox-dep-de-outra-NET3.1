using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;
namespace JQuery.Domain.Interfaces.Services
{
    public interface IStateDomainService : IBaseDomainService<State>
    {
        State GetById(int id);
    }
}
