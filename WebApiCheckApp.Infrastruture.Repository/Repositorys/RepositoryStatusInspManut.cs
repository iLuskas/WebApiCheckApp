using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Infrastruture.Repository.Repositorys;

namespace WebApiCheckApp.Infrastructure.Repository.Repositorys
{
    public class RepositoryStatusInspManut : RepositoryBase<StatusInspManut>, IRepositoryStatusInspManut
    {
        private readonly CheckappContext _checkappContext;

        public RepositoryStatusInspManut(CheckappContext checkappContext) : base(checkappContext)
        {
            _checkappContext = checkappContext;
        }
    }
}
