using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_PetsAPI.Models;

public class Pet
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    [RegularExpression(@"^[a-zA-Z''-'\s]{2,50}$", 
        ErrorMessage = "Pet names cannot start with a number, must be longer than 1 and up to 50 characters.")]
    public string Name { get; set; } = null!;
    
    [MaxLength(50)]
    public string? AnimalType { get; set; }    
    
    [Column(TypeName = "date")]    
    public DateTime? Birthday { get; set; }
    
    [MaxLength(280)]
    public string? Description { get; set; }

    public IEnumerable<Owner>? OwnerIds { get; set;} = [];

    public override string ToString()
    {
        return $"\nId: {Id}\nName: {Name}\nAnimal: {AnimalType}\nBirthday: {Birthday?.ToString("MM/dd/yyyy")}\nDescription: {Description}\n";
    }
}
