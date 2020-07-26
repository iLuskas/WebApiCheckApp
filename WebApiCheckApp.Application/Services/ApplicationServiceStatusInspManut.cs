using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Services
{
    public class ApplicationServiceStatusInspManut : IApplicationServiceStatusInspManut
    {
        private readonly IServiceStatusInspManut _serviceStatusInspManut;
        private readonly IMapper _mapper;

        public ApplicationServiceStatusInspManut(IServiceStatusInspManut serviceStatusInspManut, IMapper mapper)
        {
            _serviceStatusInspManut = serviceStatusInspManut;
            _mapper = mapper;
        }

        public void Add(StatusInspManut obj)
        {
            _serviceStatusInspManut.Add(obj);
        }

        public void Dispose()
        {
            _serviceStatusInspManut.Dispose();
        }

        public IEnumerable<StatusInspManut> GetAll()
        {
            return _serviceStatusInspManut.GetAll();
        }

        public StatusInspManut GetById(int id)
        {
            return _serviceStatusInspManut.GetById(id);
        }

        public void Remove(StatusInspManut obj)
        {
            _serviceStatusInspManut.Remove(obj);
        }

        public void Update(StatusInspManut obj)
        {
            _serviceStatusInspManut.Update(obj);
        }
    }
}
