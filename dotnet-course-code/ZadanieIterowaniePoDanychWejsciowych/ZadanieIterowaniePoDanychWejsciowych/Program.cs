namespace ZadanieIterowaniePoDanychWejsciowych
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Podaj liczbę:");
            string userInputString;

            List<int> userInputs = new List<int>();

            do
            {
                userInputString = Console.ReadLine();
                Console.WriteLine($"Echo : {userInputString}");
                int userInputInt = int.Parse(userInputString);
                userInputs.Add(userInputInt);

            } while (userInputString != "0");

            int summarize = userInputs.Sum();

            int biggestNumber = userInputs[0];
            foreach (int inputInt in userInputs)
            {
                if (inputInt > biggestNumber)
                {
                    biggestNumber = inputInt;
                }
            }

            Console.WriteLine($"Największa liczba to: {biggestNumber}");

            Console.WriteLine($"Suma wszystkich liczb to: {summarize}");

        }
    }
}