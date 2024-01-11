public static class QueueDemo
{
    public static void Demo()
    {
        const int customers = 10;
        const int cap = 10;

        var q1 = new Queue<Customer>(customers);
        var q2 = new Queue<Customer>(customers);

        // Enqueue random customers
        for (int i = 0; i < customers; i++)
        {
            q1.Enqueue(new Customer() { Id = i, Priority = Random.Shared.Next(0, cap) });
        }

        Console.WriteLine("The original Queue:");
        PrintQueue(q1);

        CustomerServiceRep();

        Console.WriteLine("The order of service:");
        PrintQueue(q2);

        void CustomerServiceRep()
        {
            while (q1.Count != 0)
            {
                var customer = q1.Dequeue();

                if (customer.Priority < cap)
                {
                    customer.Priority++;
                    q1.Enqueue(customer);
                }
                else
                {
                    q2.Enqueue(customer);
                }
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
        public int Priority;

        public override string ToString()
        {
            return $"{Id} : {Priority}";
        }
    }
}