using Microsoft.AspNetCore.Mvc;

namespace Project1_PetsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FactsController : ControllerBase
{
    private readonly HttpClient _client;

    public FactsController(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Returns a random cat fact!
    /// *Terms and conditions apply. Offer valid for a limited time only.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAnimalFact()
    {
        string endPoint = $"https://meowfacts.herokuapp.com/";

        string fact = "";
        
        HttpResponseMessage response = await _client.GetAsync(endPoint);

        if (response.IsSuccessStatusCode)
        {
            fact = await response.Content.ReadAsStringAsync();
        }

        return Ok(fact);
    }
}