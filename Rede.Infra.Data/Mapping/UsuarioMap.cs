using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;
using Rede.Dominio.Entidades;

namespace Teste.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuarios");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Email)
				.IsRequired()
				.HasColumnName("Email");

			builder.Property(c => c.Senha)
				.IsRequired()
				.HasColumnName("Senha");

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasColumnName("Name");

			builder.HasMany(c => c.Amigos).WithOne(c => c.Usuario).HasForeignKey(c => c.AmigoID);
			builder.HasMany(c => c.Posts).WithOne(c => c.Autor).HasForeignKey(c => c.AutorId);
		}
	}
}
