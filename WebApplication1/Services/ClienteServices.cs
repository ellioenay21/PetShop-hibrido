using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services;

public class ClienteServices
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteServices(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<List<Cliente>> GetAll()
    {
        return await _clienteRepository.GetAll();
    }

    public async Task<Cliente?> GetById(int id)
    {
        return await _clienteRepository.GetClienteByIdAsync(id);
    }

    public async Task Create(Cliente cliente)
    {
        await _clienteRepository.Add(cliente);
        await _clienteRepository.Save();
    }

    public async Task Inativar(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);
        if (cliente == null) return;

        cliente.Ativo = false;

        foreach (var pet in cliente.Pets)
            pet.Ativo = false;

        await _clienteRepository.Update(cliente);
        await _clienteRepository.Save();
    }

    public async Task Ativar(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);
        if (cliente == null) return;

        cliente.Ativo = true;

        await _clienteRepository.Update(cliente);
        await _clienteRepository.Save();
    }
    public async Task Delete(int id)
{
    var cliente = await _clienteRepository.GetClienteByIdAsync(id);

    if (cliente == null)
        return;

    await _clienteRepository.Delete(cliente);
    await _clienteRepository.Save();
}
}