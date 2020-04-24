using Rede.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teste.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Amigo> Amigos { get; set; }
        public List<Post> Posts { get; set; }
    }
}

