using HuffmanCodingFile;
using System.Reflection.Metadata;

namespace HuffmanTesting
{
    public class UnitTest1
    {
        [Fact]
        public void ParseText()
        {
            HuffmanCoding huffman = new();
            int count = 0;
            string text = "m, i, l, o";
            huffman.ParseText(text);
            foreach (KeyValuePair<char, int> kvp in huffman.charCounter)
            {
                count += kvp.Value;
            }
            Assert.Equal(text.Length, count);
        }
    }
}
