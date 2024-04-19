using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.JsonPatch;
using Project1_PetsAPI.Data;
using Project1_PetsAPI.Models;

namespace Project1_PetsAPI.Services;

public class PetService : IPetService
{
    private readonly IPetDAO petDAO;
    public PetService(IPetDAO petDAO) => this.petDAO = petDAO;

    public Pet CreateNewPet(Pet newPet)
    {
        return petDAO.CreateNewPet(newPet);
    }

    public IEnumerable<Pet> GetAllPets()
    {
        return petDAO.GetAllPets();
    }

    public Pet? GetPetById(int id)
    {
        return petDAO.GetPetById(id);
    }

    public IEnumerable<Pet> GetPetsByName(string name)
    {
        return petDAO.GetPetsByName(name.Trim());
    } 

    public Pet UpdatePetById(int id, Pet newPet)
    {
        var oldPet = GetPetById(id);

        if(oldPet is not null)
        {
            return petDAO.UpdatePetById(id, newPet);
        }

        return null!;
    }  

    public Pet EditPetById(int id, JsonPatchDocument<Pet> newPet)
    {
        var oldPet = GetPetById(id);

        if(oldPet is not null) 
        {
            return petDAO.EditPetById(id, newPet);
        }
        
        return null!;
    }

    public Pet? DeletePetById(int id)
    {
        return petDAO.DeletePetById(id);
    }    
}