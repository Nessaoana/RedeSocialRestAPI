using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Dominio.Entidades;
using Teste.Dominio.Interfaces;
using Teste.Infra.Data.Contexto;

namespace Teste.Infra.Data.Repositorio
{
    public class BaseRepositorio<T> : IRepositorio<T> where T : EntidadeBase
    {
		private readonly MySqlContext context = new MySqlContext();

		public void Insert(T obj)
		{
			context.Set<T>().Add(obj);
			context.SaveChanges();
		}

		public void Update(T obj)
		{
			context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}

		public void Remove(int id)
		{
			context.Set<T>().Remove(Select(id));
			context.SaveChanges();
		}

		public T Select(int id)
		{
			return context.Set<T>().Find(id);
		}

		public IList<T> SelectAll()
		{
			return context.Set<T>().ToList();
		}
	}
}
