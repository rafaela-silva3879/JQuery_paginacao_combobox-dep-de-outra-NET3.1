using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Application.Interfaces;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Services;

namespace JQuery.Application.Services
{
    public class StateApplicationService : IStateApplicationService
    {
        //atributo
        private readonly IStateDomainService _statedomainservice;

        //construtor para inicialização do atributo (injeção de dependência)
        public StateApplicationService(IStateDomainService statedomainservice)
        {
            _statedomainservice = statedomainservice;
        }

        public void Create(State state)
        {
            try
            {
                _statedomainservice.Create(state);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(State obj)
        {
            var state = _statedomainservice.GetById(obj.IdState);
            _statedomainservice.Delete(state);
        }

        public List<State> GetAll()
        {
            var states = new List<State>();

            foreach (var item in _statedomainservice.GetAll())
            {
                var s = new State();

                s.IdState = item.IdState;
                s.StateAcronym = item.StateAcronym;

                states.Add(s);
            }

            return states;
        }



        public State GetById(int id)
        {
            var state = _statedomainservice.GetById(id);

            return state;
        }

        public void Update(State obj)
        {
            try
            {
                var state = _statedomainservice.GetById(obj.IdState);

                state.StateAcronym = obj.StateAcronym;
           

                _statedomainservice.Update(state);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
