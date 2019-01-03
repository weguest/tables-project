using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using RuntimeCode.Core.Implementation.Entities;
using RuntimeCode.Core.Interfaces.Entities;
using RuntimeCode.Core.Interfaces.Repositories;
using RuntimeCode.Core.Interfaces.UnitOfWork;

namespace RuntimeCode.Core.Implementation.Repositories
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : IEntityBase<TKey>
    {

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            var collectionName = GetCollectionName();

            var filter = new BsonDocument("name", collectionName);
            var collectionCursor = unitOfWork.Database.ListCollections(new ListCollectionsOptions {Filter = filter});
            if(!collectionCursor.Any()){
                unitOfWork.Database.CreateCollection(collectionName);
            }
            Collection = unitOfWork.Database.GetCollection<T>( collectionName );
        }

        public IMongoCollection<T> Collection { get; }
        public Type ElementType { get; set; }
        public Expression Expression { get; set; }
        public IQueryProvider Provider { get; set; }

        public IList<T> SelectAll(){
            return this.Collection.Find(x=>true).ToList();
        }

        public T Add(T entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        public void Add(IEnumerable<T> entities)
        {
            Collection.InsertMany(entities);
        }

        public IQueryable<T> AsQueryable()
        {
            return Collection.AsQueryable();
        }

        public long Count()
        {
            return Collection.Count(x => true);
        }

        public DeleteResult Delete(TKey id)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, id);
            var r = Collection.DeleteOne(filter);
            return r;
        }

        public DeleteResult Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
            var r = Collection.DeleteOne(filter);
            return r;
        }

        public DeleteResult Delete(Expression<Func<T, bool>> predicate)
        {
            var filter = Builders<T>.Filter.Where(predicate);
            var r = Collection.DeleteOne(filter);
            return r;
        }

        public DeleteResult DeleteAll()
        {
            var r = Collection.DeleteMany(x => true);
            return r;
        }

        public void Drop()
        { 

        }

        public bool Exists()
        {
            return Collection.AsQueryable().Any();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
             return Collection.AsQueryable().Any(predicate);
        }

        public IList<T> Find(Expression<Func<T, bool>> predicate)
        {
            var filter = Builders<T>.Filter.Where(predicate);
            return Collection.Find(filter).ToList();
        }

        public T GetById(TKey id)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, id);
            return Collection.Find(filter).SingleOrDefault();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Collection.AsQueryable().GetEnumerator();
        }

        public T Update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(s => s.Id, entity.Id);
            Collection.ReplaceOne(filter, entity);
            return entity;
        }

        public void Update(IEnumerable<T> entities)
        {
            Parallel.ForEach(entities, entity =>
            {
                Update(entity);
            });
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #region Collection Name
        private static string GetCollectionName()
        {
            var collectionName = typeof(T).GetTypeInfo().BaseType == typeof(object)
                ? GetCollectioNameFromInterface()
                : GetCollectionNameFromType(typeof(T));

            if (string.IsNullOrEmpty(collectionName))
                throw new ArgumentException("Collection name cannot be empty for this entity");
            return collectionName;
        }

        private static string GetCollectioNameFromInterface()
        {
            // Check to see if the object (inherited from Entity) has a CollectionName attribute
            var att = typeof(T).GetTypeInfo().GetCustomAttribute<CollectionName>();
            var collectionname = att != null ? att.Name : typeof(T).Name;

            return collectionname;
        }

        private static string GetCollectionNameFromType(Type entitytype)
        {
            string collectionname;

            // Check to see if the object (inherited from Entity) has a CollectionName attribute
            var att = entitytype.GetTypeInfo().GetCustomAttribute<CollectionName>();
            if (att != null)
            {
                // It does! Return the value specified by the CollectionName attribute
                collectionname = att.Name;
            }
            else
            {
                if (typeof(EntityBase).GetTypeInfo().IsAssignableFrom(entitytype))
                    while (entitytype.GetTypeInfo().BaseType != typeof(EntityBase))
                        entitytype = entitytype.GetTypeInfo().BaseType;
                collectionname = entitytype.Name;
            }

            return collectionname;
        }
        #endregion
    }

    public class BaseRepository<T> : BaseRepository<T, string>, IRepository<T> where T : IEntityBase<string>
    {
        public BaseRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionName : Attribute
    {
        public CollectionName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Empty collectionname not allowed", nameof(value));
            Name = value;
        }

        public virtual string Name { get; private set; }
    }
}