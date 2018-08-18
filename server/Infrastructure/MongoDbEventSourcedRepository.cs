using MongoDB.Bson;
using MongoDB.Driver;
using NServiceBus;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MongoDbEventSourcedRepository : IEventSourcedRepository
    {
        private MongoClient _client;
        private string _databaseName;

        public MongoDbEventSourcedRepository(string connectionString, string database)
        {
            //_client = new MongoClient(connectionString);
            //_databaseName = database;
        }


        public async Task Save(IEventSourced source)
        {
            await Task.Delay(100);
            return;
            //if(!(source.Events?.Count() > 0)) return;

            //var documents = source.Events.Select(e =>
            //{
            //    return new BsonDocument
            //    {
            //        { aggregateId = source.Id }
            //    };
            //});

            //var collectionName = source.GetType().Name;

            //var database = _client.GetDatabase(_databaseName);
            //var collection = database.GetCollection<BsonDocument>(collectionName);
            //await collection.InsertManyAsync(documents);
        }
    }
}
