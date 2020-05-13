using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Usuario : Base
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual Funcionario Funcionario { get; set; }
    }
}
