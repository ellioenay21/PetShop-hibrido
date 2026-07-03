namespace WebApplication1.Models;
// Class cliente
public class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public bool Ativo { get; set; } = true;

    public List<Pet> Pets { get; set; } = new();
}