using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Funcionario : Base
    {
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [MaxLength(200)]
        public string Nome { get; set; }
        [MaxLength(12)]
        public string Cpf { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }
        public virtual List<Telefone> Telefones { get; set; }
    }
}
