using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceFuncionario
    {
        void Add(FuncionarioDTO obj);
        FuncionarioDTO GetById(int id);
        IEnumerable<FuncionarioDTO> GetAll();
        IEnumerable<FuncionarioDTO> GetAllInfoFuncionario();
        FuncionarioDTO getAllInfoFuncionarioById(int id);
        void Update(FuncionarioDTO obj);
        void Remove(FuncionarioDTO obj);
        void Dispose();
    }
}
