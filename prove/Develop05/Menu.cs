namespace goal_assignment
{
    public class Menu
    {
        public void DisplayMainMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create a goal");
            Console.WriteLine("2. Display goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Delete save file");
            Console.WriteLine("7. Quit");
        }
        public void DisplayGoalMenu()
        {
            Console.WriteLine("Goal Types:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
        }
    }
}