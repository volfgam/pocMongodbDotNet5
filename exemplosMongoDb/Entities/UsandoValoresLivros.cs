using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDb.Entities
{
    class UsandoValoresLivros
    {
        static void Main(string[] args)
        {
            _ = MainSync(args);
            Console.WriteLine("Precione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //Inicializando um objeto do tipo livro

            var livro = new Livro
            {
                Titulo = "Star Wars Legends",
                Autor = "Timothy Zahn",
                Ano = 2010,
                Paginas = 245,
                Assunto = new List<string>
                {
                    "Ficção Científica",
                    "Ação"
                }
            };

            //Acessando através da Classe

            var conexcaoBiblioteca = new ConectandoMongoDb();

            //Incluindo Documento
            await conexcaoBiblioteca.Livros.InsertOneAsync(livro);

            Console.WriteLine("Documento incluido");

        }
    }
}
