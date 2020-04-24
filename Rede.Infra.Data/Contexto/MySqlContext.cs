using Microsoft.EntityFrameworkCore;
using Rede.Dominio.Entidades;
using Rede.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;
using Teste.Infra.Data.Mapping;

namespace Teste.Infra.Data.Contexto
{
	public class MySqlContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Amigo> Amigos { get; set; }
		public DbSet<Post> Posts { get; set; }
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=RedeSocial;Uid=root;Pwd=1234");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
			modelBuilder.Entity<Usuario>().HasIndex(c => c.Email).IsUnique();
			modelBuilder.Entity<Amigo>(new AmigoMap().Configure);
			modelBuilder.Entity<Post>(new PostMap().Configure);
		}
	}
}
