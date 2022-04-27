using System;

namespace Lesson5
{
    class Lesson5
    {
        public static void Main()
        {
            // Создадим дерево
            var node = new TreeNode(1)
            {
                Left = new TreeNode(10)
                {
                    Left = new TreeNode(4),
                    Right = new TreeNode(8)
                },
                Right = new TreeNode(5)
                {
                    Left = new TreeNode(2),
                    Right = new TreeNode(7)
                }
            };

            Test.Do(node.Left, node.BreadthFirstSearch(10)); // successful
            Test.Do(node.Left, node.DeepFirstSearch(10)); // successful
            
            Test.Do(node.Left.Left, node.BreadthFirstSearch(4)); // successful
            Test.Do(node.Left.Left, node.DeepFirstSearch(4));  // successful
        }
    }
}