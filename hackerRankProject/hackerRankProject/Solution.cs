using System;
using System.Collections.Generic;
using System.IO;


namespace hackerRankProject
{

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


        public interface IQueryNode : INode
        {

            int queryType
            {
                get;
                set;
            }

            IQueryNode next
            {
                get;
                set;
            }

        }

        public class QueryNode : IQueryNode
        {
            private int _queryType;
            private int _data;
            private IQueryNode _next;

            public int queryType
            {
                get { return _queryType; }
                set { _queryType = value; }
            }
            public int data
            {
                get { return _data; }
                set { _data = value; }
            }

            public IQueryNode next
            {
                get { return _next; }
                set { _next = value; }
            }

            public QueryNode()
            {

            }


            public QueryNode(int queryTypeVal)
            {
                this.queryType = queryTypeVal;
            }

            public QueryNode(int queryTypeVal, int dataVal)
            {
                this.data = dataVal;
                this.queryType = queryTypeVal;
            }
        }



        public class Stack
        {
            private int nodeCount = 0;
            public IQueryNode top = null;

            public int GetNodeCount()
            {
                return this.nodeCount;
            }

            private void IncrementNodeCount()
            {
                this.nodeCount++;
            }

            private void DecrementNodeCount()
            {
                this.nodeCount--;
            }

            public bool IsEmpty()
            {
                return this.top == null;
            }

            // methods
            public void put(IQueryNode newTop)
            {
                if (!this.IsEmpty())
                {
                    newTop.next = this.top;
                    this.top = newTop;
                }
                else
                {
                    this.top = newTop;
                }

                this.IncrementNodeCount();
            }

            public IQueryNode pop()
            {
                IQueryNode poppedNode = this.top;
                this.top = poppedNode.next;
                poppedNode.next = null;
                this.DecrementNodeCount();
                return poppedNode;
            }

            public IQueryNode peek()
            {
                return this.top;
            }
        }

        class QueryNodeFactory
        {


            public IQueryNode BuildQuery(string[] rawQuery)
            {
                IQueryNode newQuery = new QueryNode();
                for (int j = 0; j < rawQuery.Length; j++)
                {
                    if (j == 0)
                    {
                        newQuery.queryType = Convert.ToInt32(rawQuery[j]);
                    }
                    else if (j == 1)
                    {
                        newQuery.data = Convert.ToInt32(rawQuery[j]);
                    }
                    else
                    {
                        Console.WriteLine("More than 2 elements passed in query row. Bad data?");
                    }
                }

                return newQuery;
            }
        }

        class QueryDirector
        {
            private Stack stack = new Stack();
            private Stack queueOrderedStack = new Stack();

            public bool Process(IQueryNode query, ref string strOutput)
            {
                return this.RouteQuery(query, ref strOutput);
            }

            private bool RouteQuery(IQueryNode query, ref string strOutput)
            {
                // 1: x: Enqueue element  into the end of the queue.
                if (query.queryType == 1)
                {
                    stack.put(query);
                    return true;
                }
                // 2: Dequeue the element at the front of the queue.
                else if (query.queryType == 2)
                {
                    if (!queueOrderedStack.IsEmpty())
                    {
                        queueOrderedStack.pop();
                        return true;
                    }

                    else
                    {
                        // pop all stacked elements in popStack into queueStack
                        int startingStackCount = stack.GetNodeCount();
                        for (int i = 0; i < startingStackCount; i++)
                        {
                            queueOrderedStack.put(stack.pop());
                        }

                        queueOrderedStack.pop();
                        return true;
                    } 

                }
                // 3: Print the element at the front of the queue.
                else if (query.queryType == 3)
                {
                    if (!queueOrderedStack.IsEmpty())
                    {
                        strOutput = queueOrderedStack.peek().data.ToString();
                        return true;
                    }

                    else
                    {
                        // pop all stacked elements in popStack into queueStack
                        int startingStackCount = stack.GetNodeCount();
                        for (int i = 0; i < startingStackCount; i++)
                        {
                            queueOrderedStack.put(stack.pop());
                        }

                        strOutput = queueOrderedStack.peek().data.ToString();
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("QueryDirector: unexpected or null queryType");
                    return false;
                }

            }
        }


        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string path = @"C:\Users\jason.nelson\Documents\projects\hackerRank\hackerRankTestFileGenerator\Stacks_and_Queues\tale_of_two_stacks_testFile.txt";

            using (StreamReader sr = new StreamReader(path)) {

                //int numOfQueries = Convert.ToInt32(Console.ReadLine());
                int numOfQueries = Convert.ToInt32(sr.ReadLine());
                QueryNodeFactory factory = new QueryNodeFactory();
                QueryDirector director = new QueryDirector();

                int queryType;
                int queryData;

                
                List<string> results = new List<string>();

                for (int i = 0; i < numOfQueries; ++i)
                {
                    //string s = Console.ReadLine();
                    string outputStr = null;
                    string s = sr.ReadLine();
                    string[] query = s.Split(' ');

                    director.Process(factory.BuildQuery(query), ref outputStr);
                    if (!String.IsNullOrEmpty(outputStr))
                    {
                        results.Add(outputStr);
                    }
                }

                foreach (string val in results) {
                    Console.WriteLine(val);
                }
                
            }
        }
    }
}
