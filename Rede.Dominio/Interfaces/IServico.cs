using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;

namespace Teste.Dominio.Interfaces
{
    public interface IServico<T> where T : EntidadeBase
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        void Delete(int id);

        T Get(int id);

        IList<T> Get();
    }
}
