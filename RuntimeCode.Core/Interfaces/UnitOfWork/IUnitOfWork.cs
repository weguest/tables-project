using MongoDB.Driver;

namespace RuntimeCode.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
    }
}