namespace Cadastro.Categoria.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campo",
                c => new
                    {
                        IdCampo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Tipo = c.String(nullable: false, maxLength: 25, unicode: false),
                        Lista = c.String(maxLength: 150, unicode: false),
                        IdSubCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCampo)
                .ForeignKey("dbo.SubCategoria", t => t.IdSubCategoria)
                .Index(t => t.IdSubCategoria);
            
            CreateTable(
                "dbo.SubCategoria",
                c => new
                    {
                        IdSubCategoria = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Slug = c.String(nullable: false, maxLength: 50, unicode: false),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSubCategoria)
                .ForeignKey("dbo.Categoria", t => t.IdCategoria)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Slug = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Campo", "IdSubCategoria", "dbo.SubCategoria");
            DropForeignKey("dbo.SubCategoria", "IdCategoria", "dbo.Categoria");
            DropIndex("dbo.SubCategoria", new[] { "IdCategoria" });
            DropIndex("dbo.Campo", new[] { "IdSubCategoria" });
            DropTable("dbo.Categoria");
            DropTable("dbo.SubCategoria");
            DropTable("dbo.Campo");
        }
    }
}
