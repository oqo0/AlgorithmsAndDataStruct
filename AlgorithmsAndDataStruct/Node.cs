namespace Lesson6;

internal class Node
{
    internal int Value { get; set; }
    internal List<Node> Linked { get; set; }

    internal Node(int value)
    {
        this.Value = value;
        this.Linked = new List<Node>();
    }
    internal Node(int value, params Node[] linked)
    {
        this.Value = value;
        this.Linked = linked.ToList();
    }
}