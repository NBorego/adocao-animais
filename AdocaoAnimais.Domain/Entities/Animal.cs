namespace AdocaoAnimais.Domain.Entities;

public class Animal(string nome, string especie, DateTime dataNasc)
{
    public Guid Id { get; init; } =  Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public string Especie { get; private set; } = especie;
    public DateTime DataNasc { get; private set; } = dataNasc;
    public bool Adotado { get; private set; }

    public bool Adopt() => Adotado = true;
}