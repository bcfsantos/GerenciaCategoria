namespace Cadastro.Categoria.Infra.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cadastro.Infra.Context.TesteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Cadastro.Infra.Context.TesteContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Tipos.AddOrUpdate(
                p => p.Descricao,
                new Tipo { Descricao = "TextBox" },
                new Tipo { Descricao = "TextArea" },
                new Tipo { Descricao = "CheckBox" },
                new Tipo { Descricao = "Inteiro" },
                new Tipo { Descricao = "Decimal" },
                new Tipo { Descricao = "DropDownList" }
                );
        }
    }
}
