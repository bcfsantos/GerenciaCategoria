using Cadastro.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Cadastro.Infra.EntityConfig
{
    public class TipoConfig : EntityTypeConfiguration<Tipo>
    {

        public TipoConfig()
        {
            HasKey(c => c.IdTipo);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            Ignore(x => x.IdCampo);

            HasMany(c => c.Campos)
                .WithRequired(c => c.Tipo)
                .HasForeignKey(c => c.IdTipo);

        }

    }
}
