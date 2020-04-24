using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rede.Infra.Data.Mapping
{
    public class AmigoMap : IEntityTypeConfiguration<Amigo>
    {
        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            
            builder.ToTable("Amigo");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Data).IsRequired().HasColumnName("Data_amizade");
            builder.Property(c => c.UsuarioId).IsRequired().HasColumnName("Usuario");


        }

    }
}
