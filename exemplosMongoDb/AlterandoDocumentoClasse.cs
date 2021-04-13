using exemplosMongoDb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class AlterandoDocumentoClasse
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
            }

            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);

            await conexcaoBiblioteca.Livros.UpdateOneAsync(condicao, condicaoAlteracao);

            Console.WriteLine("Alterando apenas um registro");
            Console.WriteLine();
            Console.WriteLine();

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
                .ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }

            Console.WriteLine("Monstrando alteração");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Listar os livros de Machado de Assis");

            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexcaoBiblioteca.Livros
                .Find(condicao)
                .ToListAsync();

            foreach (var item in listaLivros)
            {
                Console.WriteLine(item.ToJson<Livro>());
            }

            construtorAlteracao = Builders<Livro>.Update;
            condicaoAlteracao = construtorAlteracao.Set(x => x.Autor, "M. Assis");

            await conexcaoBiblioteca.Livros.UpdateManyAsync(condicao, condicaoAlteracao);

            Console.WriteLine("Alterando apenas um registro");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
