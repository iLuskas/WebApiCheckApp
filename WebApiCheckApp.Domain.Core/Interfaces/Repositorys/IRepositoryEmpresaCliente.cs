using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryEmpresaCliente : IRepositoryBase<EmpresaCliente>
    {
        IEnumerable<EmpresaCliente> getAllInfoEmpresaCliente();
        EmpresaCliente getAllInfoEmpresaClienteById(int id);
        EmpresaCliente getAllEquipamentoByIdAndTipo(int empresaId, int tipoId);
        IEnumerable<dynamic> getRelatOcorrenciaForEmp();
    }
}
