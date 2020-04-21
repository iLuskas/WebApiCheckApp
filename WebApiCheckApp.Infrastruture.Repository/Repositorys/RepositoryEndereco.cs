using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryEndereco: RepositoryBase<Endereco>, IRepositoryEndereco
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryEndereco(CheckappContext checkAppContext) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }
    }
}
