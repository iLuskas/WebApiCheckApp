﻿using System;
using System.Collections.Generic;
using System.Text;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class EmpresaClienteDTO : BaseDTO
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Inscricao_estadual { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemUrlBase64 { get; set; }
        public string Email { get; set; }
        public List<EnderecoDTO> enderecoDTOs { get; set; }
        public List<TelefoneDTO> telefoneDTOs { get; set; }
        public virtual List<Equipamento_SegurancaDTO> EquipamentosDTOs { get; set;}

    }
}
