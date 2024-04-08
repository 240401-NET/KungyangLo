using System.Diagnostics;
using System.Security.Cryptography;
using static System.Console;

namespace P0;

class Program
{
    static void Main(string[] args)
    {        
        List<Animal> petsList = Data.LoadAllPets();

        Menu.DisplayBanner();       
        Menu.DisplayLineBreak(3);

        while(true)
        {
            Menu.DisplayMenuOptions();
            Menu.DisplayLineBreak(1);

            int userSelection = Utils.UserChoice(ReadLine());
            Menu.DisplayLineBreak(1);

            //Clear();

            switch(userSelection)
            {
                case 1:
                petsList.Add(Controller.CreateNewPet());
                Menu.DisplayLineBreak(1);
                break;

                case 2:
                Controller.DeletePet(ref petsList);
                Menu.DisplayLineBreak(1);
                break;

                case 3:
                Controller.ListAllPets(petsList);
                Menu.DisplayLineBreak(1);
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
