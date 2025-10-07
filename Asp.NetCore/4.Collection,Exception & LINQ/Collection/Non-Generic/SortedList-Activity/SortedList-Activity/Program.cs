using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // Creating a SortedList (Product ID -> Product Name)
        SortedList inventory = new SortedList();

        // Adding items to the inventory
        inventory.Add(101, "Milk");
        inventory.Add(105, "Bread");
        inventory.Add(102, "Eggs");
        inventory.Add(103, "Butter");
        inventory.Add(104, "Cheese");

        // Display the sorted inventory
        Console.WriteLine("Initial Inventory:");
        DisplayInventory(inventory);

        // Remove an item (e.g., Butter)
        inventory.Remove(103);
        Console.WriteLine("\nAfter removing Butter (Product ID 103):");
        DisplayInventory(inventory);

        // Check if a specific key (Product ID) exists
        int searchKey = 105;
        Console.WriteLine($"\nContains Key {searchKey}? {inventory.ContainsKey(searchKey)}");

        // Find the index of a specific key
        int keyToFind = 102;
        int indexKey = inventory.IndexOfKey(keyToFind);
        Console.WriteLine($"\nIndex of Product ID {keyToFind}: {indexKey}");
        Console.ReadLine();

        // Find the index of a specific value
        string valueToFind = "Cheese";
        int indexValue = inventory.IndexOfValue(valueToFind);
        Console.WriteLine($"\nIndex of Product '{valueToFind}': {indexValue}");
        Console.ReadLine();

        // Count total items in inventory
        Console.WriteLine($"\nTotal Products in Inventory: {inventory.Count}");
        Console.ReadLine();
    }

    static void DisplayInventory(SortedList inventory)
    {
        foreach (DictionaryEntry item in inventory)
        {
            Console.WriteLine($"Product ID: {item.Key}, Product Name: {item.Value}");
        }
        Console.ReadLine();
    }
}
