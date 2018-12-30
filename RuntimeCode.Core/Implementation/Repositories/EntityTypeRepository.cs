using RuntimeCode.Core.Interfaces.Repositories;
using RuntimeCode.Core.Interfaces.UnitOfWork;
using RuntimeCode.Core.Interfaces.Entities;
using RuntimeCode.Core.Implementation.Entities;

namespace RuntimeCode.Core.Implementation.Repositories
{
    public class EntityTypeRepository<T> : BaseRepository<T, string>, IEntityTypeRepository<T> where T : IEntityType
    {
        public EntityTypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}