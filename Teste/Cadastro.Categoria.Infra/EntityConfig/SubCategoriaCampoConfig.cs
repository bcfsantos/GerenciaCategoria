using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.EntityConfig
{
  public  class SubCategoriaCampoConfig : EntityTypeConfiguration<SubCategoriaCampo>
    {
        public SubCategoriaCampoConfig()
        {
            this.HasKey(t => new { t.IdSubCategoria, t.IdCampo, t.Ordem });

            Property(t => t.IdSubCategoria);

            Property(t => t.IdCampo);

            Property(t => t.Ordem);

            this.HasRequired(t => t.Campo)
                .WithMany(t => t.SubCategoriaCampos)
                .HasForeignKey(d => d.IdCampo);
            this.HasRequired(t => t.SubCategoria)
                .WithMany(t => t.SubCategoriaCampos)
                .HasForeignKey(d => d.IdSubCategoria);
        }
    }
}
