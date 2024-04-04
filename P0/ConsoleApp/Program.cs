namespace P0;

class Program
{
    static void Main(string[] args)
    {        
        Menu.DisplayBanner();
        
        Console.WriteLine("Hello, welcome to Pet Tracker!");
        Menu.DisplayLineBreak(3);
        Console.WriteLine("1. Enter new pet.");
        Console.WriteLine("2. Edit existing pet.");
        Console.WriteLine("3. List all pets.");
        Console.WriteLine("0. Exit.");
        Menu.DisplayLineBreak(3);

        Console.ReadLine();
        

    }
}
