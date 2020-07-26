using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceAgendaInspManut : ServiceBase<AgendaInspManut>, IServiceAgendaInspManut
    {
        private readonly IRepositoryAgendaInspManut _repositoryAgendaInspManut;
        private readonly IRepositoryFuncionario _repositoryFuncionario;

        public ServiceAgendaInspManut(IRepositoryAgendaInspManut repositoryAgendaInspManut, IRepositoryFuncionario repositoryFuncionario) : base(repositoryAgendaInspManut)
        {
            _repositoryAgendaInspManut = repositoryAgendaInspManut;
            _repositoryFuncionario = repositoryFuncionario;
        }

        public void alteraStatusAgendamentoById(int ageId, int statusId)
        {
            _repositoryAgendaInspManut.alteraStatusAgendamentoById(ageId, statusId);
        }

        public void finalizaAgendamentoById(int ageId)
        {
            _repositoryAgendaInspManut.finalizaAgendamentoById(ageId);
        }

        public AgendaInspManut getAgendamentoById(int id)
        {
            return _repositoryAgendaInspManut.getAgendamentoById(id);
        }

        public IEnumerable<AgendaInspManut> getAllAgendamento()
        {
            return _repositoryAgendaInspManut.getAllAgendamento();
        }

        public IEnumerable<AgendaInspManut> getAllAgendamentoByDt(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllAgendamentoByDt(dataIni, dataFim);
        }

        public IEnumerable<dynamic> getAllAgendaByUserAndTipo(string usuario, int tipoAgendamento)
        {
            var funcionarioId = _repositoryFuncionario.getFuncionarioByUsername(usuario);
           return  _repositoryAgendaInspManut.getAllAgendaByFuncIdAndTipo(funcionarioId, tipoAgendamento);
        }

        public int GetAllEquipInsp(int funcionarioId, int empresaId, int agendamentoId)
        {
            return _repositoryAgendaInspManut.GetAllEquipInsp(funcionarioId, empresaId, agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipInspByAgendamentoId(int agendamentoId)
        {
            return _repositoryAgendaInspManut.getAllEquipInspByAgendamentoId(agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllEquipInspByDtAgendamento(dataIni, dataFim);
        }

        public IEnumerable<dynamic> getAllEquipInspByDtHoje(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllEquipInspByDtHoje(dataIni, dataFim);
        }

        public int GetAllEquipNotInsp(int funcionarioId, int empresaId, int agendamentoId)
        {
            return _repositoryAgendaInspManut.GetAllEquipNotInsp(funcionarioId, empresaId, agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipNotInspByAgendamentoId(int agendamentoId)
        {
            return _repositoryAgendaInspManut.getAllEquipNotInspByAgendamentoId(agendamentoId); ;
        }

        public IEnumerable<dynamic> getAllEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllEquipNotInspByDtAgendamento(dataIni, dataFim);
        }

        public dynamic getAllQtdEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllQtdEquipInspByDtAgendamento(dataIni, dataFim);
        }

        public dynamic getAllQtdEquipInspByDtHoje(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllQtdEquipInspByDtHoje(dataIni, dataFim);
        }

        public dynamic getAllQtdEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _repositoryAgendaInspManut.getAllQtdEquipNotInspByDtAgendamento(dataIni, dataFim);
        }

        public AgendaInspManut getUltimoAgendamento()
        {
            return _repositoryAgendaInspManut.getUltimoAgendamento();
        }

        public IEnumerable<dynamic> getAllEquipNotManutByAgendamentoId(int agendamentoId)
        {
            return _repositoryAgendaInspManut.getAllEquipNotManutByAgendamentoId(agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipManutByAgendamentoId(int agendamentoId)
        {
            return _repositoryAgendaInspManut.getAllEquipManutByAgendamentoId(agendamentoId);
        }
    }
}
