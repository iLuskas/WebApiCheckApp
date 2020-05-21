using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryTipo_equipamento : RepositoryBase<Tipo_equipamento>, IRepositoryTipo_Equipamento
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryTipo_equipamento(CheckappContext checkAppContext) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }
    }
}