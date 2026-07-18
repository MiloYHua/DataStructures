using System.ComponentModel;

namespace DubiouslyKirkularlyLinkityLisity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DubiouslyKirkularlyLinkityLisity<object> linkityLisity = new();

            linkityLisity.AddFirst("bobby");
            linkityLisity.AddLast("a;sldjngfj;znfgjzndxfklznsjr;hDSFHZ");
            linkityLisity.AddAfter(linkityLisity.Head, 2340957);
            linkityLisity.RemoveFirst();
            bool alexanderTheMyInstructor = linkityLisity.Contains(2340957);
            Node<object> brandonDaoTheOtherGuyMaybeAnInstructor = linkityLisity.Search("a;sldjngfj;znfgjzndxfklznsjr;hDSFHZ");

            linkityLisity.Clear();
        }
    }
}
