namespace Lesson7;

internal class Test
{
    internal static void Do(int expectedValue, int actualValue)
    {
        if (expectedValue == actualValue)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("+ Done");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("- Failed");
            Console.ResetColor();
        }
    }
}