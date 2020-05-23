using AutoMapper;
using System.Collections.Generic;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceEquipamento_Seguranca : IApplicationServiceEquipamento_Seguranca
    {
        private readonly IServiceEquipamento_Seguranca _serviceEquipamento_Seguranca;
        private readonly IMapper _mapper;

        public ApplicationServiceEquipamento_Seguranca(IServiceEquipamento_Seguranca serviceEquipamento_Seguranca, IMapper mapper)
        {
            _serviceEquipamento_Seguranca = serviceEquipamento_Seguranca;
            _mapper = mapper;
        }

        public void Add(Equipamento_SegurancaDTO obj)
        {
            var objEntity = _mapper.Map<Equipamento_Seguranca>(obj);

            _serviceEquipamento_Seguranca.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceEquipamento_Seguranca.Dispose();
        }

        public IEnumerable<Equipamento_SegurancaDTO> GetAll()
        {
            var listObjEntity = _serviceEquipamento_Seguranca.GetAll();

            return _mapper.Map<IEnumerable<Equipamento_SegurancaDTO>>(listObjEntity);
        }

        public IEnumerable<Equipamento_SegurancaDTO> getAllEquipamento()
        {
            var listObjEntity = _serviceEquipamento_Seguranca.getAllEquipamento();

            return _mapper.Map<IEnumerable<Equipamento_SegurancaDTO>>(listObjEntity);
        }

        public IEnumerable<Equipamento_SegurancaDTO> getAllEquipamentoByEmpresaId(int EmpresaId)
        {
            var listObjEntity = _serviceEquipamento_Seguranca.getAllEquipamentoByEmpresaId(EmpresaId);

            return _mapper.Map<IEnumerable<Equipamento_SegurancaDTO>>(listObjEntity);
        }

        public IEnumerable<Equipamento_SegurancaDTO> getAllEquipamentoByEmpresaIdAndTipo(int empresaId, int tipoId)
        {
            var listObjEntity = _serviceEquipamento_Seguranca.getAllEquipamentoByEmpresaIdAndTipo(empresaId, tipoId);

            return _mapper.Map<IEnumerable<Equipamento_SegurancaDTO>>(listObjEntity);
        }

        public Equipamento_SegurancaDTO getEquipamentoById(int id)
        {
            var objEntity = _serviceEquipamento_Seguranca.getEquipamentoById(id);

            return _mapper.Map<Equipamento_SegurancaDTO>(objEntity);
        }

        public Equipamento_SegurancaDTO GetById(int id)
        {
            var objEntity = _serviceEquipamento_Seguranca.GetById(id);

            return _mapper.Map<Equipamento_SegurancaDTO>(objEntity);
        }

        public void Remove(Equipamento_SegurancaDTO obj)
        {
            var objEntity = _mapper.Map<Equipamento_Seguranca>(obj);

            _serviceEquipamento_Seguranca.Remove(objEntity);
        }

        public void Update(Equipamento_SegurancaDTO obj)
        {
            var objEntity = _mapper.Map<Equipamento_Seguranca>(obj);

            _serviceEquipamento_Seguranca.Update(objEntity);
        }
    }
}