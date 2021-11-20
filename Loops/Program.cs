using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }
        private static bool IsPrimeNumber(int number)
        {
            bool result = true;
            for (int i = 2; i < number - 1; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
                return result;
            }
        }

    }

}
