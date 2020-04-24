using System;
using System.Collections.Generic;
using System.Text;
using Teste.Dominio.Entidades;

namespace Rede.Dominio.Entidades
{
    public class Amigo : EntidadeBase
    {
        public DateTime Data { get; set; }
        public Usuario AmigoU { get; set; }
        public int AmigoID { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public String Status { get; set; }
    }
}
