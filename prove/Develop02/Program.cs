using System;

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        string choice;
        do
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                myJournal.WriteEntry();
            }
            else if (choice == "2")
            {
                myJournal.DisplayEntries();
            }
            else if (choice == "3")
            {
                myJournal.SaveToFile();
            }
            else if (choice == "4")
            {
                myJournal.LoadFromFile();
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        } while (choice != "5");
        Console.WriteLine("Exiting program...");
    }
}