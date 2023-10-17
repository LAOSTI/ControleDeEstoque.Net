using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoqueWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            this._clienteServices = clienteServices ?? throw new ArgumentNullException(nameof(clienteServices));
        }

        public async Task<IActionResult> ClienteIndex()
        {
            var clientes = await _clienteServices.FindAllClientes();
            return View(clientes);
        }
        public async Task<IActionResult> CriarCliente()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarCliente(ClienteModel model)
        {
            if(ModelState.IsValid)
            {
                var cliente = await _clienteServices.CreateClientes(model);
                return View(cliente);
            }
            return View(model);
        }
        public async Task<IActionResult> AtualizarCliente(int id)
        {
            var model = await _clienteServices.FindClientesById (id);
            if(model != null)return View(model);
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AtualizarCliente(ClienteModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _clienteServices.UpdateClientes(model);
                if(response != null) return RedirectToAction(nameof(ClienteIndex));
            }
            return View(model);
        }
        public async Task<IActionResult> DeletarCliente(int id)
        {
            var model = await _clienteServices.FindClientesById(id);
            if (model != null) return View(model);
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletarCliente(ClienteModel model)
        {
            var response = await _clienteServices.DeleteClientes(model.Id);
            if(response)return RedirectToAction(nameof(ClienteIndex));
            return View(model);
        }
    }
}
