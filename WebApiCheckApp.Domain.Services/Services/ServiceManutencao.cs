using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceManutencao : ServiceBase<Manutencao>, IServiceManutencao
    {
        private readonly IRepositoryManutencao _repositoryManutencao;

        public ServiceManutencao(IRepositoryManutencao repositoryManutencao): base(repositoryManutencao)
        {
            _repositoryManutencao = repositoryManutencao;
        }

        public Manutencao GetManutencaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId)
        {
            return _repositoryManutencao.GetManutencaoByEquipIdAndAgeId(equipamentoId, agendamentoId);
        }
    }
}
