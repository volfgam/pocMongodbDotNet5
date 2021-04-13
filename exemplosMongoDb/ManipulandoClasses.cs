using exemplosMongoDb.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ManipulandoClasses
    {
        static void Main(string[] args)
        {
            Task t = MainSync(args);
            Console.WriteLine("Precione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            //Inicializando um objeto do tipo livro

            var livro = new Livro
            {
                Titulo = "Sob a redoma",
                Autor = "Stephen King",
                Ano = 2012,
                Paginas = 679,
                Assunto = new List<string>
                {
                    "Ficção Científica",
                    "Terror",
                    "Ação"
                }
            };

            //Acesso ao servidor mongo db
            string stringConexao = "mongodb://localhost:27017";

            IMongoClient client = new MongoClient(stringConexao);

            //acesso ao banco de dados

            IMongoDatabase bancoDados = client.GetDatabase("Biblioteca");

            //Acesso a coleção

            IMongoCollection<Livro> collection = bancoDados.GetCollection<Livro>("Livros");

            //Incluindo Documento
            await collection.InsertOneAsync(livro);
            Console.WriteLine("Documento incluido");

        }
    }
}
