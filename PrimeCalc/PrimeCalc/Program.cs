
using System;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using PrimeCalc;

class MainClass
{
    /* the main function below will find all the prime numbers between two numbers given as arguments, using threads that also given as argument */
    static void Main(string[] args)
    {
        // Check there is enough arguments
        if (args.Length != 3)
        {
            Console.WriteLine("Wrong number of arguments");
            return;
        }
        else
        {
            long firstNum = long.Parse(args[0]);
            long lastNum = long.Parse(args[1]);
            int numOfThreads = (int)long.Parse(args[2]);
            long range = (lastNum - firstNum) / numOfThreads;

            // Check the second number greater then the first.
            if (firstNum >= lastNum)
            {
                Console.WriteLine("The second number has to be bigger then the first.");
                return;
            }
            // Check the numbers are positive.
            if (firstNum < 0 || lastNum < 0)
            {
                Console.WriteLine("The numbers has to be positive.");
                return;
            }
            // Check the amount of threads is positive.
            if (numOfThreads <= 0)
            {
                Console.WriteLine("The number of threads has to be positive.");
                return;
            }

            PrimeCalculator primeCalculator = new PrimeCalculator();
            
            Thread[] threads = new Thread[numOfThreads];

            for (int i = 0; i < threads.Length; i++)
            {
                long tempNum = firstNum;
                // Give the last thread the rest of the numbers 
                if (i == numOfThreads - 1)
                {
                    threads[i] = new Thread(() => primeCalculator.findPrimes(tempNum, lastNum));
                    threads[i].Start();
                }
                // Divide the work by the range of the numbers
                else
                {
                    threads[i] = new Thread(() => primeCalculator.findPrimes(tempNum, tempNum + range));
                    threads[i].Start();
                    firstNum += range;

                }

            }

            // Waiting for all threads to complete
            foreach (Thread thread in threads)
            { thread.Join(); }


        }


    }


}




