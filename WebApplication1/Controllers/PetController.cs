using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class PetController : Controller
{
    private readonly IPetRepository _petRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly PetService _petService;

    public PetController(
        IPetRepository petRepository,
        IClienteRepository clienteRepository,
        PetService petService)
    {
        _petRepository = petRepository;
        _clienteRepository = clienteRepository;
        _petService = petService;
    }
    // Pagina onde mostra os Pet, vai mostar todos igual a Paginad de cliente mas sem uma guia de buscar
    public async Task<IActionResult> Index()
    {
        return View(await _petRepository.GetAllPetsAsync());
    }
    // Detalhes do Pet cadastrado
    public async Task<IActionResult> Details(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        if (pet == null)
            return NotFound();

        return View(pet);
    }

    // Criar um pet
    public async Task<IActionResult> Create()
    {
        var clientes = await _clienteRepository.GetAll();
        // Esse metodo ira listar os Clientes cadastrados.
        var vm = new PetViewModel
        {
            Clientes = clientes.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            }).ToList()
        };

        return View(vm);
    }

    // Dados a serem inseridos ao Pet
    [HttpPost]
    public async Task<IActionResult> Create(PetViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var pet = new Pet
        {
            Nome = vm.Nome,
            Especie = vm.Especie,
            Raca = vm.Raca,
            ClienteId = vm.ClienteId,
            Ativo = true
        };

        await _petService.Create(pet);

        return RedirectToAction(nameof(Index));
    }

    // Ativar apenas o Pet
    public async Task<IActionResult> Activate(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        if (pet == null)
            return NotFound();

        await _petService.Activate(id);

        return RedirectToAction("Details", "Cliente", new { id = pet.ClienteId });
    }

    // Inativar apenas o Pet
    public async Task<IActionResult> Deactivate(int id)
    {
        var pet = await _petRepository.GetPetByIdAsync(id);

        if (pet == null)
            return NotFound();

        await _petService.Deactivate(id);

        return RedirectToAction("Details", "Cliente", new { id = pet.ClienteId });
    }
    //Editar
    [HttpGet]
public async Task<IActionResult> Edit(int id)
{
    var pet = await _petRepository.GetPetByIdAsync(id);

    if (pet == null)
        return NotFound();

    return View(pet);
}
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(Pet pet)
{
    if (!ModelState.IsValid)
        return View(pet);

    await _petRepository.Update(pet);

    return RedirectToAction("Details", "Cliente", new { id = pet.ClienteId });
}
}