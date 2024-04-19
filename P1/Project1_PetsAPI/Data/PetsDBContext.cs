using Microsoft.EntityFrameworkCore;
using Project1_PetsAPI.Models;

namespace Project1_PetsAPI.Data;

public class PetsDBContext : DbContext
{
    public PetsDBContext() : base() {}
    public PetsDBContext(DbContextOptions options) : base(options) {}

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Owner> Owners { get; set; }
}
