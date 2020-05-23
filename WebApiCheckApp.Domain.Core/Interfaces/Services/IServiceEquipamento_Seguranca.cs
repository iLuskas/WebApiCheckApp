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
    }
}
