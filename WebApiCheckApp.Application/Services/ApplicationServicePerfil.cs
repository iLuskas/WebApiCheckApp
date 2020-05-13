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
    public class ApplicationServicePerfil : IApplicationServicePerfil
    {
        private readonly IServicePerfil _servicePerfil;
        private readonly IMapper _mapper;

        public ApplicationServicePerfil(IServicePerfil servicePErfil, IMapper mapper)
        {
            _servicePerfil = servicePErfil;
            _mapper = mapper;
        }

        public void Add(PerfilDTO obj)
        {
            var objEntity = _mapper.Map<Perfil>(obj);

            _servicePerfil.Add(objEntity);
        }

        public void Dispose()
        {
            _servicePerfil.Dispose();
        }

        public IEnumerable<PerfilDTO> GetAll()
        {
            var listObjEntity = _servicePerfil.GetAll();

            return _mapper.Map<IEnumerable<PerfilDTO>>(listObjEntity);
        }

        public PerfilDTO GetById(int id)
        {
            var ObjEntity = _servicePerfil.GetById(id);

            return _mapper.Map<PerfilDTO>(ObjEntity);
        }

        public void Remove(PerfilDTO obj)
        {
            var objEntity = _mapper.Map<Perfil>(obj);

            _servicePerfil.Remove(objEntity);
        }

        public void Update(PerfilDTO obj)
        {
            var objEntity = _mapper.Map<Perfil>(obj);

            _servicePerfil.Update(objEntity);
        }
    }
}
