using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Endereco : Base
    {
        public int? FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int? EmpresaClienteId { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        [MaxLength(50)]
        public string Pais_end { get; set; }
        [MaxLength(50)]
        public string Estado_end { get; set; }
        [MaxLength(50)]
        public string Cidade_end { get; set; }
        [MaxLength(50)]
        public string Bairro_end { get; set; }
        [MaxLength(50)]
        public string Rua_end { get; set; }
        [MaxLength(10)]
        public string Numero_end { get; set; }
        [MaxLength(8)]
        public string Cep_end { get; set; }
    }
}
