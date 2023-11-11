using Models.Models;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            int[] intsToCompress = new int[] { 10, 15, 20, 25, 30, 12, 34 };

            int totalValue = 0;

            Console.WriteLine(totalValue);

            totalValue = GetSum(intsToCompress, totalValue);

            Console.WriteLine(totalValue);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                CPUCores = 8,
                VideoCard = "RTX 2060"
            };
            myComputer.HasWifi = false;
            Console.WriteLine(myComputer.Motherboard);
            Console.WriteLine(myComputer.HasWifi);
            Console.WriteLine(myComputer.ReleaseDate);
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