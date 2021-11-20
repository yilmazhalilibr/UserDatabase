using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //WhileLoop();
            //DoWhileLoop();
            string[] a = { "DJ", "DİKKAT", "ALİMÜNYUM", "123", "123123", "mp2ı35jm", "1123oksjkowq" };
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }


        }

        private static void DoWhileLoop()
        {
            int number = 10;
            do
            {
                Console.WriteLine(number);
                number--;
            } while (number >= 0);
        }

        private static void WhileLoop()
        {
            int y = 31;
            int x = 25;
            while (x >= 0)
            {
                Console.WriteLine(x);
                x--;
            }
            Console.WriteLine("Numara {0}", x);
            Console.ReadLine();
        }

        private static void ads()
        {
            string[] a = { "DJ", "DİKKAT", "ALİMÜNYUM", "123", "123123", "mp2ı35jm", "1123oksjkowq" };

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }

        }
    }
}
