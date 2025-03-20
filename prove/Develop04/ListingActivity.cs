
public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _activityName = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void ExecuteActivity()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You will have a few seconds to think about it...");
        DisplayCountdown(5);

        Console.WriteLine("Start listing items. Press Enter after each item:");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        int count = 0;
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    count++;
                }
            }
            else
            {
                Thread.Sleep(100);
            }
        }

        Console.WriteLine($"You listed {count} items!");
    }
}