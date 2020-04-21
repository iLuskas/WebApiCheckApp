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
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _serviceUsuario;
        private readonly IMapper _mapper;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapper mapper)
        {
            _serviceUsuario = serviceUsuario;
            _mapper = mapper;
        }

        public void Add(UsuarioDTO obj)
        {
            var objEntity = _mapper.Map<Usuario>(obj);

            _serviceUsuario.Add(objEntity);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var listObjEntity =  _serviceUsuario.GetAll();

            return _mapper.Map<IEnumerable<UsuarioDTO>>(listObjEntity);
        }

        public UsuarioDTO GetById(int id)
        {
            var objEntity = _serviceUsuario.GetById(id);

            return _mapper.Map<UsuarioDTO>(objEntity);
        }

        public void Remove(UsuarioDTO obj)
        {
            var objEntity = _mapper.Map<Usuario>(obj);

            _serviceUsuario.Remove(objEntity);
        }

        public void Update(UsuarioDTO obj)
        {
            var objEntity = _mapper.Map<Usuario>(obj);

            _serviceUsuario.Update(objEntity);
        }
    }
}
