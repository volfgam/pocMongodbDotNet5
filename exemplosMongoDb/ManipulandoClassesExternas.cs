using exemplosMongoDb.Entities;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ManipulandoClassesExternas
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

            var livro = new Livro();
            livro = Livro.IncluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura  Brasileira");
            await conexcaoBiblioteca.Livros.InsertOneAsync(livro);

            livro = Livro.IncluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");
            await conexcaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento incluido");

        }
    }
}
