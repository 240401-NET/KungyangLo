using System.Diagnostics;

namespace P0;

//Utils.cs contains all utilities that may be needed for this application
public class Utils
{
    public static void waitSec(int sec)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        long numOfSec = 0;

        while(numOfSec < sec)
        {
            numOfSec = stopwatch.ElapsedTicks / Stopwatch.Frequency;
        }
    }
}

/*
        //Possible functions I was playing with
        
        Random rnd = new();

        int price = rnd.Next(10);
        Console.WriteLine($"Random number is: {price}");

        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(rnd.Next(10));
        }

        Console.WriteLine(Console.BackgroundColor);
        Console.WriteLine(Console.ForegroundColor);

        waitSec(1);

        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.Clear();

        waitSec(1);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();

        waitSec(1);

        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();

        waitSec(1);

        Console.BackgroundColor = ConsoleColor.Red;
        Console.Clear();

        while(true)
        {
            ConsoleKeyInfo keyPress = Console.ReadKey(true);

            if(keyPress.Key is ConsoleKey.Escape)
            {
                Console.Clear();
            }

            Console.WriteLine(keyPress.Key);
        }
    */