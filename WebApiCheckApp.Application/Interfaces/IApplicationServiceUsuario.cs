using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using webApiCheckApp.Application.DTO.DTO.DTOHelpers;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDTO usuarioDTO);
        UsuarioDTO GetById(int id);
        IEnumerable<UsuarioDTO> GetAllUsuario();
        UsuarioDTO GetUserByUserAndPass(UsuarioDTO usuarioDTO);
        bool ResetSenhaUsuario(string email);
        void AlterarSenhaUsuario(ModeloAlterarSenhaUserDTO modeloAlterarSenhaUserDTO);
        void Update(UsuarioDTO usuarioDTO);
        void Remove(UsuarioDTO usuarioDTO);
        void Dispose();
    }
}
