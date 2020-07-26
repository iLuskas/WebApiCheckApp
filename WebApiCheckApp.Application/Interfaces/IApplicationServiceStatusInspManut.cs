using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Application.Interfaces
{
    public interface IApplicationServiceStatusInspManut
    {
        void Add(StatusInspManut obj);
        StatusInspManut GetById(int id);
        IEnumerable<StatusInspManut> GetAll();
        void Update(StatusInspManut obj);
        void Remove(StatusInspManut obj);
        void Dispose();
    }
}
