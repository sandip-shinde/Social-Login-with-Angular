using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StarterKit.SQLite.Interfaces
{
    public interface IDBRepository<T> where T : class, new()
    {
        List<T> Get();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(int id);
        List<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        T Get(Expression<Func<T, bool>> predicate);
        int Insert(T entity);
        int InsertOrReplace(T entity);
        int Update(T entity);
        int Delete(T entity);
        int GetCount(Expression<Func<T, bool>> predicate);
        int DeleteAll();
    }
}
