using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace DavisStaircase_factorial_permutation
{
    

    class Solution
    {
        public class Factorial
        {
            private Dictionary<int, double> storedValues = null;
            public Factorial()
            {
                this.storedValues = new Dictionary<int, double>();
            }


            public double Calculate(int n)
            {
                double storedFactorial = 0;
                if (n == 1)
                {
                    return 1;
                }
                else if (storedValues.TryGetValue(n, out storedFactorial))
                {
                    return storedFactorial;
                }
                else
                {
                    storedValues[n] = n * this.Calculate(n - 1);
                    return storedValues[n];
                }
            }

        }

        public class Permuation
        {
            private Factorial factorial;
            public Permuation()
            {
                this.factorial = new Factorial();
            }

            public int Calculate(int n, int r)
            {

                return Convert.ToInt32(this.factorial.Calculate(n) / this.factorial.Calculate(n - r));
            }


        }



        // Complete the stepPerms function below.
        static int stepPerms(int n, ref Permuation perm)
        {
            int result = 0;
            
            for (int r=1; r < 4; ++r )
            {
                if (n-r >= 0)
                {
                    result += perm.Calculate(n, r);
                }
            }


            return result;

        }

        static void Main(string[] args)
        {
            string path = @"C:\Users\jason.nelson\Documents\projects\hackerRank\hackerRankTestFileGenerator\recursion\davis_staircase_testFile.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                //int n = Convert.ToInt32(sr.ReadLine());

                //int[] p = Array.ConvertAll(sr.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp));
                //int result = poisonousPlants(p);

                int s = Convert.ToInt32(sr.ReadLine());
                Permuation perm = new Permuation();

                for (int sItr = 0; sItr < s; sItr++)
                {
                    int n = Convert.ToInt32(sr.ReadLine());
                    int res = stepPerms(n, ref perm);

                    Console.WriteLine(res);
                }
            }
        }


        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //    int s = Convert.ToInt32(Console.ReadLine());

        //    for (int sItr = 0; sItr < s; sItr++)
        //    {
        //        int n = Convert.ToInt32(Console.ReadLine());

        //        int res = stepPerms(n);

        //        textWriter.WriteLine(res);
        //    }

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }

}
