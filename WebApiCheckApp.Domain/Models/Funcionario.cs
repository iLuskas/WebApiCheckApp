using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Funcionario : Base
    {
        public int idPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
