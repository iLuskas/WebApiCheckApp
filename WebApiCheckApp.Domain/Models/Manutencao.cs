using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class Manutencao : Base
    {
        public int EquipamentoSegurancaId { get; set; }
        public virtual Equipamento_Seguranca EquipamentoSeguranca { get; set; }
        public int StatusInspManutId { get; set; }
        public virtual StatusInspManut StatusInspManut { get; set; }
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int EmpresaClienteId { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        public int? AgendaInspManutId { get; set; }
        public virtual AgendaInspManut AgendaInspManut { get; set; }
        [MaxLength(20)]
        public string TipoExt { get; set; }
        [MaxLength(50)]
        public string Capacidade { get; set; }
        [MaxLength(4)]
        public string AnoFabricacao { get; set; }
        [MaxLength(50)]
        public string FabricanteExt { get; set; }
        [MaxLength(50)]
        public string NumCilindro { get; set; }
        [MaxLength(50)]
        public string SeloInmetro { get; set; }
        public string ObsManut { get; set; }
        [MaxLength(20)]
        public string UltimoTeste { get; set; }
        [MaxLength(20)]
        public string DataRecarga { get; set; }
        [MaxLength(20)]
        public string DataProximaRecarga { get; set; }
        [MaxLength(20)]
        public string DataReteste { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public bool Reprovado { get; set; }
        public bool Aprovado { get; set; }
        [MaxLength(20)]
        public string Duracao { get; set; }
        
    }
}
