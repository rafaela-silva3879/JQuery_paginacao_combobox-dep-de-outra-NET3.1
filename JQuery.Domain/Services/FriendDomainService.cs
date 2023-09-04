using System;
using System.Collections.Generic;
using System.Text;
using JQuery.Domain.Entities;
using JQuery.Domain.Interfaces.Repositories;
using JQuery.Domain.Interfaces.Services;
namespace JQuery.Domain.Services
{
    public class FriendDomainService : BaseDomainService<Friend>, IFriendDomainService
    {
        //atributo
        private readonly IFriendRepository _Friendrepository;

        //construtor para inicializar o atributo (injeção de dependência)
        public FriendDomainService(IFriendRepository Friendrepository) : base(Friendrepository)
        {
            _Friendrepository = Friendrepository;
        }

        public virtual Friend GetById(Guid id)
        {
            return _Friendrepository.GetById(id);
        }

        //Sobrescrever o método Create
        public override void Create(Friend obj)
        {
            try
            {
                #region Não é permitido gravar Friend com o mesmo nome

                if (_Friendrepository.GetByFriendName(obj.FriendName) != null)
                    throw new ArgumentException("O nome informado já está cadastrado, tente outro.");

                #endregion

                #region Não é permitido gravar Friend com o mesmo telefone

                if (_Friendrepository.GetByPhone(obj.Phone) != null)
                    throw new ArgumentException("O telefone informado já está cadastrado, tente outro.");

                // Cadastrar o Cliente

                obj.IdFriend = Guid.NewGuid();
                obj.DataCadastro = DateTime.Now;
                _Friendrepository.Create(obj);
            }
            catch (Exception)
            {

                throw;
            }


            #endregion
        }

        //Sobrescrita do método Update
        public override void Update(Friend obj)
        {
            Friend Friend;

            #region Não é permitido alterar o nome do amigo utilizando um nome já cadastrado para outro amigo

            Friend = _Friendrepository.GetByFriendName(obj.FriendName);

            if (Friend != null && Friend.FriendName == obj.FriendName && Friend.IdFriend != obj.IdFriend)
                throw new ArgumentException("O nome informado já está cadastrado para outro amigo.");

            #endregion

            #region Não é permitido alterar o telefone do amigo utilizando um telefone já cadastrado para outro amigo

            Friend = _Friendrepository.GetByPhone(obj.Phone);

            if (Friend != null && Friend.Phone == obj.Phone && Friend.IdFriend != obj.IdFriend)
                throw new ArgumentException("O telefone informado já está cadastrado para outro amigo.");

            #endregion

            #region Atualizar o Friend

            _Friendrepository.Update(obj);

            #endregion
        }

        //Consultar os Friends cadastrados dentro do periodo de datas
        public List<Friend> GetByDataCadastro(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                #region A data inicial deve ser menor ou igual a data final

                if (dataMin > dataMax)
                    throw new ArgumentException("A data de início deve ser menor ou igual a data de término.");

                #endregion

                #region Executar a consulta e retornar os dados

                return _Friendrepository.GetByDataCadastro(dataMin, dataMax);

                #endregion
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
                return _Friendrepository.GetByStateId(idState);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
