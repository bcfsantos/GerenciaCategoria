using Cadastro.Domain.Entities;
using Cadastro.Infra.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Cadastro.Infra.Context
{
    public class TesteContext : DbContext
    {
        public TesteContext()
            : base("TesteContext")
        {

        }
        public DbSet<Cadastro.Domain.Entities.Categoria> Clientes { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Campo> Campos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CategoriaConfig());
            modelBuilder.Configurations.Add(new SubCategoriaConfig());
            modelBuilder.Configurations.Add(new CampoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
