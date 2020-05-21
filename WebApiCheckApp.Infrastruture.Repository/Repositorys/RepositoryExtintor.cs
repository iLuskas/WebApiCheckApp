using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryExtintor : RepositoryBase<Extintor>, IRepositoryExtintor
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryExtintor(CheckappContext checkAppContext) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }
    }
}