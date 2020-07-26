using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Inspecao : Base
    {
        public int StatusInspManutId { get; set; }
        public virtual StatusInspManut StatusInspManut { get; set; }
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int EmpresaClienteId { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        public int? AgendaInspManutId { get; set; }
        public virtual AgendaInspManut AgendaInspManut { get; set; }
        [MaxLength(50)]
        public string UltimaRec_Insp { get; set; }
        [MaxLength(50)]
        public string ProximoRec_Insp { get; set; }
        [MaxLength(50)]
        public string UltimoReteste_Insp { get; set; }
        [MaxLength(50)]
        public string ProximoReteste_Insp { get; set; }
        [MaxLength(20)]
        public string EstadoCilindro_Insp { get; set; }
        [MaxLength(20)]
        public string EstadoLocal_Insp { get; set; }
        [MaxLength(20)]
        public string SeloLacre_insp { get; set; }
        [MaxLength(20)]
        public string SinalizacaoPiso_insp { get; set; }
        [MaxLength(20)]
        public string SinalizacaoAcesso_insp { get; set; }
        [MaxLength(255)]
        public string Obs_Insp { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        [MaxLength(20)]
        public string Duracao { get; set; }
        public bool? PrecisaManutencao { get; set; }
        public string ImagemOcorrencia { get; set; }
        public int EquipamentoSegurancaId { get; set; }
        public virtual Equipamento_Seguranca EquipamentoSeguranca { get; set; }
    }
}
