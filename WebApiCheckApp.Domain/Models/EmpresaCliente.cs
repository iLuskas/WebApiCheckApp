﻿using System;
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

        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }
    }
}