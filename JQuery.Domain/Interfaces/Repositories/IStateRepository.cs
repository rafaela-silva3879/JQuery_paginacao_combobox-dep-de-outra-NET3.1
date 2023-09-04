using JQuery.Domain.Entities;
using System;
using System.Collections.Generic;

namespace JQuery.Domain.Interfaces.Repositories
{
    public interface IStateRepository : IBaseRepository<State>
    {
        State GetById(int id);
    }
}
