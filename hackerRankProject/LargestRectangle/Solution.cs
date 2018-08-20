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

namespace LargestRectangle
{
    

    class Solution
    {

        // Complete the largestRectangle function below.
        static long largestRectangle(int[] h)
        {
            List<int> buildings = new List<int>();
            buildings.AddRange(h);

            long minHeight = buildings.Min();
            return Solution.BruteForceMaxArea(buildings);
        }


        static long BruteForceMaxArea(List<int> list)
        {
            long curMaxArea = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = i+1; j < list.Count; ++j)
                {
                    long localArea = Convert.ToInt64(list[i]) * Convert.ToInt64(list[j]);
                    if (localArea > curMaxArea)
                    {
                        curMaxArea = localArea;
                    }
                }

            }


            return 1;
        }


        static void Main(string[] args)
        {
            string path = @"C:\Users\jason.nelson\Documents\projects\hackerRank\hackerRankTestFileGenerator\Stacks_and_Queues\largestRectangle_testFile.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                int n = Convert.ToInt32(sr.ReadLine());

                int[] h = Array.ConvertAll(sr.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
                ;
                long result = largestRectangle(h);

                Console.WriteLine(result);
            }
        }

        // Main function for web submission
        //static void Main(string[] args)
        //{
        //    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        //    int n = Convert.ToInt32(Console.ReadLine());

        //    int[] h = Array.ConvertAll(Console.ReadLine().Split(' '), hTemp => Convert.ToInt32(hTemp))
        //    ;
        //    long result = largestRectangle(h);

        //    textWriter.WriteLine(result);

        //    textWriter.Flush();
        //    textWriter.Close();
        //}
    }

}
