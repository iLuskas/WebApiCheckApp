using System.Collections.Generic;
using AutoMapper;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceTipo_Equipamento : IApplicationServiceTipo_Equipamento
    {
        private readonly IServiceTipo_Equipamento _serviceIServiceTipo_Equipamento;
        private readonly IMapper _mapper;

        public ApplicationServiceTipo_Equipamento(IServiceTipo_Equipamento serviceIServiceTipo_Equipamento, IMapper mapper)
        {
            _serviceIServiceTipo_Equipamento = serviceIServiceTipo_Equipamento;
            _mapper = mapper;
        }

        public void Add(Tipo_EquipamentoDTO obj)
        {
            var objEntity = _mapper.Map<Tipo_equipamento>(obj);

            _serviceIServiceTipo_Equipamento.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceIServiceTipo_Equipamento.Dispose();
        }

        public IEnumerable<Tipo_EquipamentoDTO> GetAll()
        {
            var listObjEntity = _serviceIServiceTipo_Equipamento.GetAll();

            return _mapper.Map<IEnumerable<Tipo_EquipamentoDTO>>(listObjEntity);
        }

        public Tipo_EquipamentoDTO GetById(int id)
        {
            var objEntity = _serviceIServiceTipo_Equipamento.GetById(id);

            return _mapper.Map<Tipo_EquipamentoDTO>(objEntity);
        }

        public void Remove(Tipo_EquipamentoDTO obj)
        {
            var objEntity = _mapper.Map<Tipo_equipamento>(obj);

            _serviceIServiceTipo_Equipamento.Remove(objEntity);
        }

        public void Update(Tipo_EquipamentoDTO obj)
        {
            var objEntity = _mapper.Map<Tipo_equipamento>(obj);

            _serviceIServiceTipo_Equipamento.Add(objEntity);
        }
    }
}