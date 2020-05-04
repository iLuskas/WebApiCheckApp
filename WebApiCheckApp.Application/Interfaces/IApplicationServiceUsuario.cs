using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDTO usuarioDTO);
        UsuarioDTO GetById(int id);
        IEnumerable<UsuarioDTO> GetAll();
        UsuarioDTO GetUserByUserAndPass(UsuarioDTO usuarioDTO);
        void Update(UsuarioDTO usuarioDTO);
        void Remove(UsuarioDTO usuarioDTO);
        void Dispose();
    }
}
