using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;
using Teste.Dominio.Interfaces;
using Teste.Infra.Data.Repositorio;

namespace Teste.Servico.Servicos
{
    public class BaseServico<T> : IServico<T> where T : EntidadeBase
    {
        private BaseRepositorio<T> repository = new BaseRepositorio<T>();

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Remove(id);
        }

        public IList<T> Get() => repository.SelectAll();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
