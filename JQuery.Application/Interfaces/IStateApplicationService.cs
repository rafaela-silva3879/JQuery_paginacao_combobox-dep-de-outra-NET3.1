using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;

namespace JQuery.Application.Interfaces
{
    public interface IStateApplicationService : IBaseApplicationService<State>
    {
        State GetById(int id);
    }
}
