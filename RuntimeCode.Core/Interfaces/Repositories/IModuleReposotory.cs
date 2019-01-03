using RuntimeCode.Core.Implementation.Entities;
using RuntimeCode.Core.Interfaces.Entities;

namespace RuntimeCode.Core.Interfaces.Repositories
{
    public interface IModuleRepository<T> : IRepository<T> where T : IModule
    {
         
    }
}