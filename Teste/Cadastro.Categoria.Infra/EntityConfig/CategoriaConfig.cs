using System.Data.Entity.ModelConfiguration;

namespace Cadastro.Infra.EntityConfig
{
    public class CategoriaConfig : EntityTypeConfiguration<Cadastro.Domain.Entities.Categoria>
    {
        public CategoriaConfig()
        {
            HasKey(c => c.IdCategoria);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Slug)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
