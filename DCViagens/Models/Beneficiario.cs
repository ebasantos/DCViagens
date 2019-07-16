using System;
using System.ComponentModel.DataAnnotations;

namespace DCViagens.Models
{
    public class Beneficiario : Pessoa
    {
        public DateTime DataNascimento { get; set; }
        public string EstadoCivil { get; set; }
        public string NomeMae { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public int ColaboradorId { get; set; }

    }
}