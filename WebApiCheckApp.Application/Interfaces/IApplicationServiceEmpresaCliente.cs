using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceEmpresaCliente
    {
        void Add(EmpresaClienteDTO obj);
        EmpresaClienteDTO GetById(int id);
        IEnumerable<EmpresaClienteDTO> GetAll();
        IEnumerable<EmpresaClienteDTO> GetAllInfoEmpressaCliente();
        EmpresaClienteDTO getAllInfoEmpresaClienteById(int id);
        EmpresaClienteDTO getAllEquipamentoByIdAndTipo(int empresaId, int tipoId);
        IEnumerable<dynamic> getRelatOcorrenciaForEmp();
        void Update(EmpresaClienteDTO obj);
        void Remove(EmpresaClienteDTO obj);
        void Dispose();
    }
}
