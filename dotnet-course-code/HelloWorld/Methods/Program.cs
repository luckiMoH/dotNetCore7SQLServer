namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intsToCompress = new int[] { 10, 15, 20, 25, 30, 12, 34 };

            int totalValue = 0;

            Console.WriteLine(totalValue);

            totalValue = GetSum(intsToCompress, totalValue);

            Console.WriteLine(totalValue);


        }

        static private int GetSum(int[] numbers, int sum)
        {
            foreach (int i in numbers)
            {
                sum += i;
            }
            return sum;
        }
    }
}