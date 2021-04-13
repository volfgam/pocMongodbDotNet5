using exemplosMongoDb.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class IncluindoMuitosLivros
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

            var livros = new List<Livro>
            {
                Livro.IncluiValoresLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"),
                Livro.IncluiValoresLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"),
                Livro.IncluiValoresLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"),
                Livro.IncluiValoresLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"),
                Livro.IncluiValoresLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"),
                Livro.IncluiValoresLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"),
                Livro.IncluiValoresLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"),
                Livro.IncluiValoresLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"),
                Livro.IncluiValoresLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"),
                Livro.IncluiValoresLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"),
                Livro.IncluiValoresLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"),
                Livro.IncluiValoresLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"),
                Livro.IncluiValoresLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação")
            };

            await conexcaoBiblioteca.Livros.InsertManyAsync(livros);

            Console.WriteLine("Documento Incluido");

        }
    }
}
