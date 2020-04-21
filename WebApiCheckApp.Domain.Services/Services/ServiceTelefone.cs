using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceTelefone : ServiceBase<Telefone>, IServiceTelefone
    {
        private readonly IRepositoryTelefone _repositoryTelefone;

        public ServiceTelefone(IRepositoryTelefone repositoryTelefone) : base(repositoryTelefone)
        {
            _repositoryTelefone = repositoryTelefone;
        }
    }
}
