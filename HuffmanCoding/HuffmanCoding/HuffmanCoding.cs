using System.Runtime.InteropServices;

namespace HuffmanCodingFile
{
    public class HuffmanNode
    {
        public char Val;
        public int Height;
        public int Frequency;
        public bool IsLeaf;


        public HuffmanNode LChild;
        public HuffmanNode RChild;

        public HuffmanNode(char val, int frequency)
        {
            Val = val;
            Frequency = frequency;
            IsLeaf = true;
        }
        public HuffmanNode(int frequency, HuffmanNode left, HuffmanNode right)
        {
            Val = '^';
            Frequency = frequency;
            LChild = left;
            RChild = right;
            IsLeaf = false;
        }
    }
    public class HuffmanCoding
    {
        public PriorityQueue<HuffmanNode, int> priorityQueue;
        public Dictionary<char, int> charCounter;
        public Dictionary<char, byte> charToCode;
        public HuffmanNode Root;
        private string text;

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
            this.text = text;
        }

        public void BuildTree()
        {
            foreach (KeyValuePair<char, int> kvp in charCounter)
            {
                priorityQueue.Enqueue(new HuffmanNode(kvp.Key, kvp.Value), kvp.Value);
            }

            while (priorityQueue.Count > 1)
            {
                HuffmanNode left = priorityQueue.Dequeue();
                HuffmanNode right = priorityQueue.Dequeue();
                HuffmanNode parent = new HuffmanNode(left.Frequency + right.Frequency, left, right);

                priorityQueue.Enqueue(parent, parent.Frequency);
            }
            
            Root = priorityQueue.Dequeue();
        }

        public void Encode()
        {
            Stack<HuffmanNode> toVisit = [];
            toVisit.Push(Root);
            byte currentCode = 0;

            while (true)
            {
                HuffmanNode current = toVisit.Pop();

                if(current.IsLeaf)
                {
                    charToCode.Add(current.Val, currentCode);
                    currentCode = 0;
                }
            }
                foreach (char c in text)
            {
                
            }
        }
    }
}
