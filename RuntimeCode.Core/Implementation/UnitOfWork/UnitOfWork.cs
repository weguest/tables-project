using MongoDB.Driver;
using RuntimeCode.Core.Interfaces.UnitOfWork;

namespace RuntimeCode.Core.Implementation.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString) : this(new MongoUrl(connectionString))
        {
        }

        public UnitOfWork(MongoUrl url)
        {
            Client = new MongoClient(url);
            Database = Client.GetDatabase(url.DatabaseName);
        }
        
        public IMongoClient Client { get; }
        public IMongoDatabase Database { get; }
    }
}