namespace MyList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> numbers = new MyList<int>(4);
            numbers.Add(1);
            numbers.Add(2);
            numbers.IndexRemove(0);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Remove(6);
            numbers.GetIndex(2);

            for (int i = 0; i < numbers.Capacity; i++)
            {
                Console.WriteLine(numbers.data[i]);
            }
            Console.WriteLine(numbers.Capacity);
        }
    }
}
