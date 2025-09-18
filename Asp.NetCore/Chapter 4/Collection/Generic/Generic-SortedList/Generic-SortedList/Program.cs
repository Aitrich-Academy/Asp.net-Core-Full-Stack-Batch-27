using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating a SortedList where student IDs are keys and grades are values
        SortedList<int, string> studentGrades = new SortedList<int, string>();

        // Adding student IDs with corresponding grades
        studentGrades.Add(105, "B");
        studentGrades.Add(102, "A");
        studentGrades.Add(108, "C");
        studentGrades.Add(101, "A+");
        studentGrades.Add(107, "B+");

        // Displaying students sorted by their IDs
        Console.WriteLine("Student Grades (Sorted by Student ID):");
        foreach (var student in studentGrades)
        {
            Console.WriteLine($"Student ID: {student.Key}, Grade: {student.Value}");
        }

        // Searching for a specific student's grade
        int searchId = 102;
        if (studentGrades.ContainsKey(searchId))
        {
            Console.WriteLine($"\nStudent {searchId} has grade: {studentGrades[searchId]}");
        }

        // Removing a student record
        studentGrades.Remove(108);
        Console.WriteLine("\nAfter removing Student ID 108:");

        foreach (var student in studentGrades)
        {
            Console.WriteLine($"Student ID: {student.Key}, Grade: {student.Value}");
        }
        Console.ReadLine();
    }
}

