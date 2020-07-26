using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using webApiCheckApp.Application.DTO.DTO.DTOHelpers;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Domain.Models.Helpers;

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

        public void Add(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            _serviceUsuario.Add(objEntity);
        }

        public void AlterarSenhaUsuario(ModeloAlterarSenhaUserDTO modeloAlterarSenhaUserDTO)
        {
            if (string.IsNullOrEmpty(modeloAlterarSenhaUserDTO.Email))
                throw new Exception("O campo e-mail é obrigatorio");

            if (string.IsNullOrEmpty(modeloAlterarSenhaUserDTO.Senha))
                throw new Exception("O campo senha é obrigatorio");

            var objEntity = _mapper.Map<ModeloAlterarSenhaUser>(modeloAlterarSenhaUserDTO);

            _serviceUsuario.AlterarSenhaUsuario(objEntity);
        }

        public void Dispose()
        {
            _serviceUsuario.Dispose();
        }

        public IEnumerable<UsuarioDTO> GetAllUsuario()
        {
            var listObjEntity =  _serviceUsuario.GetAllUsuario();

            return _mapper.Map<IEnumerable<UsuarioDTO>>(listObjEntity);
        }

        public UsuarioDTO GetById(int id)
        {
            var objEntity = _serviceUsuario.GetById(id);

            return _mapper.Map<UsuarioDTO>(objEntity);
        }

        public UsuarioDTO GetUserByUserAndPass(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            var obj = _serviceUsuario.GetUserByUsernameAndPass(objEntity);
            return _mapper.Map<UsuarioDTO>(obj);
        }

        public void Remove(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            _serviceUsuario.Remove(objEntity);
        }

        public bool ResetSenhaUsuario(string email)
        {
            return _serviceUsuario.resetSenhaUsuario(email);
        }

        public void Update(UsuarioDTO usuarioDTO)
        {
            var objEntity = _mapper.Map<Usuario>(usuarioDTO);

            _serviceUsuario.Update(objEntity);
        }
    }
}
