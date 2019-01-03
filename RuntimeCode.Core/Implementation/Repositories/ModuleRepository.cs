using RuntimeCode.Core.Interfaces.Entities;
using RuntimeCode.Core.Interfaces.Repositories;
using RuntimeCode.Core.Interfaces.UnitOfWork;

namespace RuntimeCode.Core.Implementation.Repositories
{
     public class ModuleRepository<T> : BaseRepository<T, string>, IModuleRepository<T> where T : IModule
    {
        public ModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}