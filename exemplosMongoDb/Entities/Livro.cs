using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace exemplosMongoDb.Entities
{

    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }

        public static Livro IncluiValoresLivro(string titulo, string autor, int ano, int paginas, string assuntos)
        {
            string[] vetAssunto = assuntos.Split(',');

            var vetAssunto2 = new List<string>();
            
            for (int i = 0; i <= vetAssunto.Length - 1; i++)
            {
                vetAssunto2.Add(vetAssunto[i].Trim());
            }

            Livro Livro = new()
            {
                Titulo = titulo,
                Autor = autor,
                Ano = ano,
                Paginas = paginas,
                Assunto = vetAssunto2
            };

            return Livro;
        }
    }

}
