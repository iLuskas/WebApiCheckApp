using System;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class ExtintorDTO : BaseDTO
    {
        public int EquipamentoId { get; set; }
        public int Num_ext { get; set; }
        public string SeloInmetro_ext { get; set; }
        public string Fabricante_ext { get; set; }
        public string Tipo_ext { get; set; }
        public double Peso_ext { get; set; }
        public double Capacidade_ext { get; set; }
        public DateTime Ano_fabricacao { get; set; }
    }
}