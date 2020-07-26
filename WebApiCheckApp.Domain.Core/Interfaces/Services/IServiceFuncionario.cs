using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IServiceFuncionario : IServiceBase<Funcionario>
    {
        IEnumerable<Funcionario> GetAllInfoFuncionario();
        Funcionario GetAllInfoFuncionarioById(int id);
        Funcionario getFuncionarioByName(string name);
    }
}
