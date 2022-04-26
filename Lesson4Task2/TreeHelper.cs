namespace Lesson4;

public static class TreeHelper
{
    public static NodeInfo[] GetTreeInLine(ITree tree)
    {
        var bufer = new Queue<NodeInfo>();
        var returnArray = new List<NodeInfo>();
        var root = new NodeInfo() { Node = tree.GetRoot() };
        bufer.Enqueue(root);
        
        while (bufer.Count != 0)
        {
            var element = bufer.Dequeue();
            returnArray.Add(element);
            var depth = element.Depth + 1;
            if (element.Node.Left != null)
            {
                var left = new NodeInfo()
                {
                    Node = element.Node.Left,
                    Depth = depth,
                };
                bufer.Enqueue(left);
            }
            if (element.Node.Right != null)
            {
                var right = new NodeInfo()
                {
                    Node = element.Node.Right,
                    Depth = depth,
                };
                bufer.Enqueue(right);
            }
        }
        
        return returnArray.ToArray();
    }
}