using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DCViagens.Models
{
    public class DCViagensContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DCViagensContext() : base("name=DCViagensContext")
        {
        }

        public System.Data.Entity.DbSet<DCViagens.Models.Beneficiario> Beneficiarios { get; set; }

        public System.Data.Entity.DbSet<DCViagens.Models.Colaborador> Colaboradors { get; set; }

        public System.Data.Entity.DbSet<DCViagens.Models.Parceiro> Parceiroes { get; set; }

        public System.Data.Entity.DbSet<DCViagens.Models.Vendedor> Vendedors { get; set; }

        public System.Data.Entity.DbSet<DCViagens.Models.Cadastro> Cadastroes { get; set; }
    }
}
