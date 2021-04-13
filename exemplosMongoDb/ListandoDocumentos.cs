using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ListandoDocumentos
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
            Console.WriteLine("Documento Incluido");

            var listaLivros = await conexcaoBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
        }
    }
}
