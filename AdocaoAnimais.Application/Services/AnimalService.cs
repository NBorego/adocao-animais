using AdocaoAnimais.Application.DTOs;
using AdocaoAnimais.Application.Interfaces;
using AdocaoAnimais.Domain.Entities;
using AdocaoAnimais.Domain.Interfaces;

namespace AdocaoAnimais.Application.Services;

public class AnimalService(IAnimalRepository animalRepository) : IAnimalService
{
    private readonly IAnimalRepository _animalRepository = animalRepository;

    public async Task<IEnumerable<AnimalDTO>> GetAllAsync(string? especie)
    {
        var animais = await _animalRepository.GetAllAsync(especie);

        return animais.Select(a => new AnimalDTO(a.Id, a.Nome, a.Especie, a.DataNasc, a.Adotado));
    }

    public async Task SaveAsync(Animal animal)
    {
        await _animalRepository.SaveAsync(animal);
    }

    public async Task<AnimalDTO?> AdoptAsync(Guid id)
    {
        var animal = await _animalRepository.AdoptAsync(id);

        if (animal == null)
            return null;
        
        var dto = new AnimalDTO(animal.Id, animal.Nome, animal.Especie, animal.DataNasc, animal.Adotado);
        
        return dto;
    }

    public async Task<IEnumerable<AnimalDTO>> GetAdoptedAsync()
    {
        var animais = await _animalRepository.GetAdoptedAsync();
        
        var dto = animais
            .Select(a => new AnimalDTO(a.Id, a.Nome, a.Especie, a.DataNasc, a.Adotado)).ToList();
        
        return dto;
    }
}