using System;
using System.Collections.Generic;
using System.Text;

namespace JQuery.Domain.Entities
{
    public class Friend
    {
        public Guid IdFriend { get; set; }
        public string FriendName { get; set; }
        public string Phone { get; set; }
        public DateTime DataCadastro { get; set; }

        #region relacionamentos
        public int IdState { get; set; }
        public State State { get; set; } 
        #endregion
    }
}
