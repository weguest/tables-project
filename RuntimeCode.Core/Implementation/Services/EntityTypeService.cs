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
            throw new System.NotImplementedException();
        }

        public IList<EntityType> SelectAll()
        {
            throw new System.NotImplementedException();
        }
    }
}