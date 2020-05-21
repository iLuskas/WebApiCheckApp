using System.Collections.Generic;
using webApiCheckApp.Application.DTO.DTO;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceExtintor
    {
        void Add(ExtintorDTO obj);
        ExtintorDTO GetById(int id);
        IEnumerable<ExtintorDTO> GetAll();
        void Update(ExtintorDTO obj);
        void Remove(ExtintorDTO obj);
        void Dispose();
    }
}