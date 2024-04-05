namespace P0;

//Menu.cs handles all menu display and manipulations
public class Menu
{
    public static void DisplayBanner()
    {
        DisplayLineBreak(1);
        Console.WriteLine
        (
            " _____     _     _______             _                \n" +        
            "|  __ \\   | |   |__   __|           | |              \n" +
            "| |__) |__| |_     | |_ __ __ _  ___| | _____ _ __    \n" +
            "|  ___/ _ \\ __|    | | '__/ _` |/ __| |/ / _ \\ '__| \n" +
            "| |  |  __/ |_     | | | | (_| | (__|   <  __/ |      \n" +
            "|_|   \\___|\\__|    |_|_|  \\__,_|\\___|_|\\_\\___|_|  "                                  
        );
        
        Console.WriteLine("Hello, welcome to Pet Tracker!");
    }

    public static void DisplayMenuOptions()
    {
        Console.WriteLine("1. Enter new pet.");
        Console.WriteLine("2. Edit existing pet.");
        Console.WriteLine("3. List all pets.");
        Console.WriteLine("0. Exit.");
    }

    public static void DisplayLineBreak(int numOfBreak)
    {
        for(int i = 0; i < numOfBreak; i++)
        {
            Console.Write("\n");
        }
    }

    public static Animal CreateNewPet()
    {
        Console.WriteLine("What is the name of your pet?");
        string? name = Console.ReadLine();
        
        while(String.IsNullOrEmpty(name))
        {
            Console.WriteLine("Pet name cannot be left blank, try again!");
            name = Console.ReadLine();
        }

        Console.WriteLine("What type of animal is your pet?");
        string animalType = Console.ReadLine() ?? String.Empty;

        return new Animal(name, animalType);     
    }
}