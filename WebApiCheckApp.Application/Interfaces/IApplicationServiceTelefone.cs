using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceTelefone
    {
        void Add(TelefoneDTO obj);
        TelefoneDTO GetById(int id);
        IEnumerable<TelefoneDTO> GetAll();
        void Update(TelefoneDTO obj);
        void Remove(TelefoneDTO obj);
        void Dispose();
    }
}
