using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Extintor : Base
    {
        public int EquipamentoId { get; set; }
        public  Equipamento_Seguranca Equipamento { get; set; }
        public int Num_ext { get; set; }
        [MaxLength(14)]
        public string SeloInmetro_ext { get; set; }
        [MaxLength(50)]
        public string Fabricante_ext { get; set; }
        [MaxLength(100)]
        public string Tipo_ext { get; set; }
        public double Capacidade_ext { get; set; }
        [MaxLength(4)]
        public string AnoFabricacao_ext { get; set; }
    }
}
