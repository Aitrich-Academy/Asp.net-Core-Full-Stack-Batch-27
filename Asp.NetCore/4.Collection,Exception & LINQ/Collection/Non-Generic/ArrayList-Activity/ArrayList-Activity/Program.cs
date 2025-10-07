using System;
using System.Collections;

class Library
{
    static void Main()
    {
        // Creating an ArrayList to store book titles
        ArrayList books = new ArrayList();

        // 1. Add books to the library
        books.Add("The Great Gatsby");
        books.Add("To Kill a Mockingbird");
        books.Add("1984");
        books.Add("Moby Dick");
        books.Add("Pride and Prejudice");

        Console.WriteLine("Books in the library:");
        DisplayBooks(books);

        // 2. Remove a book by name
        books.Remove("1984");
        Console.WriteLine("\nAfter removing '1984':");
        DisplayBooks(books);

        // 3. Remove a book at a specific index
        books.RemoveAt(2);  // Removing "Moby Dick" (index 2 after previous removal)
        Console.WriteLine("\nAfter removing book at index 2:");
        DisplayBooks(books);

        // 4. Insert a book at a specific position
        books.Insert(1, "Harry Potter");
        Console.WriteLine("\nAfter inserting 'Harry Potter' at index 1:");
        DisplayBooks(books);

        // 5. Find the index of a book
        int index = books.IndexOf("Pride and Prejudice");
        Console.WriteLine($"\nIndex of 'Pride and Prejudice': {index}");

        // 6. Check if a book exists
        bool contains = books.Contains("The Great Gatsby");
        Console.WriteLine($"\nDoes the library contain 'The Great Gatsby'? {contains}");

        // 7. Count the total books
        Console.WriteLine($"\nTotal books in the library: {books.Count}");

        // 8. Sort books alphabetically
        books.Sort();
        Console.WriteLine("\nBooks after sorting alphabetically:");
        DisplayBooks(books);
    }

    static void DisplayBooks(ArrayList books)
    {
        foreach (string book in books)
        {
            Console.WriteLine(book);
            Console.WriteLine();
        }
        Console.ReadLine();
    }
    
}

