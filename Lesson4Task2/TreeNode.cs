namespace Lesson4;

public class TreeNode : ITree
{
    public int Value { get; set; }
    public TreeNode Parent { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode()
    {
        
    }
    
    public override bool Equals(object? obj)
    {
        var node = obj as TreeNode;
            
        if (node == null)
            return false;
            
        return node.Value == Value;
    }

    /// <summary>
    /// Получение корневого элемента дерева
    /// </summary>
    /// <returns></returns>
    public TreeNode GetRoot()
    {
        TreeNode node = this;
        
        while (node.Parent != null)
        {
            node = node.Parent;
        }

        return node;
    }

    /// <summary>
    /// Добавление нового узла
    /// </summary>
    /// <param name="value"></param>
    public void AddItem(int value)
    {
        if (Left == null)
        {
            Left = new TreeNode();
            Left.Parent = this;
            Left.Value = value;

            return;
        }
        if (Right == null)
        {
            Right = new TreeNode();
            Right.Parent = this;
            Right.Value = value;

            return;
        }

        if (Left.Left == null || Left.Right == null)
            Left.AddItem(value);
        else
            Right.AddItem(value);
    }

    /// <summary>
    /// Получить узел по значению
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TreeNode GetNodeByValue(int value)
    {
        if (Value == value)
            return this;

        if (Left.GetNodeByValue(value) != null)
            return Left.GetNodeByValue(value);
        if (Right.GetNodeByValue(value) != null)
            Right.GetNodeByValue(value);
        
        return null;
    }
    
    /// <summary>
    /// Удалить узел по значению
    /// </summary>
    /// <param name="value"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void RemoveItem(int value)
    {
        TreeNode nodeToRemove = GetNodeByValue(value);
        
        if (nodeToRemove.Parent.Left.Value == value)
            Parent.Left = null;
        else
            Parent.Right = null;
    }

    /// <summary>
    /// Вывести дерево в консоль
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void PrintTree()
    {
        int depth = 0;
        
        foreach (var v in TreeHelper.GetTreeInLine(this))
        {
            if (v.Depth > depth)
            {
                Console.WriteLine();
                depth = v.Depth;
            }

            if (v.Node.Parent != null)
            {
                if (v.Node.Parent.Left == v.Node)
                    Console.Write("|");
                else
                    Console.Write(@"\");
            }
                
            Console.Write($"({v.Node.Value, 3} | {v.Depth})   ");
        }
    }
}