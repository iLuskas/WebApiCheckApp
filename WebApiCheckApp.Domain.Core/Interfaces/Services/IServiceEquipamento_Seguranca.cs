using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Core.Interfaces.Services
{
    public interface IServiceEquipamento_Seguranca : IServiceBase<Equipamento_Seguranca>
    {
        Equipamento_Seguranca getEquipamentoById(int id);
        IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaId(int EmpresaId);
        IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaIdAndTipo(int EmpresaId, int tipoId);
        IEnumerable<Equipamento_Seguranca> getAllEquipamento();
        IEnumerable<dynamic> getRelatEquipamentos(DateTime dataIni, DateTime dataFim);
        dynamic getEquipByNumExtintor(string numExtintor, int empId);
        IEnumerable<dynamic> getRelatEquipNotInsp();
        IEnumerable<dynamic> getRelatEquipInsp();
    }
}
