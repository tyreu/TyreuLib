using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Stopwatch.StartNew();
            var res = Tyreu.String.Capitalize(string.Join(" ", Enumerable.Repeat("hello world", 100)));
            Console.WriteLine();
            Console.WriteLine(s.ElapsedMilliseconds);
        }
    }
}
