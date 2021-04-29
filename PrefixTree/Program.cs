using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();

            tree.Add("hello", 50);
            tree.Add("world", 100);
            tree.Add("help", 200);
            tree.Add("oracle", 200);
            tree.Add("garage", 200);
            tree.Add("come", 200);
            tree.Add("home", 200);
            tree.Add("city", 200);

            tree.Remove("come");
            tree.Remove("garage");

            Search(tree, "come");
        }

        /// <summary>
        /// Realization the method "search" to simplify it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree">main tree</param>
        /// <param name="word">found word</param>
        private static void Search<T>(Tree<T> tree, string word)
        {
            if(tree.TrySearch(word, out T value))
            {
                Console.WriteLine(word + " " + value);
            }
            else
            {
                Console.WriteLine("No data");
            }
        }
    }
}
