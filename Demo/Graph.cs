using System.Collections.ObjectModel;

public class LimitedGraph
{
    public int Count { get; private set; }
    public Node Root { get; set; }
    HashSet<Node> _context = new();

    public LimitedGraph(int value)
    {
        var node = new Node(value, this);
        Root = node;
        _context.Add(node);
        Count = 1;
    }

    public Node AddNode(int value)
    {
        Count++;
        var node = new Node(value, this);
        _context.Add(node);
        return node;
    }

    public void RemoveNode(Node node)
    {
        node.Remove();
        _context.Remove(node);
        Count--;
    }

    public void ConnectNodes(int edgeValue, Node a, Node b)
    {
        if (a.ConnectedTo(b))
            throw new ArgumentException("Nodes are already connected.");
        else
        {
            new Edge(edgeValue, a, b, this);
        }
    }

    public void Print()
    {
        foreach (var node in _context)
        {
            Console.WriteLine(node);
        }
    }
}

public class Node
{
    public int Value { get; set; }
    public LimitedGraph Graph { get; internal init; }

    public ReadOnlyCollection<Edge> Edges => _edges.AsReadOnly();
    public ReadOnlyCollection<Node> ConnectedNodes
    {
        get
        {
            var nodes = new List<Node>();
            for (int i = 0; i < _edges.Count; i++)
            {
                Edge edge = _edges[i];
                nodes.Add(edge.GetOther(this));
            }

            return nodes.AsReadOnly();
        }
    }

    private List<Edge> _edges = new List<Edge>();

    internal Node(int value, LimitedGraph graph)
    {
        Graph = graph;
        Value = value;
    }

    public void ConnectTo(Node node, int edgeValue)
    {
        Graph.ConnectNodes(edgeValue, this, node);
    }

    internal void DisconnectFromEdge(Edge edge)
    {
        _edges.Remove(edge);
    }

    internal void Remove()
    {
        foreach (var edge in _edges)
        {
            edge.Disconnect();
        }
    }

    public bool ConnectedTo(Node node)
    {
        foreach (var edge in _edges)
        {
            if (edge.GetOther(node) == node)
            {
                return true;
            }
        }

        return false;
    }

    internal void Connect(Edge edge)
    {
        _edges.Add(edge);
    }

    public override string ToString()
    {
        return $"{Value} [{_edges.Count}]";
    }
}

public class Edge
{
    public int Value { get; set; }
    public LimitedGraph Graph { get; internal init; }

    public Node A { get; private set; }
    public Node B { get; private set; }

    internal Edge(int value, Node a, Node b, LimitedGraph graph)
    {
        Value = value;
        A = a ?? throw new ArgumentNullException(nameof(a));
        B = b ?? throw new ArgumentNullException(nameof(b));
        A.Connect(this);
        B.Connect(this);
        Graph = graph;
    }

    internal void Disconnect()
    {
        A.DisconnectFromEdge(this);
        B.DisconnectFromEdge(this);
        A = null;
        B = null;
    }

    internal Node GetOther(Node node)
    {
        if (A == node)
            return B;
        else if (B == node)
            return A;
        else
            throw new ArgumentException(nameof(node));
    }
}

public static class DijkstrasAlgorithmPreparation
{
    public static void Demo()
    {
        LimitedGraph graph = new(0);

        // a initial
        // e destination
        var a = graph.Root;
        var b = graph.AddNode(int.MaxValue);
        var c = graph.AddNode(int.MaxValue);
        var d = graph.AddNode(int.MaxValue);
        var e = graph.AddNode(int.MaxValue);
        var f = graph.AddNode(int.MaxValue);

        a.ConnectTo(b, 14);
        a.ConnectTo(c, 9);
        a.ConnectTo(d, 7);

        b.ConnectTo(e, 9);
        b.ConnectTo(c, 2);

        c.ConnectTo(d, 10);
        c.ConnectTo(f, 11);

        d.ConnectTo(f, 15);

        e.ConnectTo(f, 6);

        List<Node> unvisited = new() { a, b, c, d, e, f };
    }
}