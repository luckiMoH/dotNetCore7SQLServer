int[] intsToCompress = new int[] { 10, 15, 20, 25, 30, 12, 34 };

DateTime startTime = DateTime.Now;
int totalValue = intsToCompress[0] + intsToCompress[1] + intsToCompress[2] + intsToCompress[3] + intsToCompress[4] + intsToCompress[5] + intsToCompress[6];

Console.WriteLine("Manual adding");
Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

Console.WriteLine(totalValue);
//146

totalValue = 0;
startTime = DateTime.Now;

for (int i = 0; i < intsToCompress.Length; i++)
{
    totalValue += intsToCompress[i];
}
Console.WriteLine("for Loop");
Console.WriteLine(totalValue);
Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

totalValue = 0;
startTime = DateTime.Now;

foreach (int i in intsToCompress)
{
    totalValue += i;
}
Console.WriteLine("foreach Loop");
Console.WriteLine(totalValue);
Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

totalValue = 0;
startTime = DateTime.Now;

int index = 0;

while(index < intsToCompress.Length)
{
    totalValue += intsToCompress[index];
    index++;
}
Console.WriteLine("While Loop");
Console.WriteLine(totalValue);
Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

totalValue = 0;
startTime = DateTime.Now;
index = 0;

do
{
    totalValue += intsToCompress[index];
    index++;
} while(index < intsToCompress.Length);
Console.WriteLine("Do while loop");
Console.WriteLine(totalValue);
Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

totalValue = 0;
startTime = DateTime.Now;

totalValue = intsToCompress.Sum();
Console.WriteLine("Sum method");
Console.WriteLine(totalValue);
Console.WriteLine((DateTime.Now - startTime).TotalSeconds);

Console.WriteLine("If conditions in Loops");

totalValue = 0;

foreach(int i in intsToCompress)
{
    if(i > 20)
    {
        totalValue += i;
    }
}

Console.WriteLine(totalValue);

