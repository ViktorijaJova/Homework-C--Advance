using System;
using System.Threading;

namespace Homework01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Traffic light...");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(" -----------------");
            Console.WriteLine(" |Red light STOP!|" );
            Thread.Sleep(2000);
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" |Yellow PREPARE!|");
            Thread.Sleep(2000);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" |Green light GO!|");
            Thread.Sleep(2000);
            Console.WriteLine(" -----------------");

            Console.ReadLine();
        }
    }
}
