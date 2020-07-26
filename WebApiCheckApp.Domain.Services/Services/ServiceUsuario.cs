using System;
using System.Collections.Generic;
using System.Text;
using Util;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Domain.Models.Helpers;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IEmailSender _emailSender;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario, IEmailSender emailSender): base(repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
            _emailSender = emailSender;
        }

        public void AlterarSenhaUsuario(ModeloAlterarSenhaUser modeloAlterarSenhaUser)
        {
            var usuario = _repositoryUsuario.getUsuarioByEmail(modeloAlterarSenhaUser.Email);

            if (usuario == null)
                throw new Exception("Email não encontrato em nossa base.");

            usuario.Senha = Utilidades.GerarHashMd5(modeloAlterarSenhaUser.Senha);

            _repositoryUsuario.Update(usuario);
        }

        public IEnumerable<Usuario> GetAllUsuario()
        {
            return _repositoryUsuario.GetAllUsuario();
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            return _repositoryUsuario.GetUserByUsernameAndPass(usuario);
        }

        public Usuario getUsuarioByEmail(string email)
        {
            return _repositoryUsuario.getUsuarioByEmail(email);
        }

        public bool resetSenhaUsuario(string email)
        {
            var usuario = _repositoryUsuario.getUsuarioByEmail(email);
            
            if (usuario == null)
                throw new Exception("Email não encontrato em nossa base.");

            var token = ServiceToken.GenerateToken(usuario, true);

            var response = _emailSender.SendEmailRecoveryPassAsync(usuario.Funcionario.Email, token).GetAwaiter();

            return response.IsCompleted;
        }
    }
}
