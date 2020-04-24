using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;

namespace Teste.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : EntidadeBase
    {
        void Insert(T obj);

        void Update(T obj);

        void Remove(int id);

        T Select(int id);

        IList<T> SelectAll();
    }
}
