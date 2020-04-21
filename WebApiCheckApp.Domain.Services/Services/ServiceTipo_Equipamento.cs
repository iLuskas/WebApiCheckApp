using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceTipo_Equipamento : ServiceBase<Tipo_equipamento>, IServiceTipo_Equipamento
    {
        private readonly IRepositoryTipo_Equipamento _repositoryTipo_Equipamento;

        public ServiceTipo_Equipamento(IRepositoryTipo_Equipamento repositoryTipo_Equipamento) : base(repositoryTipo_Equipamento)
        {
            _repositoryTipo_Equipamento = repositoryTipo_Equipamento;
        }
    }
}
