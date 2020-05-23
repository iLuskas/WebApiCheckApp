using System.Collections.Generic;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceEquipamento_Seguranca
    {
        void Add(Equipamento_SegurancaDTO obj);
        Equipamento_SegurancaDTO GetById(int id);
        IEnumerable<Equipamento_SegurancaDTO> GetAll();
        Equipamento_SegurancaDTO getEquipamentoById(int id);
        IEnumerable<Equipamento_SegurancaDTO> getAllEquipamentoByEmpresaId(int EmpresaId);
        IEnumerable<Equipamento_SegurancaDTO> getAllEquipamentoByEmpresaIdAndTipo(int EmpresaId, int tipoId);
        IEnumerable<Equipamento_SegurancaDTO> getAllEquipamento();
        void Update(Equipamento_SegurancaDTO obj);
        void Remove(Equipamento_SegurancaDTO obj);
        void Dispose();
    }
}