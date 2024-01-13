public class Tree
{
    public int Height { get; private set; }
    public Node Root { get; init; }

    public Tree(int rootKey)
    {
        Root = new Node(rootKey);
        Height = 0;
    }

    public Node ConnectChild(Node parent, int key)
    {
        var node = new Node(key);
        parent.ConnectChild(node);

        return node;
    }

    public void DeleteNode(Node node)
    {
        if (node == Root)
            throw new InvalidOperationException("Cannot delete the root node of a tree.");
        else
            node.Delete();
    }
}

public class Node
{
    public int Key { get; set; }
    public bool IsRoot => Parent == null;
    public bool IsLeaf => Children == null || Children.Count == 0;
    public int Level { get; }
    public Node Parent { get; private set; }

    // optimally this would be a readonly DTS
    public List<Node> Children { get; private set; } = new();
    public List<Node> Siblings => Parent?.Children;

    public Node(int key)
    {
        Key = key;
        if (!IsRoot)
            Level = Parent.Level + 1;
    }

    internal void ConnectChild(Node child)
    {
        Children.Add(child);
        child.Parent = this;
    }

    internal void Delete()
    {
        Parent.Children.Remove(this);
        Parent = null;

        // recursion
        // To incur garbage collection
        // limits the size of the tree
        for (int i = 0; i < Children.Count; i++)
            Children[i].Delete();

        Children.Clear();
        Children = null;
    }
}