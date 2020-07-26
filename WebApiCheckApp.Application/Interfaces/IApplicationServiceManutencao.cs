using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceManutencao
    {
        void Add(ManutencaoDTO obj);
        ManutencaoDTO GetById(int id);
        IEnumerable<ManutencaoDTO> GetAll();
        public ManutencaoDTO GetManutencaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId);
        void Update(ManutencaoDTO obj);
        void Remove(ManutencaoDTO obj);
        void Dispose();
    }
}
