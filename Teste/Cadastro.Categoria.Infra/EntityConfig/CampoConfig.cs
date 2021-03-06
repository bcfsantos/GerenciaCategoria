﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.Infra.EntityConfig
{
    public class CampoConfig : EntityTypeConfiguration<Cadastro.Domain.Entities.Campo>
    {
        public CampoConfig()
        {
            HasKey(c => c.IdCampo);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Lista)
               .HasMaxLength(150);

            this.HasRequired(t => t.Tipo)
                .WithMany(t => t.Campos)
                .HasForeignKey(d => d.IdTipo);




        }
    }
}
