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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllPets()
    {        
        return Ok(petService.GetAllPets());
    }

    [HttpGet("name/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetPetsByName(string name)
    {
        return Ok(petService.GetPetsByName(name));
    }

    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetPetById(int id)
    {
        var foundPet = petService.GetPetById(id);

        if(foundPet is null) return NoContent();        
        return Ok(foundPet);
    }
    
    //Post
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateNewPet(Pet newPet)
    {
        var createdPet = petService.CreateNewPet(newPet);

        if(createdPet is null) return BadRequest();
        return Ok(createdPet);
    }
    
    //Put
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdatePetById(int id, Pet newPet)
    {
        var updatedPet = petService.UpdatePetById(id, newPet);

        if(updatedPet is null) return BadRequest("No such pet.");
        return Ok(updatedPet);
    }

    //Patch
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult EditPetById(int id, JsonPatchDocument<Pet> newPet)
    {
        var updatedPet = petService.EditPetById(id, newPet);

        if(updatedPet is null) return BadRequest("No such pet.");
        return Ok(updatedPet);
    }
    
    //Delete
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeletePetById(int id)
    {
        var deletePet = petService.DeletePetById(id);

        if(deletePet is null) return BadRequest("No such pet.");
        return Ok(deletePet);
    }
}