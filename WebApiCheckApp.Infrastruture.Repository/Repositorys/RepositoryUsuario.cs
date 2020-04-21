using System;
using System.Collections.Generic;
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
    }
}
