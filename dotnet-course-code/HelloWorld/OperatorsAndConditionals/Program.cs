namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int myInt = 5;
            int mySecondInt = 10;

            string myString = "Hello.";

            //Console.WriteLine(myString);

            myString += " second part.";

            //Console.WriteLine(myString);

            myString = myString + " \\third one";

            //Console.WriteLine(myString);

            string[] myStringArr = myString.Split(". ");

            //Console.WriteLine(myStringArr[0]);
            //Console.WriteLine(myStringArr[1]);
            //Console.WriteLine(myStringArr[2]);

            if (myInt < mySecondInt)
            {
                myInt++;
                Console.WriteLine(myInt);
            }
            
        }
    }
}