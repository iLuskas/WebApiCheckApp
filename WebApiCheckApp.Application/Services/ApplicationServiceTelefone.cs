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
    public class ApplicationServiceTelefone : IApplicationServiceTelefone
    {
        private readonly IServiceTelefone _serviceTelefone;
        private readonly IMapper _mapper;

        public ApplicationServiceTelefone(IServiceTelefone serviceTelefone, IMapper mapper)
        {
            _serviceTelefone = serviceTelefone;
            _mapper = mapper;
        }

        public void Add(TelefoneDTO obj)
        {
            var objEntity = _mapper.Map<Telefone>(obj);

            _serviceTelefone.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceTelefone.Dispose();
        }

        public IEnumerable<TelefoneDTO> GetAll()
        {
            var listObjEntity = _serviceTelefone.GetAll();

            return _mapper.Map<IEnumerable<TelefoneDTO>>(listObjEntity);
        }

        public TelefoneDTO GetById(int id)
        {
            var objEntity = _serviceTelefone.GetById(id);

            return _mapper.Map<TelefoneDTO>(objEntity);
        }

        public void Remove(TelefoneDTO obj)
        {
            var objEntity = _mapper.Map<Telefone>(obj);

            _serviceTelefone.Remove(objEntity);
        }

        public void Update(TelefoneDTO obj)
        {
            var objEntity = _mapper.Map<Telefone>(obj);

            _serviceTelefone.Update(objEntity);
        }
    }
}
