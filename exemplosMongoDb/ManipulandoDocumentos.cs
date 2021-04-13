using System;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace exemplosMongoDb
{
    class ManipulandoDocumentos
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
            
        }
    }
}
