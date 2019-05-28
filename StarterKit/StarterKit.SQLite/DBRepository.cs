using StarterKit.SQLite.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StarterKit.SQLite
{
    public class DBRepository<T> : IDBRepository<T> where T : class, new()
    {
        SQLiteConnection dbConnection;

        public DBRepository(SQLiteConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            this.dbConnection.CreateTable<T>(CreateFlags.AutoIncPK);
        }

        public int Delete(T entity) => dbConnection.Delete(entity);

        public List<T> Get() => dbConnection.Table<T>().ToList();

        public T Get(int id) => dbConnection.Find<T>(id);

        public List<T> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = dbConnection.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return query.ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate) => dbConnection.Find<T>(predicate);

        public List<T> GetAll(Expression<Func<T, bool>> predicate) => dbConnection.Table<T>().Where(predicate).ToList();

        public int GetCount(Expression<Func<T, bool>> predicate)
        {
            var query = dbConnection.Table<T>();
            if (predicate != null)
                return query.Count(predicate);
            return -1;
        }

        public int Insert(T entity) => dbConnection.Insert(entity);

        public int InsertOrReplace(T entity) => dbConnection.InsertOrReplace(entity);

        public int Update(T entity) => dbConnection.Update(entity);
        public int DeleteAll() => dbConnection.DeleteAll<T>();
    }
}
