using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações
using JQuery.Domain.Entities;

namespace JQuery.Presentation.Models
{
    public class FriendSearchTableModel
    {
        //resultado da consulta feito no banco de dados para exibir na página
        public string IdFriend { get; set; }

        public string FriendName { get; set; }

        public string DataCadastro { get; set; }

        public string Phone { get; set; }

        public string IdState { get; set; }

        public string StateAcronym { get; set; }

    }
}
