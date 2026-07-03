using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Services;

public class PetService
{
    private readonly IPetRepository _petRepository;
    private readonly IClienteRepository _clienteRepository;

    public PetService(IPetRepository petRepository, IClienteRepository clienteRepository)
    {
        _petRepository = petRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<(bool success, string message)> Create(Pet pet)
    {
        var client = await _clienteRepository.GetClienteByIdAsync(pet.ClienteId);

        if (client == null)
            return (false, "Cliente nao encontrado");

        if (!client.Ativo)
            return (false, "Cliente inativo");

        await _petRepository.Add(pet);
        await _petRepository.Save();

        return (true, "Peti Criado");
    }

    public async Task Activate(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        if (pet == null)
            return;

        var client = await _clienteRepository.GetClienteByIdAsync(pet.ClienteId);

        if (client == null || !client.Ativo)
            return;

        pet.Ativo = true;

        await _petRepository.Update(pet);
        await _petRepository.Save();
    }

    public async Task Deactivate(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        if (pet == null)
            return;

        pet.Ativo = false;

        await _petRepository.Update(pet);
        await _petRepository.Save();
    }
}