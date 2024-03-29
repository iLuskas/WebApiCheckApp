﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryFuncionario : IRepositoryBase<Funcionario>
    {
        IEnumerable<Funcionario> getAllInfoFuncionario();
        Funcionario getAllInfoFuncionarioById(int id);
        int getFuncionarioByUsername(string userName);
        Funcionario getFuncionarioByName(string name);
    }
}
