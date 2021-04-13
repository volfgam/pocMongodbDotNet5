using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ListandoDocumentosFiltroClasse
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
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Listando documentos do Autor = Machado de Assis - Classe");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexcaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Listando documentos ano de publicacao maior ou igual a 1999");

            condicao = construtor.Gte(x => x.Ano, 1999);

            listaLivros = await conexcaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Listando documentos a partir de 1999 e com mais de 300 paginas");

            condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);

            listaLivros = await conexcaoBiblioteca.Livros.Find(condicao).ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }
            Console.WriteLine("Fim da lista");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Listando documentos somente de ficção científica");

            condicao = construtor.AnyEq(x => x.Assunto, "Ficção Científica");

            listaLivros = await conexcaoBiblioteca.Livros.Find(condicao).ToListAsync();

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
