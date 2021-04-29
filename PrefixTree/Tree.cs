

using System;
using System.Collections.Generic;

namespace PrefixTree
{
    class Tree<T>
    {
        /// <summary>
        /// main node - root node
        /// </summary>
        private Node<T> root;
        /// <summary>
        /// count of words
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// standard constructor for creating prefix tree
        /// </summary>
        public Tree()
        {
            root = new Node<T>('\0', default(T), prefix:"");
            Count = 0;
        }

        /// <summary>
        /// adding new word
        /// </summary>
        /// <param name="key">word</param>
        /// <param name="data">word's data</param>
        public void Add(string key, T data=default(T))
        {
            AddNode(key, data, root);
        }

        /// <summary>
        /// private sub adding
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="node"></param>
        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                    Count++;
                }
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);


                if (subnode != null)
                {
                    AddNode(key.Substring(1), data, subnode);
                }
                else
                {
                    var newNode = new Node<T>(symbol, data, prefix:node.Prefix + symbol);
                    node.AddNode(newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
            }
        }

        /// <summary>
        /// Remove the word
        /// </summary>
        /// <param name="key">removing word</param>
        public void Remove(string key) 
        {
            bool check = RemoveNode(key: key, node: root);
            if(check == true)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }

        /// <summary>
        /// private sub method for removing word
        /// </summary>
        /// <param name="key"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool RemoveNode(string key, Node<T> node)
        {
            if(string.IsNullOrWhiteSpace(key))
            {
                if(node.IsWord)
                {
                    node.IsWord = false;
                    return true;
                }
            }
            else
            {
                char symbol = key[0];
                Node<T> subtree = node.TryFind(symbol);
                if (subtree != null)
                {
                    return RemoveNode(key.Substring(1), subtree);
                }
            }
            return false;
        }

        /// <summary>
        /// Search the word 
        /// return true if word is found; else return false
        /// </summary>
        /// <param name="key">word</param>
        /// <param name="value">word's data if it is existing</param>
        /// <returns></returns>
        public bool TrySearch(string key, out T value)
        {
            bool result = SearchNode(key: key, node: root, out value);

            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// private sub method for searching word
        /// </summary>
        /// <param name="key"></param>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool SearchNode(string key, Node<T> node, out T value)
        {
            bool result = false;
            value = default(T);

            if(string.IsNullOrWhiteSpace(key))
            {
                if(node.IsWord)
                {
                    result = true;
                    value = node.Data;
                }
            }
            else
            {
                char symbol = key[0];
                Node<T> subtree = node.TryFind(symbol);
                if(subtree != null)
                {
                    result = SearchNode(key: key.Substring(1), node: subtree, out value);
                }
            }
            return result;
        }
    }
}
