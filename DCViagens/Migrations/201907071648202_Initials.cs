namespace DCViagens.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beneficiarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataNascimento = c.DateTime(nullable: false),
                        EstadoCivil = c.String(),
                        NomeMae = c.String(),
                        CPF = c.String(),
                        Endereco = c.String(),
                        Email = c.String(),
                        ColaboradorId = c.Int(nullable: false),
                        Nome = c.String(),
                        Fone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cadastroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CIF = c.Int(nullable: false),
                        Senha = c.String(),
                        DataCadastro = c.DateTime(nullable: false),
                        BeneficiarioId = c.Int(nullable: false),
                        VendedorId = c.Int(nullable: false),
                        ColaboradorId = c.Int(nullable: false),
                        ParceiroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beneficiarios", t => t.BeneficiarioId, cascadeDelete: true)
                .ForeignKey("dbo.Colaboradors", t => t.ColaboradorId, cascadeDelete: true)
                .ForeignKey("dbo.Parceiroes", t => t.ParceiroId, cascadeDelete: true)
                .ForeignKey("dbo.Vendedors", t => t.VendedorId, cascadeDelete: true)
                .Index(t => t.BeneficiarioId)
                .Index(t => t.VendedorId)
                .Index(t => t.ColaboradorId)
                .Index(t => t.ParceiroId);
            
            CreateTable(
                "dbo.Colaboradors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataAdmissao = c.DateTime(nullable: false),
                        CIF = c.Int(nullable: false),
                        Senha = c.String(),
                        Nome = c.String(),
                        Fone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parceiroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Fone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Fone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cadastroes", "VendedorId", "dbo.Vendedors");
            DropForeignKey("dbo.Cadastroes", "ParceiroId", "dbo.Parceiroes");
            DropForeignKey("dbo.Cadastroes", "ColaboradorId", "dbo.Colaboradors");
            DropForeignKey("dbo.Cadastroes", "BeneficiarioId", "dbo.Beneficiarios");
            DropIndex("dbo.Cadastroes", new[] { "ParceiroId" });
            DropIndex("dbo.Cadastroes", new[] { "ColaboradorId" });
            DropIndex("dbo.Cadastroes", new[] { "VendedorId" });
            DropIndex("dbo.Cadastroes", new[] { "BeneficiarioId" });
            DropTable("dbo.Vendedors");
            DropTable("dbo.Parceiroes");
            DropTable("dbo.Colaboradors");
            DropTable("dbo.Cadastroes");
            DropTable("dbo.Beneficiarios");
        }
    }
}
