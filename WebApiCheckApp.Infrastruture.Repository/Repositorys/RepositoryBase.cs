using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly CheckappContext _checkappContext;

        public RepositoryBase(CheckappContext checkappContext)
        {
            _checkappContext = checkappContext;
        }

        public virtual void Add(TEntity obj)
        {
            _checkappContext.InitTransacao();
            _checkappContext.Set<TEntity>().Add(obj);
            _checkappContext.SendChanges();
        }

        public virtual void Dispose()
        {
            _checkappContext.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _checkappContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _checkappContext.Set<TEntity>().Find(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _checkappContext.InitTransacao();
            _checkappContext.Set<TEntity>().Remove(obj);
            _checkappContext.SendChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _checkappContext.InitTransacao();
            _checkappContext.Set<TEntity>().Attach(obj);
            _checkappContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _checkappContext.SendChanges();
        }
    }
}
