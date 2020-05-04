using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Telefone : Base
    {
        public int? FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int? EmpresaClienteId { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        [MaxLength(3)]
        public string ddd_tel { get; set; }
        [MaxLength(9)]
        public string Telefone_tel { get; set; }
    }
}
