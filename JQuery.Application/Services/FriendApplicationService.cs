using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JQuery.Application.Interfaces;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Services;

namespace JQuery.Application.Services
{
    public class FriendApplicationService : IFriendApplicationService
    {
        //atributo
        private readonly IFriendDomainService _frienddomainservice;
        private readonly IStateDomainService _statedomainservice;

        //construtor para inicialização do atributo (injeção de dependência)
        public FriendApplicationService(IFriendDomainService frienddomainservice, IStateDomainService stateDomainService)
        {
            _frienddomainservice = frienddomainservice;
            _statedomainservice = stateDomainService;
        }

        public void Create(Friend friend)
        {
            try
            {
                _frienddomainservice.Create(friend);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Delete(Friend obj)
        {
            var friend = _frienddomainservice.GetById(obj.IdFriend);
            _frienddomainservice.Delete(friend);
        }

        public List<Friend> GetAll()
        {
            var friends = new List<Friend>();

            foreach (var item in _frienddomainservice.GetAll())
            {
                var f = new Friend();

                f.IdFriend = item.IdFriend;
                f.FriendName = item.FriendName;
                f.Phone = item.Phone;
                f.IdState = item.IdState;
                f.DataCadastro = item.DataCadastro;

                friends.Add(f);
            }

            return friends;
        }

        public List<Friend> GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            var friends = new List<Friend>();
            try
            {
                var dados = _frienddomainservice.GetByDataCadastro(dataMin, dataMax).ToList();
                foreach (var item in dados)
                {
                    var f = new Friend();

                    f.IdFriend = item.IdFriend;
                    f.FriendName = item.FriendName;
                    f.Phone = item.Phone;
                    f.IdState = item.IdState;
                    f.DataCadastro = item.DataCadastro;
                    // f.State.StateAcronym = _statedomainservice.GetById(item.IdState).StateAcronym;  
                    f.State = new State();

                    f.State.StateAcronym= item.State.StateAcronym;
                    friends.Add(f);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return friends;
        }

        public Friend GetById(Guid id)
        {
            var friend = _frienddomainservice.GetById(id);

            return friend;
        }



        public void Update(Friend obj)
        {
            try
            {
                var friend = _frienddomainservice.GetById(obj.IdFriend);

                friend.FriendName = obj.FriendName;
                friend.Phone = obj.Phone;
                friend.IdState = obj.IdState;

                _frienddomainservice.Update(friend);
            }
            catch (Exception)
            {

                throw;
            }
       
        }
        public List<Friend> GetByStateId(int idState)
        {
            try
            {
               return _frienddomainservice.GetByStateId(idState);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
