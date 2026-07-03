using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces;
// Onde os metodos sao chamados
public interface IClienteRepository
{
    Task<List<Cliente>> GetAll();
    Task<Cliente?> GetClienteByIdAsync(int id);
    Task<Cliente?> GetByCpfAsync(string cpf);

    Task Add(Cliente cliente);
    Task Update(Cliente cliente);
    Task Delete(Cliente cliente);
    Task Save();
}