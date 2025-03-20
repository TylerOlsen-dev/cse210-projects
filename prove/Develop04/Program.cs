

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Menu.Display();
            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            int choice;
            
            if (int.TryParse(input, out choice))
            {
                Activity activity = null;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }

                if (activity != null && !exit)
                {
                    activity.Run();
                    Console.WriteLine("Press Enter to return to the menu...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}