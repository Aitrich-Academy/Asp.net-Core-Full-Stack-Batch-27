using System;
using System.Collections.Generic;

class BrowserHistory
{
    private Stack<string> history = new Stack<string>();

    public void VisitPage(string url)
    {
        Console.WriteLine($"Visiting: {url}");
        history.Push(url); // Adding the page to the stack
    }

    public void GoBack()
    {
        if (history.Count > 1)
        {
            history.Pop(); // Remove current page
            Console.WriteLine($"Going back to: {history.Peek()}"); // Show the previous page
        }
        else
        {
            Console.WriteLine("No previous pages to go back to.");
        }
    }

    public void ShowHistoryCount()
    {
        Console.WriteLine($"Total pages in history: {history.Count}");
    }
}

class Program
{
    static void Main()
    {
        BrowserHistory browser = new BrowserHistory();
        browser.VisitPage("https://google.com");
        browser.VisitPage("https://github.com");
        browser.VisitPage("https://stackoverflow.com");

        browser.ShowHistoryCount(); // Output: 3
        browser.GoBack(); // Output: Going back to: https://github.com
        browser.GoBack(); // Output: Going back to: https://google.com
        browser.GoBack(); // Output: No previous pages to go back to.
        Console.ReadLine();
    }
}
