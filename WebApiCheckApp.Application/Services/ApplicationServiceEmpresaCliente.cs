using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceEmpresaCliente : IApplicationServiceEmpresaCliente
    {
        private readonly IServiceEmpresaCliente _serviceEmpresaCliente;
        private readonly IMapper _mapper;

        public ApplicationServiceEmpresaCliente(IServiceEmpresaCliente serviceEmpresaCliente, IMapper mapper)
        {
            _serviceEmpresaCliente = serviceEmpresaCliente;
            _mapper = mapper;
        }

        public void Add(EmpresaClienteDTO obj)
        {
            var objEntity = _mapper.Map<EmpresaCliente>(obj);

            _serviceEmpresaCliente.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceEmpresaCliente.Dispose();
        }

        public IEnumerable<EmpresaClienteDTO> GetAll()
        {
            var listObjEntity = _serviceEmpresaCliente.GetAll();

            return _mapper.Map<IEnumerable<EmpresaClienteDTO>>(listObjEntity);
        }

        public EmpresaClienteDTO getAllEquipamentoByIdAndTipo(int empresaId, int tipoId)
        {
            var listObjentity = _serviceEmpresaCliente.getAllEquipamentoByIdAndTipo(empresaId, tipoId);

            return _mapper.Map<EmpresaClienteDTO>(listObjentity);
        }

        public EmpresaClienteDTO getAllInfoEmpresaClienteById(int id)
        {
            var objEntity = _serviceEmpresaCliente.getAllInfoEmpresaClienteById(id);

            return _mapper.Map<EmpresaClienteDTO>(objEntity);
        }

        public IEnumerable<EmpresaClienteDTO> GetAllInfoEmpressaCliente()
        {
            var listObjentity = _serviceEmpresaCliente.getAllInfoEmpresaCliente();

            return _mapper.Map<IEnumerable<EmpresaClienteDTO>>(listObjentity);
        }

        public EmpresaClienteDTO GetById(int id)
        {
            var objEntity = _serviceEmpresaCliente.GetById(id);

            return _mapper.Map<EmpresaClienteDTO>(objEntity);
        }

        public void Remove(EmpresaClienteDTO obj)
        {
            var objEntity = _mapper.Map<EmpresaCliente>(obj);
            _serviceEmpresaCliente.Remove(objEntity);
        }

        public void Update(EmpresaClienteDTO obj)
        {
            var objEntity = _mapper.Map<EmpresaCliente>(obj);
            _serviceEmpresaCliente.Update(objEntity);
        }
    }
}
