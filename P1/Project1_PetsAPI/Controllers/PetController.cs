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
    

    /// <summary>
    /// Returns all the pets in the database.
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllPets()
    {        
        return Ok(petService.GetAllPets());
    }

    /// <summary>
    /// Returns a list of pets matching {name}.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [HttpGet("name/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetPetsByName(string name)
    {
        return Ok(petService.GetPetsByName(name));
    }

    /// <summary>
    /// Returns a pet matching the {id}.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetPetById(int id)
    {
        var foundPet = petService.GetPetById(id);

        if(foundPet is null) return NoContent();        
        return Ok(foundPet);
    }
    
    /// <summary>
    /// Creates a pet and stores it in the database.
    /// </summary>
    /// <param name="newPet"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateNewPet(Pet newPet)
    {
        var createdPet = petService.CreateNewPet(newPet);

        if(createdPet is null) return BadRequest();
        return Ok(createdPet);
    }
    
    /// <summary>
    /// Replaces all attibutes of a pet matching {id} with the specified {pet}. 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newPet"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdatePetById(int id, Pet newPet)
    {
        var updatedPet = petService.UpdatePetById(id, newPet);

        if(updatedPet is null) return BadRequest("No such pet.");
        return Ok(updatedPet);
    }

    /// <summary>
    /// Edits specific attributes of a pet matching {id} using a JSONPatchDocument.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newPet"></param>
    /// <returns></returns>
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult EditPetById(int id, JsonPatchDocument<Pet> newPet)
    {
        var updatedPet = petService.EditPetById(id, newPet);

        if(updatedPet is null) return BadRequest("No such pet.");
        return Ok(updatedPet);
    }
    
    /// <summary>
    /// Deletes a pet from the database matching {id}.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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