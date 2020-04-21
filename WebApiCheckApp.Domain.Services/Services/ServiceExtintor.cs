using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceExtintor : ServiceBase<Extintor>, IServiceExtintor
    {
        private readonly IRepositoryExtintor _repositoryExtintor;

        public ServiceExtintor(IRepositoryExtintor repositoryExtintor) : base(repositoryExtintor)
        {
            _repositoryExtintor = repositoryExtintor;
        }
    }
}
