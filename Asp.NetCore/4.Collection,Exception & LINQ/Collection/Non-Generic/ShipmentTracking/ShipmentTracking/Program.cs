using System;
using System.Collections;

class ShipmentTrackingSystem
{
    static void Main()
    {
        // 1. ArrayList: Storing tracking numbers
        ArrayList trackingNumbers = new ArrayList();

        // 2. Hashtable: Mapping tracking numbers to shipment details
        Hashtable shipmentDetails = new Hashtable();

        // 3. SortedList: Shipments ordered by estimated delivery date
        SortedList sortedShipments = new SortedList();

        // 4. Queue: FIFO processing of shipments
        Queue shipmentQueue = new Queue();

        // 5. Stack: LIFO undo functionality
        Stack undoStack = new Stack();

        // Adding shipments dynamically
        string tracking1 = "SHIP001";
        string tracking2 = "SHIP002";
        string tracking3 = "SHIP003";

        trackingNumbers.Add(tracking1);
        trackingNumbers.Add(tracking2);
        trackingNumbers.Add(tracking3);

        shipmentDetails[tracking1] = "Sender: Alice, Receiver: Bob, Status: In Transit";
        shipmentDetails[tracking2] = "Sender: Charlie, Receiver: David, Status: Delivered";
        shipmentDetails[tracking3] = "Sender: Eve, Receiver: Frank, Status: Pending";

        sortedShipments.Add(DateTime.Parse("2025-02-10"), tracking1);
        sortedShipments.Add(DateTime.Parse("2025-02-08"), tracking2);
        sortedShipments.Add(DateTime.Parse("2025-02-12"), tracking3);

        shipmentQueue.Enqueue(tracking1);
        shipmentQueue.Enqueue(tracking2);
        shipmentQueue.Enqueue(tracking3);

        undoStack.Push("Modified shipment details for " + tracking2);
        undoStack.Push("Cancelled shipment " + tracking3);

        // Displaying tracking numbers
        Console.WriteLine("Tracking Numbers in System:");
        foreach (string track in trackingNumbers)
        {
            Console.WriteLine(track);
        }

        // Fetching shipment details
        Console.WriteLine("\nShipment Details for SHIP002:");
        Console.WriteLine(shipmentDetails[tracking2]);

        // Displaying sorted shipments
        Console.WriteLine("\nShipments sorted by estimated delivery date:");
        foreach (DictionaryEntry entry in sortedShipments)
        {
            Console.WriteLine($"Delivery Date: {entry.Key}, Tracking Number: {entry.Value}");
        }

        // Processing shipments in FIFO order
        Console.WriteLine("\nProcessing Shipments (FIFO Order):");
        while (shipmentQueue.Count > 0)
        {
            Console.WriteLine("Processing Shipment: " + shipmentQueue.Dequeue());
        }

        // Undo last action (LIFO order)
        Console.WriteLine("\nUndo Last Actions (LIFO Order):");
        while (undoStack.Count > 0)
        {
            Console.WriteLine("Undo: " + undoStack.Pop());
        }
    }
}
