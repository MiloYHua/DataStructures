namespace TrieTreeAndNode
{
    public class TrieNode
    {
        public char Letter { get; private set; } // The letter of the current node
        public Dictionary<char, TrieNode> Children { get; private set; } // All known continuations from the current letter in the current prefix keyed off their beginning letters
        public bool IsWord { get; set; } // Whether or not the current node is at the end of a word

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = default;
            IsWord = false;
        }
        public TrieNode(char c)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = false;
        }
    }
}
