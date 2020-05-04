using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryEmpresaCliente: RepositoryBase<EmpresaCliente>, IRepositoryEmpresaCliente
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryEmpresaCliente(CheckappContext checkAppContext): base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }

        public IEnumerable<EmpresaCliente> getAllInfoEmpresaCliente()
        {
            IQueryable<EmpresaCliente> query = _checkAppContext.EmpresaClientes
           .Include(e => e.Enderecos)
           .Include(e => e.Telefones);

            return query.AsNoTracking().OrderBy(e => e.Id).ToList();            
        }

        public EmpresaCliente getAllInfoEmpresaClienteById(int id)
        {
            IQueryable<EmpresaCliente> query = _checkAppContext.EmpresaClientes
           .Include(e => e.Enderecos)
           .Include(e => e.Telefones);

            return query.AsNoTracking()
            .Where(e => e.Id == id).FirstOrDefault();  
        }
    }
}
