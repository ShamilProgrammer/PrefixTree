

using System;
using System.Collections.Generic;

namespace PrefixTree
{
    class Node<T>
    {
        /// <summary>
        /// Symbol of node
        /// </summary>
        public char Symbol { get; set; }
        /// <summary>
        /// Data of node
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Check if it's a whole word
        /// </summary>
        public bool IsWord { get; set; }
        /// <summary>
        /// Previous getting word
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// dictionary of subnodes for words
        /// </summary>
        public Dictionary<char, Node<T>> SubNodes { get; set; }

        /// <summary>
        /// standard constructor for creating node
        /// </summary>
        /// <param name="symbol">wishing symbol</param>
        /// <param name="data">sending data</param>
        /// <param name="prefix">getting prefix</param>
        public Node(char symbol, T data, string prefix)
        {
            SubNodes = new Dictionary<char, Node<T>>();
            Symbol = symbol;
            Data = data;
            Prefix = prefix;
        }

        /// <summary>
        /// try to find the element
        /// </summary>
        /// <param name="symbol">finding symbol</param>
        /// <returns></returns>
        public Node<T> TryFind(char symbol)
        {
            if (SubNodes.TryGetValue(symbol, out Node<T> value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// adding the node to the dictionary
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node<T> node)
        {
            SubNodes.Add(node.Symbol, node);
        }

        public override string ToString()
        {
            return $"{Data} {Prefix} [{SubNodes.Count}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.Equals(item.Data);
            }
            return false;
        }
    }
}
