using System.Collections.Generic;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceInspecao
    {
        void Add(InspecaoDTO obj);
        InspecaoDTO GetById(int id);
        IEnumerable<InspecaoDTO> GetAll();
        InspecaoDTO GetInspecaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId);
        void Update(InspecaoDTO obj);
        void Remove(InspecaoDTO obj);
        void Dispose();
    }
}
