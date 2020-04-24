using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teste.Dominio.Entidades;
using Teste.Infra.Data;
using Teste.Infra.Data.Contexto;

namespace Teste.Servico.Validacoes
{
    public class UsuarioValidador :AbstractValidator<Usuario>
    {
        private readonly IEnumerable<Usuario> _usuario;

        public UsuarioValidador()
        {

            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não foi possível encontrar o usuário");
                });

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .NotNull().WithMessage("Senha é obrigatória");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .NotNull().WithMessage("Email é obrigatório")
                .Must(IsEmailUnique).WithMessage("Esse email já está sendo usado");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .NotNull().WithMessage("Nome é obrigatório");
        }

        public bool IsEmailUnique(string email)
        {
            MySqlContext db = new MySqlContext();
            var emailVal = db.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).SingleOrDefault();

            if (emailVal == null) 
                return true;

            return false;
        }
    }
}
