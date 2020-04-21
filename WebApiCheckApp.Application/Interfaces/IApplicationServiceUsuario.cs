using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDTO obj);
        UsuarioDTO GetById(int id);
        IEnumerable<UsuarioDTO> GetAll();
        void Update(UsuarioDTO obj);
        void Remove(UsuarioDTO obj);
        void Dispose();
    }
}
