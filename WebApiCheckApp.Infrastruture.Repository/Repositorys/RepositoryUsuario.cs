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

        public IEnumerable<Usuario> GetAllUsuario()
        {
            IQueryable<Usuario> query = _checkAppContext.Usuarios
                .Include(f => f.Funcionario)
                    .ThenInclude(p => p.Perfil);

            return query.AsNoTracking().OrderByDescending(u => u.Id).ToList();
        }

        public Usuario GetUserByUsernameAndPass(Usuario usuario)
        {
            IQueryable<Usuario> query = _checkAppContext.Usuarios
                .Include(f => f.Funcionario)
                    .ThenInclude(p => p.Perfil);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Login.ToLower() == usuario.Login.ToLower() && user.Senha == usuario.Senha).FirstOrDefault();
        }

        public Usuario getUsuarioByEmail(string email)
        {
            IQueryable<Usuario> query = _checkAppContext.Usuarios
                .Include(f => f.Funcionario)
                    .ThenInclude(p => p.Perfil);

            return query.AsNoTracking().OrderByDescending(u => u.Id)
                                       .Where(user => user.Funcionario.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
    }
}
