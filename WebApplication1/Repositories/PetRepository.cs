using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pet>> GetAllPetsAsync()
    {
        return await _context.Pets
            .Include(p => p.Cliente)
            .ToListAsync();
    }

    public async Task<Pet?> GetPetByIdAsync(int id)
    {
        return await _context.Pets
            .Include(p => p.Cliente)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Pet>> GetPetsByClienteIdAsync(int clienteId)
    {
        return await _context.Pets
            .Where(p => p.ClienteId == clienteId)
            .ToListAsync();
    }

    public async Task Add(Pet pet)
    {
        await _context.Pets.AddAsync(pet);
    }

    public async Task Update(Pet pet)
{
    var existing = await _context.Pets.FindAsync(pet.Id);

    if (existing == null)
        return;

    existing.Nome = pet.Nome;
    existing.Especie = pet.Especie;
    existing.Raca = pet.Raca;
    existing.ClienteId = pet.ClienteId;
    existing.Ativo = pet.Ativo;

    await _context.SaveChangesAsync();
}

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}