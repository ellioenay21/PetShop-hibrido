using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels;

public class PetViewModel
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Especie { get; set; } = string.Empty;
    public string Raca { get; set; } = string.Empty;

    public int ClienteId { get; set; }

    public List<SelectListItem> Clientes { get; set; } = new();
}