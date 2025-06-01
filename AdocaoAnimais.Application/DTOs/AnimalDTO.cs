namespace AdocaoAnimais.Application.DTOs;

public record AnimalDTO(Guid Id, string Nome, string Especie, DateTime DataNasc, bool Adotado);