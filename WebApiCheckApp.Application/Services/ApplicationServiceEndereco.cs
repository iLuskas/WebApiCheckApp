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
    public class ApplicationServiceEndereco : IApplicationServiceEndereco
    {
        private readonly IServiceEndereco _serviceEndereco;
        private readonly IMapper _mapper;

        public ApplicationServiceEndereco(IServiceEndereco serviceEndereco, IMapper mapper)
        {
            _serviceEndereco = serviceEndereco;
            _mapper = mapper;
        }

        public void Add(EnderecoDTO obj)
        {
            var objEntity = _mapper.Map<Endereco>(obj);

            _serviceEndereco.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceEndereco.Dispose();
        }

        public IEnumerable<EnderecoDTO> GetAll()
        {
            var listObjEntity = _serviceEndereco.GetAll();

            return _mapper.Map<IEnumerable<EnderecoDTO>>(listObjEntity);
        }

        public EnderecoDTO GetById(int id)
        {
            var objEntity = _serviceEndereco.GetById(id);

            return _mapper.Map<EnderecoDTO>(objEntity);
        }

        public void Remove(EnderecoDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(EnderecoDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
