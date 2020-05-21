using System.Collections.Generic;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceTipo_Equipamento
    {
        void Add(Tipo_EquipamentoDTO obj);
        Tipo_EquipamentoDTO GetById(int id);
        IEnumerable<Tipo_EquipamentoDTO> GetAll();
        void Update(Tipo_EquipamentoDTO obj);
        void Remove(Tipo_EquipamentoDTO obj);
        void Dispose();
    }
}