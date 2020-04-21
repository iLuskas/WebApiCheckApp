using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public virtual void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
           return  _repositoryBase.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return _repositoryBase.GetById(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _repositoryBase.Remove(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }
    }
}
