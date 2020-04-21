using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Log_Sessao : Base
    {
        public int IdUsuario { get; set; }  
        public virtual Usuario Usuario { get; set; }
        public DateTime Data_ini { get; set; }
        public DateTime Data_fim { get; set; }
        public TimeSpan Duracao_horas { get; set; }
    }
}
