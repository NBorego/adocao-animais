using AdocaoAnimais.Application.DTOs;
using AdocaoAnimais.Domain.Entities;

namespace AdocaoAnimais.Application.Interfaces;

public interface IAnimalService
{
    Task<IEnumerable<AnimalDTO>> GetAllAsync(string? especie);
    Task SaveAsync(Animal animal);
    Task<AnimalDTO?> AdoptAsync(Guid id);
    Task<IEnumerable<AnimalDTO>> GetAdoptedAsync();
}