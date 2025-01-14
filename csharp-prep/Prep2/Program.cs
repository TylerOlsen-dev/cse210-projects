using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80 && grade < 90)
        {
            letter = "B";
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C";
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is a {letter}");

        if (grade >= 70)
        {
            Console.Write("You passed the class! Keep up the good work!");
        }
        else
        {
            Console.Write("You failed the class. Do better next time!");
        }
    }
}