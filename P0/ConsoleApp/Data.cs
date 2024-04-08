using System.Text.Json;
using static System.Console;

namespace P0;

public class Data
{
    static string saveFilePath = "petList.json";
    
    public static void SaveAllPets(List<Animal> allPets)
    {
        string jsonPets = JsonSerializer.Serialize(allPets);
        File.WriteAllText(saveFilePath, jsonPets);
    }

    public static List<Animal> LoadAllPets()
    {
        List<Animal> petList = [];
        
        try
        {
            string jsonPets = File.ReadAllText(saveFilePath);            
            petList = JsonSerializer.Deserialize<List<Animal>>(jsonPets) ?? [];
        }catch(Exception)
        {
            WriteLine("Pets save file does not exist or is corrupted.");
            WriteLine("Generating new pets save file.");
            SaveAllPets(petList);
        }
        
        return petList;
    }
}