using System.Runtime.InteropServices;
using System.Diagnostics;

public abstract class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public void Run()
    {
        DisplayStartingMessage();
        SetDuration();
        Console.WriteLine("Get ready...");
        DisplayCountdown(5);
        ExecuteActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    protected void SetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        string input = Console.ReadLine();
        int duration;
        if (int.TryParse(input, out duration))
        {
            _duration = duration;
        }
        else
        {
            _duration = 30;
        }
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Good job!");
        DisplaySpinner(3);
        Console.WriteLine($"You have completed the {_activityName} for {_duration} seconds.");
        DisplaySpinner(3);
    }

    protected void DisplaySpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
        PlayBeep();
    }

    protected void PlayBeep()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Console.Beep(800, 300);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            try
            {
                Process.Start("afplay", "/System/Library/Sounds/Glass.aiff");
            }
            catch
            {
                Console.Write("\a");
            }
        }
        else
        {
            Console.Write("\a");
        }
    }

    protected abstract void ExecuteActivity();
}