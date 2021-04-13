using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ListandoDocumentosOrdenados
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
            Console.WriteLine("Listando documentos mais de 100 páginas");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gte(x => x.Paginas, 100);

            var listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
                .SortBy(x => x.Titulo)
                .Limit(5)
                .ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
