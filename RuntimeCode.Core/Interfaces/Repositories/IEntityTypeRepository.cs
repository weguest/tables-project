using RuntimeCode.Core.Implementation.Entities;
using RuntimeCode.Core.Interfaces.Entities;

namespace RuntimeCode.Core.Interfaces.Repositories
{
    public interface IEntityTypeRepository<T> : IRepository<EntityType> where T : IEntityType
    {
         
    }
}