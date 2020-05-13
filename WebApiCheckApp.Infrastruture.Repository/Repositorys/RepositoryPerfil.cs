using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryPerfil : RepositoryBase<Perfil>, IRepositoryPerfil
    {
        private readonly CheckappContext _checkAppContext;
        public RepositoryPerfil(CheckappContext checkappContext) : base(checkappContext)
        {
            _checkAppContext = checkappContext;
        }
    }
}
