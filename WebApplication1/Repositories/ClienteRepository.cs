using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAll()
    {
        return await _context.Clientes
            .Include(c => c.Pets)
            .ToListAsync();
    }

    public async Task<Cliente?> GetClienteByIdAsync(int id)
    {
        return await _context.Clientes
            .Include(c => c.Pets)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cliente?> GetByCpfAsync(string cpf)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(x => x.CPF == cpf);
    }

    public async Task Add(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
    }

    public async Task Update(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await Task.CompletedTask;
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Cliente cliente)
{
    _context.Clientes.Remove(cliente);
    await Task.CompletedTask;
}
}