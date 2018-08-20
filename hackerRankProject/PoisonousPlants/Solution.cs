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

class Solution
{

    public interface INode
    {
        int data
        {
            get;
            set;
        }
    }


    public interface IPlantNode
    {
        IPlantNode next
        {
            get;
            set;
        }
        int AmountOfPesticide
        {
            get;
            set;
        }
    }

    public class PlantNode : IPlantNode
    {
        private int _amountOfPesticide;
        private IPlantNode _next;
        public IPlantNode next
        {
            get
            {
                return this._next;
            }
            set
            {
                this._next = value;
            }
        }

        public PlantNode(int pesticideAmount)
        {
            this.AmountOfPesticide = pesticideAmount;
        }

        public PlantNode(int pesticideAmount, IPlantNode nextNode)
        {
            this.AmountOfPesticide = pesticideAmount;
            this.next = nextNode;

        }

        public int AmountOfPesticide
        {
            get
            {
                return this._amountOfPesticide;
            }
            set
            {
                this._amountOfPesticide = value;
            }
        }
    }


    public interface IPlantQueue
    {
        int Count
        {
            get;
            set;
        }
        IPlantNode head
        {
            get;
            set;
        }

        IPlantNode tail
        {
            get;
            set;
        }

        bool isEmpty();
        void enqueue(IPlantNode node);
        IPlantNode dequeue();

    }

    public class PlantQueue : IPlantQueue
    {
        private IPlantNode _head = null;
        private IPlantNode _tail = null;
        private int _Count = 0;
        public int Count
        {
            get
            {
                return this._Count;
            }
            set
            {
                this._Count = value;
            }
        }
        public IPlantNode head
        {
            get
            {
                return this._head;
            }
            set
            {
                this._head = value;
            }
        }

        public IPlantNode tail
        {
            get
            {
                return this._tail;
            }
            set
            {
                this._tail = value;
            }
        }

        public bool isEmpty()
        {
            return this.head == null;
        }

        public void enqueue(IPlantNode node)
        {
            if (this.isEmpty())
            {
                this.head = node;
                this.tail = node;
            }

            else
            {
                this.tail.next = node;
                this.tail = node;
                this.tail.next = null;
            }
            this.Count++;
        }

        public IPlantNode dequeue()
        {
            if (this.isEmpty())
            {
                return null;
            }
            else
            {
                IPlantNode returnNode = this.head;
                this.head = returnNode.next;
                this.Count--;
                return returnNode;
            }
        }


    }


    // Complete the poisonousPlants function below.
    static int poisonousPlants(int[] p)
    {
        int numOfDays = 0;
        IPlantQueue plantQueue = new PlantQueue();
        for (int i=0; i < p.Length; ++i)
        {
            plantQueue.enqueue(new PlantNode(p[i]));
        }

        int? initalNumOfPlants = null;
        int? updatedNumOfPlants = null;
        while (true)
        {
            initalNumOfPlants = plantQueue.Count;
            plantQueue = SimulateDay(plantQueue);
            updatedNumOfPlants = plantQueue.Count;
            if (initalNumOfPlants == updatedNumOfPlants)
            {
                break;
            }
            numOfDays++;
        }

        return numOfDays;
    }

    static IPlantQueue SimulateDay (IPlantQueue currentPlants)
    {
        int initNumOfPlants = currentPlants.Count;
        IPlantQueue survivingPlants = new PlantQueue();
        IPlantNode left = null;
        IPlantNode right = null;

        while(!currentPlants.isEmpty())
        {
            if (left == null)
            {
                left = currentPlants.dequeue();
                survivingPlants.enqueue(left);
                continue;
            }

            right = currentPlants.dequeue();

            if (right.AmountOfPesticide <= left.AmountOfPesticide)
            {
                survivingPlants.enqueue(right);
            }

            left = right;
        }

        return survivingPlants;

    }

    static void Main(string[] args)
    {
        string path = @"C:\Users\jason.nelson\Documents\projects\hackerRank\hackerRankTestFileGenerator\Stacks_and_Queues\poisonousPlants_testFile_simple.txt";

        using (StreamReader sr = new StreamReader(path))
        {
            int n = Convert.ToInt32(sr.ReadLine());

            int[] p = Array.ConvertAll(sr.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp));
            int result = poisonousPlants(p);

            Console.WriteLine(result);
        }
    }



    //    static void Main(string[] args)
    //    {
    //        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    //        int n = Convert.ToInt32(Console.ReadLine());

    //        int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), pTemp => Convert.ToInt32(pTemp));
    //        int result = poisonousPlants(p);

    //        textWriter.WriteLine(result);

    //        textWriter.Flush();
    //        textWriter.Close();
    //    }
}
