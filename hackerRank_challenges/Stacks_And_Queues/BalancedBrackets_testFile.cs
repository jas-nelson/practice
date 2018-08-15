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

class Solution {

    // Complete the isBalanced function below.
    static string isBalanced(string s) {
        Stack<char?> stack = new Stack<char?>();
        Dictionary<char?,char> matchFinder = new Dictionary<char?,char>();
        matchFinder.Add('}','{');
        matchFinder.Add(')','(');
        matchFinder.Add(']','[');
        
        
        for(int i = 0; i < s.Length; ++i) {
            char? cur = s[i];            
            Nullable<char> match;
            
            //PrintStack(stack);
            
            if (cur == '{' | cur == '(' | cur == '[') {
                //Console.WriteLine("Pushed " + cur.ToString() + " to stack.");
                stack.Push(cur);
            }
            else if (stack.Count == 0 && (cur == '}' | cur == ')' | cur == ']')){
                Console.WriteLine("i value: " + i.ToString());
                Console.WriteLine("cur value should close this char : " + match.ToString());
                Console.WriteLine("cur value: " + cur.ToString());
                Console.WriteLine("string supplied: " + s);
                PrintStack(stack);
                Console.WriteLine("Answer choice: NO\n");
                return "NO";
                }
            else {
                match = stack.Pop();
                
                if (match.HasValue && matchFinder[cur] != match) {
                    Console.WriteLine("i value: " + i.ToString());
                    Console.WriteLine("cur value should close this char : " + match.ToString());
                    Console.WriteLine("cur value: " + cur.ToString());
                    Console.WriteLine("string supplied: " + s);
                    PrintStack(stack);
                    Console.WriteLine("Answer choice: NO\n");
                    return "NO";
                }
            }
        }
        
        Console.WriteLine("string supplied: " + s);
        PrintStack(stack);
        Console.WriteLine("Answer choice: YES\n");
        if (stack.Count == 0){
            return "YES";    
        }
        else {
            return "NO";
        }
        
    }
    
    static void PrintStack(Stack<char?> stack) {
        if (stack.Count == 0) {
            Console.WriteLine("Stack is Empty.");
            return;
        }
        
        string s = "Stack: ";
        foreach (char? val in stack) {
            s = s + val;
        }
        Console.WriteLine(s);
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
