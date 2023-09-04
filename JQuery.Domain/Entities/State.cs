using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JQuery.Domain.Entities
{
    public class State
    {
        public int IdState { get; set; }
        public string StateAcronym { get; set; }

        #region relacionamentos
        public List<Friend> Friends { get; set; }
        #endregion
    }
}
