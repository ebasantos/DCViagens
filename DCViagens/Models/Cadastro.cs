using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCViagens.Models
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }
        public int CIF { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public Colaborador Colaborador { get; set; }
        public Beneficiario Beneficiario { get; set; }
        public Parceiro Parceiro { get; set; }
        public Vendedor Vendedor { get; set; }
        public int BeneficiarioId { get; set; }
        public int VendedorId { get; set; }
        public int ColaboradorId { get; set; }
        public int ParceiroId { get; set; }
    }
}