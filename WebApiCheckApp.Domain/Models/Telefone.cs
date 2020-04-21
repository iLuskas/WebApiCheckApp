using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Telefone : Base
    {
        public int? FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int? EmpresaClienteId { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        public string ddd_tel { get; set; }
        public string Telefone_tel { get; set; }
        public string Tipo_tel { get; set; }
        public int Status_tel { get; set; }
        public int Percentual_tel { get; set; }
    }
}
