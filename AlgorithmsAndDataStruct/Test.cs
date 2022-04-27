namespace Lesson5;

public class Test
{
    public static void Do(TreeNode expected, TreeNode actual)
    {
        int count = 0;
                    
        if (expected.Value == actual.Value)
            count++;
        if (expected.Left == actual.Left)
            count++;
        if (expected.Right == actual.Right)
            count++;

        if (count == 3)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successful test");
            Console.ResetColor();
                
            return;
        }
            
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Unsuccessful test");
        Console.ResetColor();
    }
}