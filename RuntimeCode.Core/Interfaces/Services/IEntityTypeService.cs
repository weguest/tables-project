using RuntimeCode.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace RuntimeCode.Core.Interfaces.Services
{
    public interface IEntityTypeService<T> where T : IEntityType
    {
        T Save(T entity);
        bool Delete(T entity);
        T GetById(string Id);
        IList<T> SelectAll();
    }
}