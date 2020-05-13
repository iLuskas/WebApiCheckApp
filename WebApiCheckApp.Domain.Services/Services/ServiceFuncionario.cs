using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceFuncionario : ServiceBase<Funcionario>, IServiceFuncionario
    {
        private readonly IRepositoryFuncionario _repositoryFuncionario;

        public ServiceFuncionario(IRepositoryFuncionario repositoryFuncionario) : base(repositoryFuncionario)
        {
            _repositoryFuncionario = repositoryFuncionario;
        }

        public IEnumerable<Funcionario> GetAllInfoFuncionario()
        {
           return _repositoryFuncionario.getAllInfoFuncionario();
        }

        public Funcionario GetAllInfoFuncionarioById(int id)
        {
            return _repositoryFuncionario.getAllInfoFuncionarioById(id);
        }
    }
}
