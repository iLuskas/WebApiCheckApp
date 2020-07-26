using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiCheckApp.Domain.Models
{
    public class AgendaInspManut : Base
    {
        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public int EmpresaClienteId { get; set; }
        public virtual EmpresaCliente EmpresaCliente { get; set; }
        public int TipoEquipamentoId { get; set; }
        public virtual Tipo_equipamento TipoEquipamento { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public int TipoAgendamentoId { get; set; }
        public TipoAgendamento TipoAgendamento { get; set; }
        public int StatusInspManutId { get; set; }
        public virtual StatusInspManut StatusInspManut { get; set; }
        public string Duracao { get; set; }
        public string TipoManutencao { get; set; }
        public bool OcorrenciaInspecao { get; set; }

        public virtual List<Inspecao> Inspecoes { get; set; }
        public virtual List<Manutencao> Manutencoes { get; set; }
    }
}
