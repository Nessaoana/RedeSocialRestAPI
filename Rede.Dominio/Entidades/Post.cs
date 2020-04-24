using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;

namespace Rede.Dominio.Entidades
{
    public class Post : EntidadeBase
    {
        public virtual Usuario Autor { get; set; }
        public int AutorId { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
    }
}
