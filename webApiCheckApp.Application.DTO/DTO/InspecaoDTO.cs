using System;
using System.Collections.Generic;
using System.Text;

namespace webApiCheckApp.Application.DTO.DTO
{
    public class InspecaoDTO : BaseDTO
    {
        public int StatusInspManutId { get; set; }
        public int FuncionarioId { get; set; }
        public int EmpresaClienteId { get; set; }
        public int? AgendaInspManutId { get; set; }
        public string UltimaRec_Insp { get; set; }
        public string ProximoRec_Insp { get; set; }
        public string UltimoReteste_Insp { get; set; }
        public string ProximoReteste_Insp { get; set; }
        public string EstadoCilindro_Insp { get; set; }
        public string EstadoLocal_Insp { get; set; }
        public string SeloLacre_insp { get; set; }
        public string SinalizacaoPiso_insp { get; set; }
        public string SinalizacaoAcesso_insp { get; set; }
        public string Obs_Insp { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string Duracao { get; set; }
        public bool? PrecisaManutencao { get; set; }
        public string ImagemOcorrencia { get; set; }
        public string ImagemOcorrenciaBase64 { get; set; }
        public int EquipamentoSegurancaId { get; set; }
        public virtual Equipamento_SegurancaDTO EquipamentoSegurancaDTO { get; set; }
    }
}
