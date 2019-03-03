using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace Graph
{
    
    public class Graph <V, E> : IEnumerable<E>
    {

        private List<List<V>> data;

        private List<E> nodes;

        public Graph(List<List<V>> v, List<E> n)
        {
            data = v;
            nodes = n;

        }

        
        
        
        private IEnumerator<E> dfs(int n, List<bool> visited, List<E> answer)
        {
            visited[n] = true;
            List<V> node = data[n];
            for (int x = 0; x < node.Count; x++)
            {
                if (!visited[x])
                {
                    dfs(x, visited, answer);
                }
            }
            yield return nodes[n];
        }
        
        private IEnumerator<E> TopologicalSort()
        {
            List<bool> visited = new List<bool>();
            List<E> answer = new List<E>();
            for (int x = 0; x < nodes.Count; x++)
            {
                visited.Add(false);
            }
            for (int x = 0; x < data.Count; x++)
            {
                if (!visited[x])
                {
                    IEnumerator<E> ans = dfs(x, visited, answer);
                    while (ans.MoveNext())
                        yield return ans.Current;
                }
            }
        }
            
        public IEnumerator<E> GetEnumerator()
        {
            return TopologicalSort();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}