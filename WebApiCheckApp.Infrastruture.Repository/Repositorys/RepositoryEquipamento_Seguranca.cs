using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryEquipamento_Seguranca : RepositoryBase<Equipamento_Seguranca>, IRepositoryEquipamento_Seguranca
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryEquipamento_Seguranca(CheckappContext checkAppContext) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }
    }
}