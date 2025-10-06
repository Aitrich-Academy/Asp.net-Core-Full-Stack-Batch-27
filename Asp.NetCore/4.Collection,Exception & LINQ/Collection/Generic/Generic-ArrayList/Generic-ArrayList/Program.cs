using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void DisplayBook()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}");
    }
}

class Library
{
    private List<Book> books = new List<Book>();

    // Add a new book
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    // Remove a book by title
    public void RemoveBook(string title)
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                books.RemoveAt(i);
                Console.WriteLine($"Book '{title}' removed from the library.");
                return;
            }
        }
        Console.WriteLine($"Book '{title}' not found in the library.");
    }

    // Display all books
    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available in the library.");
            return;
        }

        Console.WriteLine("\nLibrary Books:");
        foreach (var book in books)
        {
            book.DisplayBook();
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        // Adding books to the list
        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald"));
        library.AddBook(new Book("1984", "George Orwell"));
        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));

        // Display all books
        library.DisplayBooks();

        // Removing a book
        library.RemoveBook("1984");

        // Display after removal
        library.DisplayBooks();
    }
}

