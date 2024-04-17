using Microsoft.EntityFrameworkCore;
using Project1_PetsAPI.Models;

namespace Project1_PetsAPI.Data;

public class PetsAPIContext : DbContext
{
    public PetsAPIContext() : base() {}
    public PetsAPIContext(DbContextOptions options) : base(options) {}

    public DbSet<Pet> Pets { get; set; }
}
