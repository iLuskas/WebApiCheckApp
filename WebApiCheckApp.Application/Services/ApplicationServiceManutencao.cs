using AutoMapper;
using System.Collections.Generic;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceManutencao : IApplicationServiceManutencao
    {
        private readonly IServiceManutencao _serviceManutencao;
        private readonly IMapper _mapper;

        public ApplicationServiceManutencao(IServiceManutencao serviceManutencao, IMapper mapper)
        {
            _serviceManutencao = serviceManutencao;
            _mapper = mapper;
        }

        public void Add(ManutencaoDTO obj)
        {
            var objEntity = _mapper.Map<Manutencao>(obj);
            _serviceManutencao.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceManutencao.Dispose();
        }

        public IEnumerable<ManutencaoDTO> GetAll()
        {
            var llistObjEntity = _serviceManutencao.GetAll();
            return _mapper.Map<IEnumerable<ManutencaoDTO>>(llistObjEntity);
        }

        public ManutencaoDTO GetById(int id)
        {
            var objEntity = _serviceManutencao.GetById(id);
            return _mapper.Map<ManutencaoDTO>(objEntity);
        }

        public ManutencaoDTO GetManutencaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId)
        {
            var objEntity = _serviceManutencao.GetManutencaoByEquipIdAndAgeId(equipamentoId, agendamentoId);
            return _mapper.Map<ManutencaoDTO>(objEntity);
        }

        public void Remove(ManutencaoDTO obj)
        {
            var objEntity = _mapper.Map<Manutencao>(obj);
            _serviceManutencao.Remove(objEntity);
        }

        public void Update(ManutencaoDTO obj)
        {
            var objEntity = _mapper.Map<Manutencao>(obj);
            _serviceManutencao.Update(objEntity);
        }
    }
}
