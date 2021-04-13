using exemplosMongoDb.Entities;
using MongoDB.Driver;

namespace exemplosMongoDb
{
    public class ConectandoMongoDb
    {
        const string StringConnection = "mongodb://localhost:27017";
        const string DataBaseName = "Biblioteca";
        const string CollectionName = "Livros";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _dataBase;

        static ConectandoMongoDb()
        {
            _client = new MongoClient(StringConnection);
            _dataBase = _client.GetDatabase(DataBaseName);
        }

        public IMongoClient Client
        {
            get
            {
                return _client;
            }
        }

        public IMongoCollection<Livro> Livros
        {
            get
            {
                return _dataBase.GetCollection<Livro>(CollectionName);
            }
        }

    }

}
