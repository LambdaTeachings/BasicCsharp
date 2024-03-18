QueueDemo.Demo();

public static class QueueDemo
{
    public static void Demo()
    {
        const int customers = 10;

        var steve = new Queue<Customer>(customers);
        var jhon = new Queue<Customer>(customers);

        // Enqueue random customers
        for (int i = 0; i < customers; i++)
        {
            steve.Enqueue(new Customer() { Id = i });
        }

        Console.WriteLine("John is on a break...");
        Console.WriteLine("Steve's Queue:");
        PrintQueue(steve);

        // steve goes on a break
        CustomerServiceRep(steve, jhon);

        Console.WriteLine("Steve is taking a break, moving customers to John...");
        Console.WriteLine("John's Queue");
        PrintQueue(jhon);

        void CustomerServiceRep(Queue<Customer> q1, Queue<Customer> q2)
        {
            while (q1.Count != 0)
            {
                q2.Enqueue(q1.Dequeue());
            }
        }

        void PrintQueue(Queue<Customer> q)
        {
            foreach (var obj in q)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine();
        }
    }

    class Customer
    {
        public int Id;
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
