using static System.Console;

namespace P0;

public class Controller
{
    public static Animal CreateNewPet()
    {
        WriteLine("What is the name of your pet?");
        string? petName = ReadLine();
        
        while(String.IsNullOrEmpty(petName) || String.IsNullOrWhiteSpace(petName))
        {
            WriteLine("Pet name cannot be left blank, try again!");
            petName = ReadLine();
        }

        Animal newPet = new(petName);

        WriteLine($"What type of animal is {petName}? Or leave blank.");
        string? animalType = ReadLine();
        newPet.AnimalType = animalType!;

        WriteLine($"Does {petName} have a birthday? MM/DD/YYYY Or leave blank.");
        string? petBirthDay = ReadLine();
        //newPet.BirthDay = ;

        return newPet;     
    }

    public static void DeletePet(ref List<Animal> petList)
    {        
        WriteLine("What is the name of the pet you want to delete?");
        string? petName = ReadLine();

        if(Utils.FindPet(petName!, petList))
        {
            petList.RemoveAll(pet => pet.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
            WriteLine($"{petName} has been removed.");
        }
        else
        {
            string respond = String.IsNullOrEmpty(petName?.Trim()) ? "No pet name was given." : $"{petName} does not exist";
            WriteLine(respond);
        }
    }

    public static void ListAllPets(List<Animal> petList)
    {
        foreach(Animal pet in petList)
        {
            WriteLine(pet);
            WriteLine("------------------------");
        }
    }

    public static List<Animal> EditPet(List<Animal> petList, Animal petToEdit)
    {
        return petList;
    } 
}