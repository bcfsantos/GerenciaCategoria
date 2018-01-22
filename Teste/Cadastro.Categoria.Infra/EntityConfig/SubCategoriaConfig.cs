using System.Data.Entity.ModelConfiguration;

namespace Cadastro.Infra.EntityConfig
{
    public class SubCategoriaConfig : EntityTypeConfiguration<Cadastro.Domain.Entities.SubCategoria>
    {
        public SubCategoriaConfig()
        {
            HasKey(c => c.IdSubCategoria);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(50);

            this.HasRequired(t => t.Categoria)
                .WithMany(t => t.SubCategoria)
                .HasForeignKey(d => d.IdCategoria);
        }
    }
}
