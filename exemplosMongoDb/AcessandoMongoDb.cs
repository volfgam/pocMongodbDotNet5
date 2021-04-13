using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace exemplosMongoDb
{
    class AcessandoMongoDb
    {
        static void Main(string[] args)
        {
            Task t = MainSync(args);
            Console.WriteLine("Precione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {

            var doc = new BsonDocument
            {
                { "Titulo", "Guerra dos Tronos" }
            };
            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);

            var assuntos = new BsonArray
            {
                "Fantasia",
                "Ação"
            };

            doc.Add("Assunto", assuntos);

            Console.WriteLine(doc);

            //Acesso ao servidor mongo db
            string stringConexao = "mongodb://localhost:27017";

            IMongoClient client = new MongoClient(stringConexao);

            //acesso ao banco de dados

            IMongoDatabase bancoDados = client.GetDatabase("Biblioteca");

            //Acesso a coleção

            IMongoCollection<BsonDocument> collection = bancoDados.GetCollection<BsonDocument>("Livros");

            //Incluindo Documento
            await collection.InsertOneAsync(doc);
            Console.WriteLine("Documento incluido");

        }
    }
}
