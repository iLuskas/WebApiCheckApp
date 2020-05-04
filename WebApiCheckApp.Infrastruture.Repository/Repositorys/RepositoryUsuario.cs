using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryUsuario(CheckappContext checkAppContext) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            IQueryable<Usuario> query = _checkAppContext.Usuarios;

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Login.ToLower() == usuario.Login.ToLower() && user.Senha == usuario.Senha).FirstOrDefault();
        }
    }
}
