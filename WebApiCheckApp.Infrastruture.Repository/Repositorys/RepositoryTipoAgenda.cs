using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Infrastruture.Repository.Repositorys;

namespace WebApiCheckApp.Infrastructure.Repository.Repositorys
{
    public class RepositoryTipoAgenda : RepositoryBase<TipoAgendamento>, IRepositoryTipoAgenda
    {
        private readonly CheckappContext _checkappContext;

        public RepositoryTipoAgenda(CheckappContext checkappContext) : base(checkappContext)
        {
            _checkappContext = checkappContext;
        }
    }
}
