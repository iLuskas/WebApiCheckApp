using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryAgendaInspManut : IRepositoryBase<AgendaInspManut>
    {
        IEnumerable<AgendaInspManut> getAllAgendamento();
        IEnumerable<AgendaInspManut> getAllAgendamentoByDt(DateTime dataIni, DateTime dataFim);
        AgendaInspManut getAgendamentoById(int id);
        dynamic getAllQtdEquipInspByDtHoje(DateTime dataIni, DateTime dataFim);
        IEnumerable<dynamic> getAllEquipInspByDtHoje(DateTime dataIni, DateTime dataFim);
        dynamic getAllQtdEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim);
        IEnumerable<dynamic> getAllEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim);
        dynamic getAllQtdEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim);
        IEnumerable<dynamic> getAllEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim);
        IEnumerable<dynamic> getAllEquipInspByAgendamentoId(int agendamentoId);
        IEnumerable<dynamic> getAllEquipNotInspByAgendamentoId(int agendamentoId);
        IEnumerable<dynamic> getAllEquipNotManutByAgendamentoId(int agendamentoId);
        IEnumerable<dynamic> getAllEquipManutByAgendamentoId(int agendamentoId);
        IEnumerable<dynamic> getAllAgendaByFuncIdAndTipo(int funcionarioId, int tipoAgendamento);
        int GetAllEquipInsp(int funcionarioId, int empresaId, int agendamentoId);
        int GetAllEquipNotInsp(int funcionarioId, int empresaId, int agendamentoId);
        void alteraStatusAgendamentoById(int ageId, int statusId);
        void finalizaAgendamentoById(int ageId);
        AgendaInspManut getUltimoAgendamento();
    }
}
