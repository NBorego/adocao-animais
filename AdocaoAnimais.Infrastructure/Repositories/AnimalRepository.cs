using AdocaoAnimais.Domain.Entities;
using AdocaoAnimais.Domain.Interfaces;
using AdocaoAnimais.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AdocaoAnimais.Infrastructure.Repositories;

public class AnimalRepository(AppDbContext context) : IAnimalRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<IEnumerable<Animal>> GetAllAsync(string? especie)
    {
        var query = _context.Animals.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(especie))
            query = query.Where(a => a.Especie.Contains(especie));
        
        return await query.ToListAsync();
    }

    public async Task SaveAsync(Animal animal)
    {
        await _context.Animals.AddAsync(animal);
        await _context.SaveChangesAsync();
    }

    public async Task<Animal?> AdoptAsync(Guid id)
    {
        var animal = await _context.Animals.SingleOrDefaultAsync(a => a.Id == id);
        
        if (animal == null)
            return null;
        
        animal.Adopt();
        await _context.SaveChangesAsync();
        
        return animal;
    }

    public async Task<IEnumerable<Animal>> GetAdoptedAsync()
    {
        var animais = await _context.Animals
            .Where(a => a.Adotado)
            .ToListAsync();
        
        return animais;
    }
}