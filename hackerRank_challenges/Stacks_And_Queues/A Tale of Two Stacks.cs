using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    
    public interface INode {
        int data {
            get;
            set;
        }
    }
    
    
    public interface IQueryNode : INode {

        int queryType{
            get;
            set;
        }
        
        IQueryNode next {
            get;
            set;
        }
        
    }
    
    public class QueryNode : IQueryNode {
        private int _queryType;
        private int _data;
        private IQueryNode _next;
        
        public int queryType {
            get { return _queryType; }
            set { _queryType = value; }
        }
        public int data {
            get { return _data; }
            set { _data = value; }
        }
        
        public IQueryNode next {
            get { return _next; }
            set { _next = value; }
        }
        
        public QueryNode() {
                   
        }

        
        public QueryNode(int queryTypeVal) {
            this.queryType = queryTypeVal;
        }
        
        public QueryNode(int queryTypeVal, int dataVal) {
            this.data = dataVal;
            this.queryType = queryTypeVal;
        }
    }
    
    
    
    public class Stack {
        private int nodeCount = 0;
        public IQueryNode top = new QueryNode();
        
        public int GetNodeCount() {
            return this.nodeCount;
        }
        
        private void IncrementNodeCount() {
            this.nodeCount++;
        }
        
        private void DecrementNodeCount() {
            this.nodeCount--;
        }
        
        public bool IsEmpty() {
            return this.top == null;
        }
        
        // methods
        public void put(IQueryNode newTop) {
            if(!this.IsEmpty()) {
                newTop.next = this.top;
                this.top = newTop;
            }
             
            this.IncrementNodeCount();
        }
        
        public IQueryNode pop() {
            IQueryNode poppedNode = this.top;
            this.top = poppedNode.next;
            this.DecrementNodeCount();
            return poppedNode;
        }
        
        public IQueryNode peek() {
            return this.top;
        }
    }
    
    class QueryNodeFactory {
        
        
        public IQueryNode BuildQuery(string[] rawQuery) {
            IQueryNode newQuery = new QueryNode();
            for (int j= 0 ; j < rawQuery.Length; j++) {
                if (j==0){
                    newQuery.queryType = Convert.ToInt32(rawQuery[j]);
                }
                else if (j == 1) {
                    newQuery.data = Convert.ToInt32(rawQuery[j]);
                }
                else {
                    Console.WriteLine("More than 2 elements passed in query row. Bad data?");
                }
            }
            
            return newQuery;
        }
    }
    
    class QueryDirector {        
        private Stack stack = new Stack();
        private Stack queueOrderedStack = new Stack();
        
        public bool Process(IQueryNode query) {
            return this.RouteQuery(query);
        }
        
        private bool RouteQuery(IQueryNode query) {
            // 1: x: Enqueue element  into the end of the queue.
            if(query.queryType == 1) {
                stack.put(query);
                return true;
            }
            // 2: Dequeue the element at the front of the queue.
            else if(query.queryType == 2) {
                // pop all stacked elements in popStack into queueStack
                for(int i=0; i < stack.GetNodeCount(); i++) {
                    queueOrderedStack.put(stack.pop());
                }
                queueOrderedStack.pop();
                
                for(int i=0; i < queueOrderedStack.GetNodeCount(); i++) {
                    stack.put(queueOrderedStack.pop());
                }
                return true;
                
            }
            // 3: Print the element at the front of the queue.
            else if(query.queryType == 3) {
                Console.WriteLine(queueOrderedStack.top);
                return true;
                
            }
            else {
                Console.WriteLine("QueryDirector: unexpected or null queryType");
                return false;
            }
            
        }
    }

    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
        
        int numOfQueries = Convert.ToInt32(Console.ReadLine());
        QueryNodeFactory factory = new QueryNodeFactory();
        QueryDirector director = new QueryDirector();
        
        int queryType;
        int queryData;
        
        for (int i = 0; i < numOfQueries; ++i) {
            string s = Console.ReadLine();
            string[] query = s.Split(' ');

            factory.BuildQuery(query);
            
            
            }
        }
}