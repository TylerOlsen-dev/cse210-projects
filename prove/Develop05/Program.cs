namespace goal_assignment
{
    public class Program
    {
        static int _points = 0;
        static List<Goal> _goals = new List<Goal>();

        static void Main(string[] args)
        {
            Menu _menu = new Menu();
            Console.WriteLine("Welcome to Goal Program\n");
            bool done = false;
            while (!done)
            {
                Console.WriteLine($"\nYou have {_points} points.\n");
                _menu.DisplayMainMenu();
                int choice = GetInt("Select a choice from the menu: ");
                switch (choice)
                {
                    case 1:
                        _menu.DisplayGoalMenu();
                        int choice2 = GetInt("Select a choice from the menu: ");
                        string name = GetString("Enter a name: ");
                        string desc = GetString("Enter a Description: ");
                        int points = GetInt("Enter points: ");
                        switch (choice2)
                        {
                            case 1:
                                _goals.Add(new SimpleGoal(name, desc, points));
                                break;
                            case 2:
                                _goals.Add(new EternalGoal(name, desc, points));
                                break;
                            case 3:
                                int times = GetInt("How many times do you want to do this? ");
                                int bonus = GetInt("Enter bonus points: ");
                                CheckListGoal tempGoal = new CheckListGoal(name, desc, points);
                                tempGoal.SetTimes(times);
                                tempGoal.SetBonus(bonus);
                                _goals.Add(tempGoal);
                                break;
                        }
                        break;
                    case 2:
                        Display(_goals);
                        break;
                    case 3:
                        Save();
                        break;
                    case 4:
                        Load();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        DeleteSaveFile();
                        break;
                    case 7:
                        done = true;
                        break;
                    default:
                        done = true;
                        break;
                }
            }
        }

        static void DeleteSaveFile()
        {
            string fileName = "myFile.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.WriteLine("Save file deleted successfully.");
            }
            else
            {
                Console.WriteLine("Save file not found.");
            }
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine("0");
            }
            Console.WriteLine("A new save file has been created.");
        }

        static void Save()
        {
            string fileName = "myFile.txt";
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_points);
                foreach (var goal in _goals)
                {
                    if (goal is SimpleGoal sg)
                        outputFile.WriteLine(sg.GetStringRepresentation());
                    else if (goal is EternalGoal eg)
                        outputFile.WriteLine(eg.GetStringRepresentation());
                    else if (goal is CheckListGoal clg)
                        outputFile.WriteLine(clg.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        static void Load()
        {
            string fileName = "myFile.txt";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Save file not found.");
                return;
            }
            string[] lines = File.ReadAllLines(fileName);
            _points = int.Parse(lines[0]);
            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = CreateGoalFromString(lines[i]);
                _goals.Add(goal);
            }
            Console.WriteLine("Goals loaded successfully.");
        }

        static void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                return;
            }
            Console.WriteLine("Select a goal to record an event:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].Display();
            }
            int selection = GetInt("Enter the number of the goal: ");
            Goal selectedGoal = _goals[selection - 1];
            int earned = 0;
            if (selectedGoal is SimpleGoal sg)
                earned = sg.RecordEvent();
            else if (selectedGoal is EternalGoal eg)
                earned = eg.RecordEvent();
            else if (selectedGoal is CheckListGoal clg)
                earned = clg.RecordEvent();
            _points += earned;
            Console.WriteLine($"Event recorded! You earned {earned} points.");
        }

        static void Display(List<Goal> goals)
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                goals[i].Display();
            }
        }

        static int GetInt(string prompt)
        {
            Console.Write(prompt);
            int result;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out result))
            {
                Console.Write("Invalid input. " + prompt);
                input = Console.ReadLine();
            }
            return result;
        }

        static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static Goal CreateGoalFromString(string representation)
        {
            string[] parts = representation.Split(':', 2);
            string type = parts[0];
            string[] fields = parts[1].Split('|');
            if (type == "SimpleGoal")
            {
                SimpleGoal sg = new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]));
                if (bool.Parse(fields[3]))
                    sg.MarkComplete();
                return sg;
            }
            else if (type == "EternalGoal")
                return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]));
            else if (type == "CheckListGoal")
            {
                CheckListGoal clg = new CheckListGoal(fields[0], fields[1], int.Parse(fields[2]));
                clg.SetTimes(int.Parse(fields[3]));
                clg.SetDone(int.Parse(fields[4]));
                clg.SetBonus(int.Parse(fields[5]));
                return clg;
            }
            else
                return null;
        }
    }
}