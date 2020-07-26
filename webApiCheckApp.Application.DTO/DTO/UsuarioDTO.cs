using System;
using System.Collections.Generic;
using System.Text;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class UsuarioDTO : BaseDTO
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string perfil { get; set; }
    }
}
