using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IEmailSender
    {
        Task SendEmailRecoveryPassAsync(string email, string token);
        Task SendEmailAgendamentoAsync(string email, AgendaInspManutDTO modeloAgenda);
        Task SendEmailAgendamentoEmpAsync(string email, AgendaInspManutDTO modeloAgenda);
    }
}
