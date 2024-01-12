public static class LinkedListExample
{
    public static void Demo()
    {
        LinkedList<int> linked = new();
        linked.AddLast(0);
        linked.AddLast(1);
        linked.AddLast(2);
        linked.AddLast(3);

        Console.WriteLine(GetNode(linked, 2).Value);
        Console.WriteLine(GetNodeFromEnd(linked, 2).Value);

        linked.Clear();
        linked.AddFirst(1);
        linked.AddFirst(2);
        linked.AddFirst(3);
        linked.AddFirst(1);
        linked.AddFirst(2);
        linked.AddFirst(3);
        linked.AddFirst(4);
        linked.AddFirst(5);
        linked.AddFirst(6);
        linked.AddFirst(2);

        ClearDuplicates(linked);
        Console.WriteLine();

        foreach (var item in linked)
        {
            Console.Write($"{item}, ");
        }
    }

    public static LinkedListNode<int> GetNode(LinkedList<int> list, int index)
    {
        var counter = 0;
        if (list == null || index >= list.Count)
            return null;

        var node = list.First;
        for (int i = 0; i < index; i++)
            node = node.Next;

        return node;
    }

    public static LinkedListNode<int> GetNodeFromEnd(LinkedList<int> list, int index)
    {
        var counter = list.Count - 1;
        if (list == null || index >= list.Count)
            return null;

        var node = list.Last;
        for (int i = 0; i < index; i++)
            node = node.Previous;

        return node;
    }

    public static void ClearDuplicates(LinkedList<int> list)
    {
        if (list == null || list.Count == 0)
            return;

        HashSet<int> set = new HashSet<int>(list.Count / 2);
        var node = list.First;

        while (node != null)
        {
            if (!set.Add(node.Value))
            {
                var n = node;
                node = node.Next;
                list.Remove(n);
            }
            else
                node = node.Next;
        }
    }
}