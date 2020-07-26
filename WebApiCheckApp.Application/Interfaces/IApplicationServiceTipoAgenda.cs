using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceTipoAgenda
    {
        void Add(TipoAgendamento obj);
        TipoAgendamento GetById(int id);
        IEnumerable<TipoAgendamento> GetAll();
        void Update(TipoAgendamento obj);
        void Remove(TipoAgendamento obj);
        void Dispose();
    }
}
