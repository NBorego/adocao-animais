using AdocaoAnimais.Application.Interfaces;
using AdocaoAnimais.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdocaoAnimais.API.Controllers;

[ApiController]
[Route("api/v1/animais")]
public class AnimalController(IAnimalService service) : ControllerBase
{
    private readonly IAnimalService _service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetAll(string? especie)
    {
        var animais = await _service.GetAllAsync(especie);
        
        return Ok(animais);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Animal animal)
    {
        await _service.SaveAsync(animal);
        
        return NoContent();
    }

    [HttpPut("{id:guid}/adotar")]
    public async Task<IActionResult> Adopt(Guid id)
    {
        var animal = await _service.AdoptAsync(id);

        if (animal == null)
            return NotFound();
        
        return Ok(animal);
    }

    [HttpGet("adotados")]
    public async Task<IActionResult> GetAllAdopted()
    {
        var animal = await _service.GetAdoptedAsync();
        
        return Ok(animal);
    }
    
}