using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class AlterandoDocumento
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
            Console.WriteLine("Lista e alterar livro Gerra dos Tronos");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            var listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
                .ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
                item.Ano = 2000;
                item.Paginas = 900;
                await conexcaoBiblioteca.Livros.ReplaceOneAsync(condicao, item);
            }

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
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
