using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Perfil : Base
    {
        [MaxLength(50)]
        public string Funcao_perfil { get; set; }
    }
}
