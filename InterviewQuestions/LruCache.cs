using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    /// <summary>
    /// Implements a Least Recently Used cache.
    /// </summary>
    /// <typeparam name="K">Type of the key.</typeparam>
    /// <typeparam name="V">Type of the value.</typeparam>
    public class LruCache<K,V> : ICache<K,V>
    {
        private LinkedList<Tuple<K,V>> list = new LinkedList<Tuple<K,V>>();
        private Dictionary<K,LinkedListNode<Tuple<K,V>>> dict = new Dictionary<K,LinkedListNode<Tuple<K,V>>>();
        private int maxSize;

        public LruCache(int size)
        {
            this.maxSize = size;
        }

        public V Get(K key)
        {
            if (dict.ContainsKey(key))
            {
                LinkedListNode<Tuple<K, V>> node = dict[key];
                list.Remove(node);
                list.AddFirst(node);
                return node.Value.Item2;
            }
            else
            {
                return default(V);
            }
        }

        public void Set(K key, V value)
        {
            if (dict.ContainsKey(key))
            {
                LinkedListNode<Tuple<K, V>> node = dict[key];
                node.Value = new Tuple<K, V>(key, value);
                list.Remove(node);
                list.AddFirst(node);
            }
            else
            {
                if (dict.Count == maxSize)
                {
                    LinkedListNode<Tuple<K, V>> node = list.Last;
                    list.RemoveLast();
                    dict.Remove(node.Value.Item1);
                }
                
                LinkedListNode<Tuple<K, V>> newNode = new LinkedListNode<Tuple<K, V>>(new Tuple<K, V>(key, value));
                dict.Add(key, newNode);
                list.AddFirst(newNode);
            }
        }
    }
}
