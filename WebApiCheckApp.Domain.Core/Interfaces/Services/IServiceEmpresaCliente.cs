using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IServiceEmpresaCliente : IServiceBase<EmpresaCliente>
    {
        IEnumerable<EmpresaCliente> getAllInfoEmpresaCliente();
        EmpresaCliente getAllInfoEmpresaClienteById(int id);
    }
}
