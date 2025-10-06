using System;
using System.Collections;

class TicketCounter
{
    static void Main()
    {
        // Creating a Queue (Non-Generic)
        Queue ticketQueue = new Queue();

        // Enqueue: Customers take tickets and enter the queue
        ticketQueue.Enqueue("Customer 1");
        ticketQueue.Enqueue("Customer 2");
        ticketQueue.Enqueue("Customer 3");
        ticketQueue.Enqueue("Customer 4");

        Console.WriteLine("Customers in Queue: " + ticketQueue.Count);

        // Peek: Check who is next without removing
        Console.WriteLine("Next to be served: " + ticketQueue.Peek());

        // Dequeue: Serve customers in FIFO order
        Console.WriteLine(ticketQueue.Dequeue() + " is being served.");
        Console.WriteLine(ticketQueue.Dequeue() + " is being served.");

        // Check updated queue status
        Console.WriteLine("Customers remaining in Queue: " + ticketQueue.Count);
        Console.WriteLine("Next to be served: " + ticketQueue.Peek());
        Console.ReadLine();
    }
}
