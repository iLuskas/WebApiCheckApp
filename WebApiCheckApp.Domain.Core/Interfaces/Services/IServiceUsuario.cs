using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Domain.Models.Helpers;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Usuario GetUserByUsernameAndPass(Usuario usuario);
        bool resetSenhaUsuario(string email);
        void AlterarSenhaUsuario(ModeloAlterarSenhaUser modeloAlterarSenhaUser);
        IEnumerable<Usuario> GetAllUsuario();
        Usuario getUsuarioByEmail(string email);
    }
}
