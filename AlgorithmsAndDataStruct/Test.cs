namespace Lesson6;

internal class Test
{
    internal static void Do(Node? expectedValue, Node? actualValue)
    {
        if (expectedValue?.Value == actualValue?.Value)
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