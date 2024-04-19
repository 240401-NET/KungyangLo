using Azure;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Project1_PetsAPI.Models;
using Project1_PetsAPI.Services;

namespace Project1_PetsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IPetService petService;
    public PetsController(IPetService petService) => this.petService = petService;
    
    //Get
    [HttpGet]
    public IActionResult GetAllPets()
    {        
        return Ok(petService.GetAllPets());
    }

    [HttpGet("name/{name}")]
    public IActionResult GetPetsByName(string name)
    {
        return Ok(petService.GetPetsByName(name));
    }

    [HttpGet("id/{id}")]
    public IActionResult GetPetById(int id)
    {
        var foundPet = petService.GetPetById(id);

        if(foundPet is null) return NoContent();        
        return Ok(foundPet);
    }
    
    //Post
    [HttpPost]
    public IActionResult CreateNewPet(Pet newPet)
    {
        var createdPet = petService.CreateNewPet(newPet);

        if(createdPet is null) return BadRequest();
        return Ok(createdPet);
    }
    
    //Put
    [HttpPut]
    public IActionResult UpdatePetById(int id, Pet newPet)
    {
        var updatedPet = petService.UpdatePetById(id, newPet);

        if(updatedPet is null) return BadRequest("No such pet.");
        return Ok(updatedPet);
    }

    //Patch
    [HttpPatch]
    public IActionResult EditPetById(int id, JsonPatchDocument<Pet> newPet)
    {
        var updatedPet = petService.EditPetById(id, newPet);

        if(updatedPet is null) return BadRequest("No such pet.");
        return Ok(updatedPet);
    }
    
    //Delete
    [HttpDelete]
    public IActionResult DeletePetById(int id)
    {
        var deletePet = petService.DeletePetById(id);

        if(deletePet is null) return BadRequest("No such pet.");
        return Ok(deletePet);
    }
}