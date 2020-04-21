using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServicePerfil : ServiceBase<Perfil>, IServicePerfil
    {
        private readonly IRepositoryPerfil _repositoryPerfil;

        public ServicePerfil(IRepositoryPerfil repositoryPerfil) : base(repositoryPerfil)
        {
            _repositoryPerfil = repositoryPerfil;
        }
    }
}
