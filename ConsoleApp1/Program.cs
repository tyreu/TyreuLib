using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var s = Stopwatch.StartNew();
            //Tyreu.String.Capitalize(string.Join(" ", Enumerable.Repeat("hello world", 100)));
            Console.WriteLine(Tyreu.String.IsAnagram("testt", "tesst"));
        }
    }
}
