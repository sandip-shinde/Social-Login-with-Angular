using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;

namespace Xpanxion.MicroService.Api.DataAccess.Repository
{
    public class DBUnitOfWork : IDBUnitOfWork
    {
        readonly DatabaseContext dbContext;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public DBUnitOfWork(DatabaseContext context)
        {
            this.dbContext = context;
        }

        public IDBRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IDBRepository<T>;
            }

            IDBRepository<T> repo = new DBRepository<T>(this.dbContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges() => this.dbContext.SaveChanges();
        
    }
}
