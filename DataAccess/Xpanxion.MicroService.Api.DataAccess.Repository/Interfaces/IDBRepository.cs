using System;
using System.Collections.Generic;
using System.Text;

namespace Xpanxion.MicroService.Api.DataAccess.Repository.Interfaces
{
    public interface IDBRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
