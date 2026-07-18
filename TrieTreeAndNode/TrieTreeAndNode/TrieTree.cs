using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace TrieTreeAndNode
{
    public class TrieTree
    {
        TrieNode sentinel;

        public TrieTree()
        {
            sentinel = new TrieNode();
        }

        public void Clear() => sentinel = new TrieNode(); // Delete all data in the Trie

        public void Insert(string word) // Add a word to the Trie   
        {
            TrieNode node = sentinel;

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (node.Children.TryGetValue(currentChar, out TrieNode value))
                {
                    node = value;
                    continue;
                }
                node.Children.Add(currentChar, new TrieNode(currentChar));
                node = node.Children[currentChar];
            }
            node.IsWord = true;
        }

        private TrieNode SearchNode(string prefix) // Find the node at the end of this prefix. Use this function WHENEVER you need to find a node.
        {
            TrieNode node = sentinel;

            for (int i = 0; i < prefix.Length; i++)
            {
                if (node.Children.ContainsKey(prefix[i]))
                {
                    node = node.Children[prefix[i]];
                    continue;
                }
                return null;
            }
            return node;
        }

        public bool Contains(string word) => SearchNode(word) is not null; // Return if a given word exists (use SearchNode)

        public List<string> GetAllMatchingPrefix(string prefix) // Get every word after a given prefix
        {
            TrieNode prefixNode = sentinel;
            string prefixWord = "";

            StringBuilder sb = new();

            for (int i = 0; i < prefix.Length; i++)
            {
                if (prefixNode.Children.ContainsKey(prefix[i]))
                {
                    prefixNode = prefixNode.Children[prefix[i]];
                    prefixWord += prefixNode.Letter;
                    sb.Append(prefixNode.Letter);
                    continue;
                }
                return new List<string>();
            }

            int temp = 0;
            List<string> stringsToReturn = RecusiveDepthFirstPrefixSearchNewAndImprovedAndCool(new List<string>(), "", ref temp, prefixNode);

            for (int i = 0; i < stringsToReturn.Count; i++)
            {
                stringsToReturn[i] = prefixWord + stringsToReturn[i][1..];
            }

            return stringsToReturn;
        }

        List<string> RecusiveDepthFirstPrefixSearchNewAndImprovedAndCool(List<string> strings, string currentString, ref int fullWordIndex, TrieNode node)
        {
            if (node.IsWord)
            {
                strings.Add(currentString + node.Letter);
                fullWordIndex++;
            }

            if (node.Children.Count == 0)
            {
                return strings;
            }

            foreach (char c in node.Children.Keys)
            {
                RecusiveDepthFirstPrefixSearchNewAndImprovedAndCool(strings, currentString + node.Letter, ref fullWordIndex, node.Children[c]);
            }

            return strings;
        }

        public bool Remove(string word) // Remove a given word if it exists, and return if you found it
        {
            TrieNode node = sentinel;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.Children.ContainsKey(word[i])) node = node.Children[word[i]];

                else return false;

                if (node.Children.Count > 0) continue;

                node = null;
                return true;
            }

            node.IsWord = false;
            return true;
        }
    }
}
