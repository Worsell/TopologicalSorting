using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Graph;

namespace TopologicalSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<bool>> l = new List<List<bool>>();
            l.Add(new List<bool>() {false,false,false,false,false});
            l.Add(new List<bool>() {true,false,false,false,false});
            l.Add(new List<bool>() {false,true,false,false,false});
            l.Add(new List<bool>() {false,false,true,false,false});
            l.Add(new List<bool>() {false,false,false,true,false});
            List<int> m = new List<int>() {1,2,3,4,5};
            
            Graph<bool, int> g = new Graph<bool, int>(l, m);
                        
            // Каноничная сортировка на с# 
            List<int> arr = (from t in g select t).ToList();
            foreach(var x in arr)
                Console.WriteLine(x);
        }
    }
}