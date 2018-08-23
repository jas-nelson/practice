using System;
using System.Collections.Generic;
using System.IO;


namespace FibonacciNumbers
{

    class Solution
    {

        public static int Fibonacci(int n)
        {
            if (n==0)
            {
                return 0;
            }                       
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        static void Main(String[] args)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            int n = 25;
            Console.WriteLine(Fibonacci(n));
        }
    }
}
