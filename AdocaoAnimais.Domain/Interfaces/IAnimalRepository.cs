using AdocaoAnimais.Domain.Entities;

namespace AdocaoAnimais.Domain.Interfaces;

public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> GetAllAsync(string? especie);
    Task SaveAsync(Animal animal);
    Task<Animal?> AdoptAsync(Guid id);
    Task<IEnumerable<Animal>> GetAdoptedAsync();
}