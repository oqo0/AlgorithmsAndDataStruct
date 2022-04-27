namespace Lesson5;

public class TreeNode
{
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
    public int Value { get; set; }
    private Queue<TreeNode> elementsQueue { get; } = new Queue<TreeNode>();
    private Stack<TreeNode> elementsStack { get; } = new Stack<TreeNode>();

    public TreeNode(int value)
    {
        Value = value;
    }

    /// <summary>
    /// BFS (breadth-first search) — поиск в ширину
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TreeNode BreadthFirstSearch(int value)
    {
        elementsQueue.Enqueue(this);

        while (elementsQueue.Count != 0)
        {
            TreeNode currentElement = elementsQueue.Dequeue();
            if (currentElement.Value == value)
                return currentElement;
        
            if (currentElement.Left != null) elementsQueue.Enqueue(currentElement.Left);
            if (currentElement.Right != null) elementsQueue.Enqueue(currentElement.Right);
        }

        return null;
    }
    
    /// <summary>
    /// DFS (deep-first search) — поиск в глубину
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public TreeNode DeepFirstSearch(int value)
    {
        elementsStack.Push(this);

        while (elementsStack.Count != 0)
        {
            TreeNode currentElement = elementsStack.Pop();
            if (currentElement.Value == value)
                return currentElement;
            
            elementsStack.Push(currentElement.Left);
            elementsQueue.Enqueue(currentElement.Right);
        }
        
        return null;
    }
}