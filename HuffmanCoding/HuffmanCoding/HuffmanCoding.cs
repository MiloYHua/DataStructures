using System.Runtime.InteropServices;

namespace HuffmanCodingFile
{
    public class HuffmanNode
    {
        public char Val;
        public int Height;
        public int Frequency;

        public HuffmanNode LChild;
        public HuffmanNode RChild;

        public HuffmanNode(char val, int frequency)
        {
            Val = val;
            Frequency = frequency;
        }
    }
    public class HuffmanCoding
    {
        public PriorityQueue<HuffmanNode, int> priorityQueue;
        public Dictionary<char, int> charCounter;

        public HuffmanCoding()
        {
            priorityQueue = new();
            charCounter = [];
        }

        public void ParseText(string text)
        {
            foreach(char c in text)
            {
                CollectionsMarshal.GetValueRefOrAddDefault(charCounter, c, out _)++;
            }
        }
    }
}
