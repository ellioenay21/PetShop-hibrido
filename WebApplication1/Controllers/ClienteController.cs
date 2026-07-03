using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

public class ClienteController : Controller
{
    private readonly IClienteRepository _clienteRepository;
    private readonly ClienteServices _clienteService;

    public ClienteController(
        IClienteRepository clienteRepository,
        ClienteServices clienteService)
    {
        _clienteRepository = clienteRepository;
        _clienteService = clienteService;
    }

    // Lstagem de todos os Clientes
    public async Task<IActionResult> Index()
    {
        var clientes = await _clienteRepository.GetAll();
        return View(clientes);
    }

    // Detalhe do clientes
    public async Task<IActionResult> Details(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    // Pagina de cadastro
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Criar cliente comvalidaçao de CPF
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return View(cliente);
        // Busca no banco se jaexiste o CPF
        var cpfExistente =
            await _clienteRepository.GetByCpfAsync(cliente.CPF);

        if (cpfExistente != null)
        {
            ModelState.AddModelError(
                "CPF",
                "Já existe um cliente cadastrado com este CPF.");

            return View(cliente);
        }

        cliente.Ativo = true;

        await _clienteRepository.Add(cliente);
        await _clienteRepository.Save();

        return RedirectToAction(nameof(Index));
    }

    // Editar cliente
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var cliente =
            await _clienteRepository.GetClienteByIdAsync(id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    // Validaçao da ediçao do cliente se informarum CPF ja existente
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Cliente cliente)
    {
        if (!ModelState.IsValid)
            return View(cliente);

        var cpfExistente =
            await _clienteRepository.GetByCpfAsync(cliente.CPF);

        if (cpfExistente != null &&
            cpfExistente.Id != cliente.Id)
        {
            ModelState.AddModelError(
                "CPF",
                "Já existe outro cliente com este CPF.");

            return View(cliente);
        }

        await _clienteRepository.Update(cliente);
        await _clienteRepository.Save();

        return RedirectToAction(nameof(Index));
    }

    // Inativar o cliente
    public async Task<IActionResult> Inativar(int id)
    {
        await _clienteService.Inativar(id);

        return RedirectToAction(
            nameof(Details),
            new { id });
    }

    // Ativar o cliente
    public async Task<IActionResult> Ativar(int id)
    {
        await _clienteService.Ativar(id);

        return RedirectToAction(
            nameof(Details),
            new { id });
    }
    // Deletar o cliente juntos com os Pets com confirmaçao
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);

            if (cliente == null)
                return NotFound();

         return View(cliente);
    }
    // Esse metodo vai confirmar se dezeja deletar o Cliente
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
    var cliente = await _clienteRepository.GetClienteByIdAsync(id);

        if (cliente == null)
            return NotFound();

        await _clienteService.Delete(id);

        return RedirectToAction(nameof(Index));
    }

}