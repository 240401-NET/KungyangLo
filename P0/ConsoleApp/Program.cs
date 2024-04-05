using System.Diagnostics;

namespace P0;

class Program
{
    static void Main(string[] args)
    {        
        Menu.DisplayBanner();       
        Menu.DisplayLineBreak(3);

        Animal myPet1 = new("Nyla");
        Animal myPet2 = new("Steve");
        Animal myPet3 = new("Dave");

        myPet1.AnimalType = "Cat";
        myPet1.BirthDay = new(2012, 10, 14);

        List<Animal> animalList = [myPet1, myPet2, myPet3];

        DateOnly bDay = DateOnly.MinValue;
        Console.WriteLine(bDay);
        Console.WriteLine(Utils.CalculateAge(bDay));
        Menu.DisplayLineBreak(3);

        while(true)
        {
            Menu.DisplayMenuOptions();
            Menu.DisplayLineBreak(3);

            int userSelection = Utils.UserChoice(Console.ReadLine());

            //Console.Clear();

            switch(userSelection)
            {
                case 1:
                Console.WriteLine(Menu.CreateNewPet());
                break;

                case 2:
                Console.WriteLine("Choice 2");
                break;

                case 3:
                foreach(Animal pet in animalList)
                {
                    Console.WriteLine(pet);
                }
                break;

                case 0:
                Console.WriteLine("Choice 0");
                Environment.Exit(0);
                break;

                default:
                break;
            }


        }
        
        

    }
}
