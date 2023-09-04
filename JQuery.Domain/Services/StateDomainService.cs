using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Repositories;
using JQuery.Domain.Interfaces.Services;
namespace JQuery.Domain.Services
{
    public class StateDomainService : BaseDomainService<State>, IStateDomainService
    {
        //atributo
        private readonly IStateRepository _Staterepository;

        //construtor para inicializar o atributo (injeção de dependência)
        public StateDomainService(IStateRepository StateRepository) : base(StateRepository)
        {
            _Staterepository = StateRepository;
        }

        public virtual State GetById(int id)
        {
            return _Staterepository.GetById(id);
        }
    }
}
