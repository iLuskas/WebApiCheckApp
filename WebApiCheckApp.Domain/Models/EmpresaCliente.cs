using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class EmpresaCliente : Base
    {
        [MaxLength(255)]
        public string RazaoSocial { get; set; }
        [MaxLength(14)]
        public string Cnpj { get; set; }
        [MaxLength(14)]
        public string Inscricao_estadual { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }
        public virtual List<Telefone> Telefones { get; set; }
        public virtual List<Equipamento_Seguranca> Equipamentos { get; set;}
    }
}
