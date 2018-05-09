using System;

namespace Berry.UnitTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UnitTest test = new UnitTest();
            test.TestMethod();

            Console.ReadKey();
        }
    }
}