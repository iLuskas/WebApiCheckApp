using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Extintor : Base
    {
        public int IdEquipamento { get; set; }
        public virtual Equipamento_Seguranca Equipamento { get; set; }
        public int Num_ext { get; set; }
        public string SeloInmetro_ext { get; set; }
        public string Fabricante_ext { get; set; }
        public string Tipo_ext { get; set; }
        public double Peso_ext { get; set; }
        public double Capacidade_ext { get; set; }
        public DateTime Ano_fabricacao { get; set; }
    }
}
