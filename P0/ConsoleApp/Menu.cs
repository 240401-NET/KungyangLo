using static System.Console;

namespace P0;

//Menu.cs handles all menu display and manipulations
public class Menu
{
    public static void DisplayBanner()
    {
        WriteLine(
            " _____     _     _______             _                \n" +        
            "|  __ \\   | |   |__   __|           | |              \n" +
            "| |__) |__| |_     | |_ __ __ _  ___| | _____ _ __    \n" +
            "|  ___/ _ \\ __|    | | '__/ _` |/ __| |/ / _ \\ '__| \n" +
            "| |  |  __/ |_     | | | | (_| | (__|   <  __/ |      \n" +
            "|_|   \\___|\\__|    |_|_|  \\__,_|\\___|_|\\_\\___|_|  "                                  
        );
        
        WriteLine("Hello, welcome to Pet Tracker!");
    }

    public static void DisplayMenuOptions()
    {
        WriteLine("1. Enter new pet.");
        WriteLine("2. Delete existing pet.");
        WriteLine("3. List all pets.");
        WriteLine("0. Save and exit.");
    }

    public static void DisplayLineBreak(TextWriter textWriter, int numOfBreak)
    {
        for(int i = 0; i < numOfBreak; i++)
        {
            Utils.Output(textWriter, "\n");
        }
    }
}