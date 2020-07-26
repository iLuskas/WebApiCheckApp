using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceAgendaInspManut : IApplicationServiceAgendaInspManut
    {
        private readonly IServiceAgendaInspManut _serviceAgendaInspManut;
        private readonly IServiceFuncionario _serviceFuncionario;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public ApplicationServiceAgendaInspManut(IServiceAgendaInspManut serviceAgendaInspManut, IServiceFuncionario serviceFuncionario, IMapper mapper, IEmailSender emailSender)
        {
            _serviceAgendaInspManut = serviceAgendaInspManut;
            _serviceFuncionario = serviceFuncionario;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public void Add(AgendaInspManut obj)
        {          
            _serviceAgendaInspManut.Add(obj);
            var ultimoAgenda = _serviceAgendaInspManut.getUltimoAgendamento();
            var agendamento = _mapper.Map<AgendaInspManutDTO>(ultimoAgenda);
            var emailFuncionario = ultimoAgenda.Funcionario.Email;
            var emailEmpresa = ultimoAgenda.EmpresaCliente.Email;
            _emailSender.SendEmailAgendamentoAsync(emailFuncionario, agendamento);
            _emailSender.SendEmailAgendamentoEmpAsync(emailEmpresa, agendamento);
        }

        public void alteraStatusAgendamentoById(int ageId, int statusId)
        {
            _serviceAgendaInspManut.alteraStatusAgendamentoById(ageId, statusId);
        }

        public void Dispose()
        {
            _serviceAgendaInspManut.Dispose();
        }

        public void finalizaAgendamentoById(int ageId)
        {
            _serviceAgendaInspManut.finalizaAgendamentoById(ageId);
        }

        public AgendaInspManutDTO getAgendamentoById(int id)
        {
            var objEntity = _serviceAgendaInspManut.getAgendamentoById(id);

            return _mapper.Map<AgendaInspManutDTO>(objEntity);
        }

        public IEnumerable<AgendaInspManut> GetAll()
        {
            return _serviceAgendaInspManut.GetAll();
        }

        public IEnumerable<AgendaInspManutDTO> getAllAgendamento()
        {
            var listObjentity = _serviceAgendaInspManut.getAllAgendamento();

            return _mapper.Map<IEnumerable<AgendaInspManutDTO>>(listObjentity);
        }

        public IEnumerable<AgendaInspManutDTO> getAllAgendamentoByDt(DateTime dataIni, DateTime dataFim)
        {
            var listObjentity = _serviceAgendaInspManut.getAllAgendamentoByDt(dataIni, dataFim);

            return _mapper.Map<IEnumerable<AgendaInspManutDTO>>(listObjentity);
        }

        public IEnumerable<dynamic> getAllAgendaByUserAndTipo(string usuario, int tipoAgendamento)
        {
            return _serviceAgendaInspManut.getAllAgendaByUserAndTipo(usuario, tipoAgendamento);
        }

        public int GetAllEquipInsp(int funcionarioId, int empresaId, int agendamentoId)
        {
            return _serviceAgendaInspManut.GetAllEquipInsp(funcionarioId, empresaId, agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipInspByAgendamentoId(int agendamentoId)
        {
            return _serviceAgendaInspManut.getAllEquipInspByAgendamentoId(agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _serviceAgendaInspManut.getAllEquipInspByDtAgendamento(dataIni, dataFim);
        }

        public IEnumerable<dynamic> getAllEquipInspByDtHoje(DateTime dataIni, DateTime dataFim)
        {
            return _serviceAgendaInspManut.getAllEquipInspByDtHoje(dataIni, dataFim);
        }

        public int GetAllEquipNotInsp(int funcionarioId, int empresaId, int agendamentoId)
        {
            return _serviceAgendaInspManut.GetAllEquipNotInsp(funcionarioId, empresaId, agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipNotInspByAgendamentoId(int agendamentoId)
        {
            return _serviceAgendaInspManut.getAllEquipNotInspByAgendamentoId(agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _serviceAgendaInspManut.getAllEquipNotInspByDtAgendamento(dataIni, dataFim);
        }

        public dynamic getAllQtdEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _serviceAgendaInspManut.getAllQtdEquipInspByDtAgendamento(dataIni, dataFim);
        }

        public dynamic getAllQtdEquipInspByDtHoje(DateTime dataIni, DateTime dataFim)
        {
            return _serviceAgendaInspManut.getAllQtdEquipInspByDtHoje(dataIni, dataFim);
        }

        public dynamic getAllQtdEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            return _serviceAgendaInspManut.getAllQtdEquipNotInspByDtAgendamento(dataIni, dataFim);
        }

        public AgendaInspManut GetById(int id)
        {
            return _serviceAgendaInspManut.GetById(id);
        }

        public void Remove(AgendaInspManut obj)
        {
            _serviceAgendaInspManut.Remove(obj);
        }

        public void Update(AgendaInspManut obj)
        {
            _serviceAgendaInspManut.Update(obj);
        }

        public IEnumerable<dynamic> getAllEquipNotManutByAgendamentoId(int agendamentoId)
        {
            return _serviceAgendaInspManut.getAllEquipNotManutByAgendamentoId(agendamentoId);
        }

        public IEnumerable<dynamic> getAllEquipManutByAgendamentoId(int agendamentoId)
        {
            return _serviceAgendaInspManut.getAllEquipManutByAgendamentoId(agendamentoId);
        }
    }
}
