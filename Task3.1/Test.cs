namespace Task3_1;

public class Test
{
    public static void Case<T>(T expectedValue, T realValue)
    {
        if (expectedValue.Equals(realValue))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("True.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"False. Expected value: {expectedValue}, but it was {realValue}.");
            Console.ResetColor();
        }
    }
}