using System;

namespace RuntimeCode.Core.Interfaces.Entities
{
    public interface IEntityBase<TKey>
    {
         TKey Id { get; set;}
         string Name { get; set;}
         string Description { get; set;}
         DateTime Created { get; set;}
         DateTime Modified { get; set;}
         bool Active { get; set;}
    }
    
    public interface IEntityBase : IEntityBase<string>
    {

    }
}