using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceEmailSender : IEmailSender
    {
        private readonly EnviaEmail _emailSettings;

        public ServiceEmailSender(IOptions<EnviaEmail> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailRecoveryPassAsync(string toEmail, string token)
        {
            try
            {
                var messageTemplate = string.Format(
                    "Prezado(a)," +
                    "<br><br>" +
                    "Para criar uma nova senha senha, clique no link abaixo:" +
                    "<br><br> " +
                    "<a href='https://checkapp-angular.herokuapp.com/recuperarSenha/?token={0}&email={1}'  target='_blank'>Redefinir Senha</a>" +
                    "<br><br> " +
                    "<span>Esse link irá expirar em 10 minutos</span>", token, toEmail);             


                Execute(toEmail, "Recuperação de senha - Equipe CheckApp", messageTemplate, "CheckApp - Recuperação de senha").Wait();
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Execute(string toEmail, string subject, string message, string title)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, title)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = $"{subject}";
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public Task SendEmailAgendamentoAsync(string toEmail, AgendaInspManutDTO modeloAgenda)
        {
            var messageTemplate = string.Format(
                "Prezado(a)," +
                "<br><br>" +
                "Foi criado um novo agendamento em seu nome, segue as informações a baixo:" +
                "<br><br> " +
                "EMPRESA: {0}" +
                "<br><br> " +
                "INSPETOR: {1}" +
                "<br><br> " +
                "Data Início: {2}" +
                "<br><br> " +
                "EQUIPAMENTO: {3}" +
                "<br><br> " +
                "STATUS: {4}" +
                "<br><br> " +
                "TIPO DO AGENDAMENTO: {5}" +
                "<br><br><br>" +
                "Att," +
                "<br>" +
                "Equipe CheckApp", modeloAgenda.Empresa, modeloAgenda.NomeFuncionario, modeloAgenda.DataInicial.ToString("dd/MM/yyyy"),
                                           modeloAgenda.TipoEquipamento, modeloAgenda.StatusInspManut, modeloAgenda.TipoAgendamento);

            Execute(toEmail, "Novo Agendamento - Equipe CheckApp", messageTemplate, "CheckApp - Agendamento").Wait();
            return Task.FromResult(0);
        }

        public Task SendEmailAgendamentoEmpAsync(string email, AgendaInspManutDTO modeloAgenda)
        {
            var messageTemplate = string.Format(
               "Prezado(a)," +
               "<br><br>" +
               "Segue abaixo as informações do agendamento que iremos realizar em sua empresa." +
               "<br><br> " +
               "EMPRESA: {0}" +
               "<br><br> " +
               "INSPETOR: {1}" +
               "<br><br> " +
               "Data Início: {2}" +
               "<br><br> " +
               "EQUIPAMENTO: {3}" +
               "<br><br> " +
               "STATUS: {4}" +
               "<br><br> " +
               "TIPO DO AGENDAMENTO: {5}" +
               "<br><br><br>" +
               "Att," +
               "<br>" +
               "Equipe CheckApp", modeloAgenda.Empresa, modeloAgenda.NomeFuncionario, modeloAgenda.DataInicial.ToString("dd/MM/yyyy"),
                                           modeloAgenda.TipoEquipamento, modeloAgenda.StatusInspManut, modeloAgenda.TipoAgendamento);


            Execute(email, "Novo Agendamento - Equipe CheckApp", messageTemplate, "CheckApp - Agendamento").Wait();
            return Task.FromResult(0);
        }
    }
}
