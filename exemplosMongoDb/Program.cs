using System;

namespace exemplosMongoDb
{
    class Program
    {
        static void Main(string[] args)
        {
            MainSync(args);
            Console.WriteLine("Precione ENTER");
            Console.ReadLine();
        }

        static void  MainSync(string[] args)
        {
            Console.WriteLine("Esperando 10 segundos...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Já esperei!");
        }
    }
}
