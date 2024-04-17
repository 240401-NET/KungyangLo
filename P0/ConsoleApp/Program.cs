using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
//using static System.Console;

namespace P0;

class Program
{
    static void Main(string[] args)
    {        
        List<Animal> petsList = Data.LoadAllPets();

        Menu.DisplayBanner();       
        Menu.DisplayLineBreak(Console.Out, 2);

        while(true)
        {
            Menu.DisplayMenuOptions();
            Menu.DisplayLineBreak(Console.Out, 1);

            int userSelection = Utils.UserChoice(Console.ReadLine());
            Menu.DisplayLineBreak(Console.Out, 1);

            //Clear();

            switch(userSelection)
            {
                case 1:
                petsList.Add(Controller.CreateNewPet());
                Menu.DisplayLineBreak(Console.Out, 1);
                break;

                case 2:
                Controller.DeletePet(ref petsList);
                Menu.DisplayLineBreak(Console.Out, 1);
                break;

                case 3:
                Controller.ListAllPets(petsList);
                Menu.DisplayLineBreak(Console.Out, 1);
                break;

                case 0:
                Data.SaveAllPets(petsList);
                Environment.Exit(0);
                break;

                default:
                break;
            }


        }
    }
}
