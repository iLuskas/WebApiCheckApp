using System;
using System.Collections.Generic;
using System.Text;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class AgendaInspManutDTO : BaseDTO
    {
        public string NomeFuncionario { get; set; }
        public string Empresa { get; set; }
        public string TipoEquipamento { get; set; }
        public string TipoAgendamento { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string StatusInspManut { get; set; }
        public string Duracao { get; set; }
        public string TipoManutencao { get; set; }
        public bool OcorrenciaInspecao { get; set; }
        public List<InspecaoDTO> InspecaoDTOs { get; set; }
    }
}
