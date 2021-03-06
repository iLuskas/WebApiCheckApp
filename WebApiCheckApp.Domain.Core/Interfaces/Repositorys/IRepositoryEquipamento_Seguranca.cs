﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryEquipamento_Seguranca : IRepositoryBase<Equipamento_Seguranca>
    {
        Equipamento_Seguranca getEquipamentoById(int id);
        IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaId(int EmpresaId);
        IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaIdAndTipo(int EmpresaId, int tipoId);
        IEnumerable<Equipamento_Seguranca> getAllEquipamento();
        dynamic getEquipByNumExtintor(string numExtintor, int empId);
        IEnumerable<dynamic> getRelatEquipamentos(DateTime dataIni, DateTime dataFim);
        IEnumerable<dynamic> getRelatEquipNotInsp();
        IEnumerable<dynamic> getRelatEquipInsp();
    }
}
