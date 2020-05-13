using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServicePerfil
    {
        void Add(PerfilDTO obj);
        PerfilDTO GetById(int id);
        IEnumerable<PerfilDTO> GetAll();
        void Update(PerfilDTO obj);
        void Remove(PerfilDTO obj);
        void Dispose();
    }
}
