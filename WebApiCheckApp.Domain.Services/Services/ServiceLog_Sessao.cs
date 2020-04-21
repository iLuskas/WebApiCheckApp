using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceLog_Sessao : ServiceBase<Log_Sessao>, IServiceLog_Sessao
    {
        private readonly IRepositoryLog_Sessao _repositoryLog_Sessao;

        public ServiceLog_Sessao(IRepositoryLog_Sessao repositoryLog_Sessao) : base(repositoryLog_Sessao)
        {
            _repositoryLog_Sessao = repositoryLog_Sessao;
        }
    }
}
