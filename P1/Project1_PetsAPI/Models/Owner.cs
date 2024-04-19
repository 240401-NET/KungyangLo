using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_PetsAPI.Models;

public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set;}

    [Column(TypeName = "date")]
    public DateTime? BirthDay { get; set; }

    public IEnumerable<Pet>? PetIds { get; set;} = [];
}
