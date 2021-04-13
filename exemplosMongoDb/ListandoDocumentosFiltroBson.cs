using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ListandoDocumentosFiltroBson
    {
        static void Main(string[] args)
        {
            _ = MainSync(args);
            Console.WriteLine("Precione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            var conexcaoBiblioteca = new ConectandoMongoDb();
            Console.WriteLine("Listando documentos do Autor = Machado de Assis");

            var filtro = new BsonDocument()
            {
                {"Autor", "Machado de Assis" }
            };

            var listaLivros = await conexcaoBiblioteca.Livros.Find(filtro).ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
        }
    }
}
