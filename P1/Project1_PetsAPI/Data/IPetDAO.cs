using Microsoft.AspNetCore.JsonPatch;
using Project1_PetsAPI.Models;

namespace Project1_PetsAPI.Data;

public interface IPetDAO
{
    //Interface for Pet data access object
    Pet CreateNewPet(Pet newPet);
    IEnumerable<Pet> GetAllPets();
    Pet? GetPetById(int id);
    IEnumerable<Pet> GetPetsByName(string name);
    Pet UpdatePetById(int id, Pet newPet);
    Pet EditPetById(int id, JsonPatchDocument<Pet> Pet);
    Pet? DeletePetById(int id);
}