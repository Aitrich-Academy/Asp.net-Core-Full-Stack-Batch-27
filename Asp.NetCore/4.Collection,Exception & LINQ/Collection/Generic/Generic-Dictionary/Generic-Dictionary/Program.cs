using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating a dictionary to store student ID and Name
        Dictionary<int, string> students = new Dictionary<int, string>();

        // Adding students
        students.Add(101, "Alice");
        students.Add(102, "Bob");
        students.Add(103, "Charlie");

        // Retrieving a student by ID
        int searchId = 102;
        if (students.ContainsKey(searchId))
        {
            Console.WriteLine($"Student ID {searchId}: {students[searchId]}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        // Removing a student
        int removeId = 101;
        if (students.ContainsKey(removeId))
        {
            students.Remove(removeId);
            Console.WriteLine($"Student ID {removeId} removed.");
        }

        // Displaying all students
        Console.WriteLine("\nList of all students:");
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Key}, Name: {student.Value}");
        }

        // Clearing all students from the dictionary
        students.Clear();
        Console.WriteLine("\nAll student records have been cleared.");

        // Checking if the dictionary is empty
        if (students.Count == 0)
        {
            Console.WriteLine("No students left in the system.");
        }
        Console.ReadLine();
    }
}

