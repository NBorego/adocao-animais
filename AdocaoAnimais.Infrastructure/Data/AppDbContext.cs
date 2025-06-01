using AdocaoAnimais.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdocaoAnimais.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Animal> Animals { get; set; }
}