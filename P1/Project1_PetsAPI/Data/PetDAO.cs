using Microsoft.AspNetCore.JsonPatch;
using Project1_PetsAPI.Models;

namespace Project1_PetsAPI.Data;

public class PetDAO : IPetDAO
{
    private readonly PetsDBContext context;
    public PetDAO(PetsDBContext context) => this.context = context;

    public Pet CreateNewPet(Pet newPet)
    {
        context.Pets.Add(newPet);
        context.SaveChanges();
        return newPet;
    }

    public IEnumerable<Pet> GetAllPets()
    {
        return context.Pets;
    }

    public Pet? GetPetById(int id)
    {
        return context.Pets.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Pet> GetPetsByName(string name)
    {
        return context.Pets.Where(p => p.Name.Equals(name));
    }

    public Pet UpdatePetById(int id, Pet newPet)
    {
        Pet oldPet = context.Pets.Find(id)!;
        newPet.Id = oldPet.Id;
        context.Entry(oldPet).CurrentValues.SetValues(newPet);
        context.SaveChanges();
        return context.Pets.Find(id)!;
    }    

    public Pet EditPetById(int id, JsonPatchDocument<Pet> newPet)
    {
        Pet oldPet = context.Pets.Find(id)!;

        newPet.ApplyTo(oldPet);        
        context.Update(oldPet);
        context.SaveChanges();
        return context.Pets.Find(id)!;
    }

    public Pet? DeletePetById(int id)
    {
        var petToDelete = GetPetById(id);

        if(petToDelete is not null)
        {
            context.Pets.Remove(petToDelete);
            context.SaveChanges();
        }

        return petToDelete;     
    }    
}