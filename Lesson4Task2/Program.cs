using System;

namespace Lesson4
{
    class Lesson4
    {
        public static void Main()
        {
            // создадим небольшое дерево
            TreeNode node = new TreeNode();
            node.Value = 2;
            node.Left = new TreeNode()
            {
                Value = 4,
                Parent = node
            };
            node.Right = new TreeNode()
            {
                Value = 4,
                Parent = node
            };
            node.Left.Left = new TreeNode()
            {
                Value = 9,
                Parent = node.Left
            };
            node.Left.Right = new TreeNode()
            {
                Value = 8,
                Parent = node.Left
            };
            node.Right.Left = new TreeNode()
            {
                Value = 7,
                Parent = node.Right
            };
            node.Right.Right = new TreeNode()
            {
                Value = 6,
                Parent = node.Right
            };
            
            // добавим элемент
            node.Right.Left.AddItem(5);
            
            // выведем в консоль
            node.PrintTree();
        }
    }
}