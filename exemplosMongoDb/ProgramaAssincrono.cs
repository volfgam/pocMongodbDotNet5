using System;
using System.Threading.Tasks;

namespace exemplosMongoDb
{
    class ProgramaAssincrono
    {
        static void Main(string[] args)
        {
            Task t = MainSync(args);
            Console.WriteLine("Precione ENTER");
            Console.ReadLine();
        }

        static async Task MainSync(string[] args)
        {
            Console.WriteLine("Esperando 10 segundos...");
            await Task.Delay(1000);
            Console.WriteLine("Já esperei!");
        }
    }
}
