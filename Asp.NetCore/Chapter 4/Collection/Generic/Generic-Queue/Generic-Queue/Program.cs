using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a queue for customer support tickets
        Queue<string> supportTickets = new Queue<string>();

        // New tickets arrive (Enqueue)
        supportTickets.Enqueue("Ticket#101");
        supportTickets.Enqueue("Ticket#102");
        supportTickets.Enqueue("Ticket#103");

        // Display the number of pending tickets
        Console.WriteLine("Total Tickets in Queue: " + supportTickets.Count);

        // Check the next ticket to be processed without removing it (Peek)
        Console.WriteLine("Next Ticket to Process: " + supportTickets.Peek());

        // Process tickets (Dequeue)
        while (supportTickets.Count > 0)
        {
            string ticket = supportTickets.Dequeue();
            Console.WriteLine($"Processing {ticket}...");
        }

        // Confirm all tickets are processed
        Console.WriteLine("All tickets processed. Remaining Tickets: " + supportTickets.Count);
        Console.ReadLine();
    }
}

