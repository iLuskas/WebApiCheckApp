using System;
using System.Collections.Generic;
using System.IO;
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

        public EmpresaCliente getAllEquipamentoByIdAndTipo(int empresaId, int tipoId)
        {
            return _repositoryEmpresaCliente.getAllEquipamentoByIdAndTipo(empresaId, tipoId);
        }

        public IEnumerable<EmpresaCliente> getAllInfoEmpresaCliente()
        {
            var empresas =  _repositoryEmpresaCliente.getAllInfoEmpresaCliente();
            return empresas;
        }

        public EmpresaCliente getAllInfoEmpresaClienteById(int id)
        {
            return _repositoryEmpresaCliente.getAllInfoEmpresaClienteById(id);
        }

        public IEnumerable<dynamic> getRelatOcorrenciaForEmp()
        {
            return _repositoryEmpresaCliente.getRelatOcorrenciaForEmp();
        }
    }
}
