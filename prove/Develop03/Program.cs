using System;

class Program
{
    static void Main()
    {
        bool playAgain = true;
        while (playAgain)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the random scripture memorizing game!");
            Console.WriteLine("You will be given a random scripture and need to memorize it.");
            Console.WriteLine("When you press enter, words will start hiding until nothing is left.");
            Console.Write("\nDo you want to start the game? (yes or no): ");
            string start = Console.ReadLine();
            if (start.ToLower() == "yes")
            {
                Console.Clear();
                Word word = new Word();
                Console.Write("\nHow many words do you want to hide each time? ");
                int count = Convert.ToInt32(Console.ReadLine());
                while (!word.IsFullyHidden())
                {
                    Console.WriteLine(word.GetModifiedScripture());
                    Console.ReadLine();
                    word.RemoveWords(count);
                }
                Console.Clear();
                Console.WriteLine("All words have been hidden. The game is now over.");
            }
            Console.Write("\nDo you want to play again? (yes or no): ");
            string again = Console.ReadLine();
            if (again.ToLower() != "yes")
                playAgain = false;
        }
    }
}