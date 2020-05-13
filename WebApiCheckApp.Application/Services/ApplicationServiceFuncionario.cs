using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceFuncionario : IApplicationServiceFuncionario
    {
        private readonly IServiceFuncionario _serviceFuncionario;
        private readonly IMapper _mapper;

        public ApplicationServiceFuncionario(IServiceFuncionario serviceFuncionario, IMapper mapper)
        {
            _serviceFuncionario = serviceFuncionario;
            _mapper = mapper;
        }

        public void Add(FuncionarioDTO obj)
        {
            var objEntity = _mapper.Map<Funcionario>(obj);

            _serviceFuncionario.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceFuncionario.Dispose();
        }

        public IEnumerable<FuncionarioDTO> GetAll()
        {
            var listObjEntity = _serviceFuncionario.GetAll();

            return _mapper.Map<IEnumerable<FuncionarioDTO>>(listObjEntity);
        }

        public IEnumerable<FuncionarioDTO> GetAllInfoFuncionario()
        {
            var listObjEntity = _serviceFuncionario.GetAllInfoFuncionario();

            return _mapper.Map<IEnumerable<FuncionarioDTO>>(listObjEntity);
        }

        public FuncionarioDTO getAllInfoFuncionarioById(int id)
        {
            var objEntity = _serviceFuncionario.GetAllInfoFuncionarioById(id);
            
            return _mapper.Map<FuncionarioDTO>(objEntity);
        }

        public FuncionarioDTO GetById(int id)
        {
            var objEntity = _serviceFuncionario.GetById(id);

            return _mapper.Map<FuncionarioDTO>(objEntity);
        }

        public void Remove(FuncionarioDTO obj)
        {
            var objEntity = _mapper.Map<Funcionario>(obj);

            _serviceFuncionario.Remove(objEntity);
        }

        public void Update(FuncionarioDTO obj)
        {
            var objEntity = _mapper.Map<Funcionario>(obj);

            _serviceFuncionario.Update(objEntity);
        }
    }
}
