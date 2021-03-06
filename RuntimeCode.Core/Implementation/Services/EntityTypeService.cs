using RuntimeCode.Core.Interfaces.Entities;
using RuntimeCode.Core.Interfaces.Services;
using RuntimeCode.Core.Interfaces.Repositories;
using System.Collections.Generic;
using RuntimeCode.Core.Implementation.Entities;

namespace RuntimeCode.Core.Implementation.Services
{
    public class EntityTypeService : IEntityTypeService<EntityType>
    {

        IEntityTypeRepository<EntityType> _repository;
        public EntityTypeService(IEntityTypeRepository<EntityType> repository)
        {
             this._repository = repository;
        }

        // public bool Delete(IEntityType entity)
        // {
        //     return this._repository.Delete( entity.Id );
        // }

        // public IEntityType GetById(string Id)
        // {
        //     return this._repository.GetById( Id );
        // }

        // public IEntityType Save(IEntityType entity)
        // {
        //     if(entity.Id == null)
        //         this._repository.Add( entity );
        //     else
        //         this._repository.Update(entity);

        //     return entity;
        // }

        // public IList<IEntityType> SelectAll()
        // {
        //     throw new System.NotImplementedException();
        // }

        public bool Delete(EntityType entity)
        {
             return this._repository.Delete( entity.Id ).DeletedCount > 0;
        }

        public EntityType GetById(string Id)
        {
            return this._repository.GetById( Id );
        }

        public EntityType Save(EntityType entity)
        {
            if( string.IsNullOrEmpty( entity?.Id )) {
                entity = _repository.Add(entity);
            }else{
                entity = _repository.Update(entity);
            }

            return entity;
        }

        public IList<EntityType> SelectAll()
        {
            return this._repository.SelectAll();
        }
    }
}