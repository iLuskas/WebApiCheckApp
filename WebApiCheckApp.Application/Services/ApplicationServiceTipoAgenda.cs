using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceTipoAgenda : IApplicationServiceTipoAgenda
    {
        private readonly IServiceTipoAgenda _serviceTipoAgenda;

        public ApplicationServiceTipoAgenda(IServiceTipoAgenda serviceTipoAgenda)
        {
            _serviceTipoAgenda = serviceTipoAgenda;
        }

        public void Add(TipoAgendamento obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoAgendamento> GetAll()
        {
            return _serviceTipoAgenda.GetAll();
        }

        public TipoAgendamento GetById(int id)
        {
            return _serviceTipoAgenda.GetById(id);
        }

        public void Remove(TipoAgendamento obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoAgendamento obj)
        {
            throw new NotImplementedException();
        }
    }
}
