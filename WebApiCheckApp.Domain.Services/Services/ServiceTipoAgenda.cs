using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceTipoAgenda : ServiceBase<TipoAgendamento>, IServiceTipoAgenda
    {
        private readonly IRepositoryTipoAgenda _repositoryTipoAgenda;

        public ServiceTipoAgenda(IRepositoryTipoAgenda repositoryTipoAgenda): base(repositoryTipoAgenda)
        {
            _repositoryTipoAgenda = repositoryTipoAgenda;
        }
    }
}
