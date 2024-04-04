namespace P0;

//Menu.cs handles all menu display and manipulations
public class Menu
{
    public static void DisplayBanner()
    {
        DisplayLineBreak(1);
        Console.WriteLine(
            " _____     _     _______             _                \n" +        
            "|  __ \\   | |   |__   __|           | |              \n" +
            "| |__) |__| |_     | |_ __ __ _  ___| | _____ _ __    \n" +
            "|  ___/ _ \\ __|    | | '__/ _` |/ __| |/ / _ \\ '__| \n" +
            "| |  |  __/ |_     | | | | (_| | (__|   <  __/ |      \n" +
            "|_|   \\___|\\__|    |_|_|  \\__,_|\\___|_|\\_\\___|_|  "                                  
        );
    }
    public static void DisplayLineBreak(int numOfBreak)
    {
        for(int i = 0; i < numOfBreak; i++)
        {
            Console.Write("\n");
        }
    }
}