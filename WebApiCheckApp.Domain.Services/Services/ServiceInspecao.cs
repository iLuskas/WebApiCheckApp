using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceInspecao : ServiceBase<Inspecao>, IServiceInspecao
    {
        private readonly IRepositoryInspecao _repositoryInspecao;

        public ServiceInspecao(IRepositoryInspecao repositoryInspecao) : base(repositoryInspecao)
        {
            _repositoryInspecao = repositoryInspecao;
        }

        public Inspecao GetInspecaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId)
        {
            return _repositoryInspecao.GetInspecaoByEquipIdAndAgeId(equipamentoId, agendamentoId);
        }
    }
}
