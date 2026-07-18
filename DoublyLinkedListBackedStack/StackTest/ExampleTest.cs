namespace StackTest
{
	public class ExampleTest
	{
		[Fact]
		public void AddTwoIntsTest()
		{
			int a = 1;
			int b = 2;

			int answer = a + b;

			int expectedAnswer = 3;

			Assert.Equal(expectedAnswer, answer);			
		}
	}
}