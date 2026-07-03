namespace WebApplication1.Models;

public class Pet
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Raca { get; set; } = string.Empty;

    public bool Ativo { get; set; } = true;

    public int ClienteId { get; set; }

    public Cliente? Cliente { get; set; }
}