using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCalc
{
    public class PrimeCalculator
    {
        public PrimeCalculator()
        {
        }


        /* The function below will check if the number is a prime number */
        private bool isPrime(long n)
        {
            if (n == 2 || n == 3)
                return true;

            if (n <= 1 || n % 2 == 0 || n % 3 == 0)
                return false;
            for (int i = 5; i <= Math.Sqrt(n); i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }
            return true;
        }

        /* The function below will find and print all the prime numbers between the two numbers */
        public void findPrimes(long firstNum, long secondNum)
        {
            while (firstNum < secondNum)
            {
                if (isPrime(firstNum))
                {
                    Console.WriteLine("Thread [" + Thread.CurrentThread.ManagedThreadId + "]: " + firstNum);

                }

                firstNum++;
            }
        }
    }
}
