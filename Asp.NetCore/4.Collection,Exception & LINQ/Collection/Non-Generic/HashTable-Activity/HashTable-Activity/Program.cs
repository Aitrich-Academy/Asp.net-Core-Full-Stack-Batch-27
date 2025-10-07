using System;
using System.Collections;

class Program
{
    static void Main()
    {
        // Creating a Hashtable for library books
        Hashtable libraryBooks = new Hashtable();

        // Adding books to the hashtable (ISBN -> Book Title)
        libraryBooks.Add("978-3-16-148410-0", "The Great Gatsby");
        libraryBooks.Add("978-1-40-289462-6", "To Kill a Mockingbird");
        libraryBooks.Add("978-0-7432-7356-5", "The Da Vinci Code");

        // Display all books
        Console.WriteLine("Library Books:");
        foreach (DictionaryEntry book in libraryBooks)
        {
            Console.WriteLine($"ISBN: {book.Key}, Title: {book.Value}");
        }

        // Checking if a book exists using ContainsKey
        string searchISBN = "978-1-40-289462-6";
        if (libraryBooks.ContainsKey(searchISBN))
        {
            Console.WriteLine($"\nBook with ISBN {searchISBN} is available: {libraryBooks[searchISBN]}");
        }

        // Checking if a book exists using ContainsValue
        string searchTitle = "The Great Gatsby";
        if (libraryBooks.ContainsValue(searchTitle))
        {
            Console.WriteLine($"\nThe book '{searchTitle}' is available in the library.");
        }

        // Removing a book
        string removeISBN = "978-0-7432-7356-5";
        if (libraryBooks.ContainsKey(removeISBN))
        {
            libraryBooks.Remove(removeISBN);
            Console.WriteLine($"\nBook with ISBN {removeISBN} has been removed.");
        }

        // Displaying total count of books
        Console.WriteLine($"\nTotal books in library: {libraryBooks.Count}");
        Console.ReadLine();
    }
}
