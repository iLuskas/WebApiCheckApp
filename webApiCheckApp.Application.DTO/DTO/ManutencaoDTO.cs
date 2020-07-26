using System;
using System.Collections.Generic;
using System.Text;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class ManutencaoDTO : BaseDTO
    {
        public int EquipamentoSegurancaId { get; set; }
        public int StatusInspManutId { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaClienteId { get; set; }
        public int? AgendaInspManutId { get; set; }
        public string TipoExt { get; set; }
        public string Capacidade { get; set; }
        public string AnoFabricacao { get; set; }
        public string FabricanteExt { get; set; }
        public string NumCilindro { get; set; }
        public string SeloInmetro { get; set; }
        public string ObsManut { get; set; }
        public string UltimoTeste { get; set; }
        public string DataReteste { get; set; }
        public string DataRecarga { get; set; }
        public string DataProximaRecarga { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public bool Reprovado { get; set; }
        public bool Aprovado { get; set; }
        public string Duracao { get; set; }
        public virtual Equipamento_SegurancaDTO EquipamentoSegurancaDTO { get; set; }
    }
}
