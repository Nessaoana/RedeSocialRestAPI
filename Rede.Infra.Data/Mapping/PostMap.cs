using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rede.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rede.Infra.Data.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Titulo).IsRequired().HasColumnName("Titulo").HasMaxLength(20);
            builder.Property(c => c.Texto).IsRequired().HasColumnName("Texto");
            builder.Property(c => c.Data).IsRequired().HasColumnName("Data_publicacao");
        }
    }
}
