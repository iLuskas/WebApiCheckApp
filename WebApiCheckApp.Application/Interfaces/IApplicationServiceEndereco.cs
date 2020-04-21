using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceEndereco
    {
        void Add(EnderecoDTO obj);
        EnderecoDTO GetById(int id);
        IEnumerable<EnderecoDTO> GetAll();
        void Update(EnderecoDTO obj);
        void Remove(EnderecoDTO obj);
        void Dispose();
    }
}
