using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System.Data.SqlClient;


namespace CCA.MongoDB.DAL
{
    public class marty_collection_entity    // name elements of the entity the same as the collection fields in NongoDB
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Repository
    {
        private static string _connectionString = "mongodb://127.0.0.1:27017";
        private static string _databaseName = "marty";
        private static string _collectionName = "marty_collection";
        public IMongoDatabase _db = null;
        public Repository()          // ctor
        {
            try
            {
                MongoClient client = new MongoClient(_connectionString);     // assumes local mongo db running    
                _db = client.GetDatabase(_databaseName);
            }
            catch (Exception exc)
            {
                throw new ApplicationException("Failed to get Mongo db: " + _connectionString,exc);
            }
        }

        public List<marty_collection_entity> GetCollection(string collectionName)
        {
            try
            {
                
                var collection = _db.GetCollection<marty_collection_entity>(_collectionName);
                return collection.Find(new BsonDocument()).ToList();
            }
            catch(Exception exc)
            {
                Exception swallow = exc;
                return null;
            }
        }

    }
}
