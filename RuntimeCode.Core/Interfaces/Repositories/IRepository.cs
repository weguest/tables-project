using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using RuntimeCode.Core.Interfaces.Entities;

namespace RuntimeCode.Core.Interfaces.Repositories
{
    public interface IRepository<T, in TKey> : IQueryable<T> where T : IEntityBase<TKey>
    {

        IMongoCollection<T> Collection { get; }

        IQueryable<T> AsQueryable();

        IList<T> SelectAll();

        T GetById(TKey id);

        T Add(T entity);

        void Add(IEnumerable<T> entities);

        T Update(T entity);

        void Update(IEnumerable<T> entities);

        DeleteResult Delete(TKey id);

        DeleteResult Delete(T entity);

        DeleteResult Delete(Expression<Func<T, bool>> predicate);

        DeleteResult DeleteAll();

        void Drop();

        long Count();

        bool Exists();

        bool Exists(Expression<Func<T, bool>> predicate);

        IList<T> Find(Expression<Func<T, bool>> predicate);
    }

    public interface IRepository<T> : IRepository<T, string> where T : IEntityBase<string>
    {
    }
}