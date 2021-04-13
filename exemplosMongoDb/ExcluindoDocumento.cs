using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ExcluindoDocumento
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
            Console.WriteLine("Buscar livros de M. Assis");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "M. Assis");

            var listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
                .ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }

            Console.WriteLine("Fim da listagem");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Excluindo livros....");

            await conexcaoBiblioteca.Livros.DeleteManyAsync(condicao);

            Console.WriteLine("Livros de M. Assis Excluídos.");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Buscar livros de M. Assis");

            listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
                .ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }

            Console.WriteLine("Fim da listagem");
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
