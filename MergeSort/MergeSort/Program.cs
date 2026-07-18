using System.ComponentModel.Design;

namespace MergeSort
{
	public class Program
	{

		static void Main(string[] args)
		{
			List<int> ints = [10, -1, 3, 5, 2, -1, -2, 9, 8, 2];

			ints = Sorts<int>.MergeSort(ints);

			for (int i = 0; i < ints.Count; i++)
			{
				Console.WriteLine(ints[i]);
			}
		}
	}
}
