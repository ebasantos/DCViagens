using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DCViagens.Models
{
    public class Colaborador : Pessoa
    {
        public DateTime DataAdmissao { get; set; }
        public int CIF { get; set; }
        public string Senha { get; set; }
       
    }
}