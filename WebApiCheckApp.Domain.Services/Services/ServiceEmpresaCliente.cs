using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceEmpresaCliente : ServiceBase<EmpresaCliente>, IServiceEmpresaCliente
    {
        public readonly IRepositoryEmpresaCliente _repositoryEmpresaCliente;
        public ServiceEmpresaCliente(IRepositoryEmpresaCliente repositoryEmpresaCliente) : base(repositoryEmpresaCliente)
        {
            _repositoryEmpresaCliente = repositoryEmpresaCliente;
        }

        public IEnumerable<EmpresaCliente> getAllInfoEmpresaCliente()
        {
            return _repositoryEmpresaCliente.getAllInfoEmpresaCliente();
        }
    }
}
