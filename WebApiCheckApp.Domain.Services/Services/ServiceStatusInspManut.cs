using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceStatusInspManut : ServiceBase<StatusInspManut>, IServiceStatusInspManut
    {
        private readonly IRepositoryStatusInspManut _repositoryStatusInspManut;

        public ServiceStatusInspManut(IRepositoryStatusInspManut repositoryStatusInspManut) : base(repositoryStatusInspManut)
        {
            _repositoryStatusInspManut = repositoryStatusInspManut;
        }
    }
}
