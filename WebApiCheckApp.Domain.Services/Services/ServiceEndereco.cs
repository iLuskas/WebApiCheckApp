using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceEndereco : ServiceBase<Endereco>, IServiceEndereco
    {
        private readonly IRepositoryEndereco repositoryEndereco;

        public ServiceEndereco(IRepositoryEndereco repositoryEndereco) : base(repositoryEndereco)
        {
            this.repositoryEndereco = repositoryEndereco;
        }
    }
}
