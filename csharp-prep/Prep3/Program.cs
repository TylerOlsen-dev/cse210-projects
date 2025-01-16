using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int myNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != myNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (myNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (myNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed the number!!");
            }

        }                    
    }
}