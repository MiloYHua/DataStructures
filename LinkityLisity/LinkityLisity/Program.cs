namespace LinkityLisity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkityLisity<int> linkityLisity = new LinkityLisity<int>();

            linkityLisity.AddFirst(1);
            linkityLisity.AddFirst(-1);
            linkityLisity.AddLast(2);
            linkityLisity.AddLast(3);
            linkityLisity.AddAfter(linkityLisity.Head.next.next, 1);
            linkityLisity.AddBefore(linkityLisity.Tail, 5);
            bool decapitated = linkityLisity.RemoveFirst();
            bool crippled = linkityLisity.RemoveLast();
            bool removed = linkityLisity.Remove(1000);
            linkityLisity.Clear();

            

            Node<int> result = linkityLisity.Search(1);

            bool found = linkityLisity.Contains(1);
        }
    }
}
