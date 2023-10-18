using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices ?? throw new ArgumentNullException(nameof(clienteServices));
        }
        
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteServices.FindAllClientes();
            return View(clientes);
        }
        
        public IActionResult CadastrarCliente()
        {
            return View();
        }

        public async Task<IActionResult> InserirCliente(ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                var cliente = await _clienteServices.CreateClientes(model);
                if (cliente != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> EditarCliente(int id)
        {
            var model = await _clienteServices.FindClientesById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        public async Task<IActionResult> AtualizarCliente(ClienteModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _clienteServices.UpdateClientes(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> ClienteIndex(int id)
        {
            var model = await _clienteServices.FindClientesById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        public async Task<IActionResult> DeletarCliente(ClienteModel model)
        {
            var response = await _clienteServices.DeleteClientes(model.Id);
            if (response) return RedirectToAction(nameof(Index));
            return View(model);
        }
    }
}
