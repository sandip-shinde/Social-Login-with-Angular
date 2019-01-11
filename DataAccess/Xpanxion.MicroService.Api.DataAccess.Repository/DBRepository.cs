using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xpanxion.MicroService.Api.DataAccess.Entities;
using Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces;
using System.Linq;

namespace Xpanxion.MicroService.Api.DataAccess.Repository
{
    public class DBRepository<T> : IDBRepository<T>
        where T : class
    {
        DatabaseContext DbContext;
        DbSet<T> objectSet;

        public DBRepository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
            objectSet = dbContext.Set<T>();
        }
        public void Add(T entity) => objectSet.Add(entity);

        public void Update(T entity) => objectSet.Update(entity);

        public void Delete(T entity) => objectSet.Remove(entity);

        public T Get(Func<T, bool> predicate) => objectSet.FirstOrDefault(predicate);

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
                return objectSet.Where(predicate);
            return objectSet.AsEnumerable();
        }

    }
}
