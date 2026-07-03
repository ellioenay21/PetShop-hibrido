using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces;

public interface IPetRepository
{
    Task<List<Pet>> GetAllPetsAsync();
    Task<Pet?> GetPetByIdAsync(int id);
    Task<List<Pet>> GetPetsByClienteIdAsync(int clienteId);

    Task Add(Pet pet);
    Task Update(Pet pet);
    Task Save();
}