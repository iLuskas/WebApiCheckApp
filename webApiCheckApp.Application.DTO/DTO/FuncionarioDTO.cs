using System;
using System.Collections.Generic;
using System.Text;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class FuncionarioDTO : BaseDTO
    {
        public int PerfilId { get; set; }
        public int? UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public virtual List<EnderecoDTO> enderecoDTOs { get; set; }
        public virtual List<TelefoneDTO> telefoneDTOs { get; set; }
    }
}
