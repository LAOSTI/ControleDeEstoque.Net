using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoqueWeb.Controllers
{
    public class VendaController : Controller
    {
        private IVendasService _vendasService;

        public VendaController(IVendasService vendasService)
        {
            _vendasService = vendasService ?? throw new ArgumentNullException(nameof(vendasService));
        }

        public async Task<IActionResult> Index()
        {
            var vendas = await _vendasService.FindAllVenda();
            return View(vendas);
        }
        public IActionResult CadastrarVendas()
        {
            return View();
        }

        public async Task<IActionResult> InserirVenda(VendasModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vendasService.CriarVenda(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> EditarVenda(long id)
        {
            var model = await _vendasService.FindVendaById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        public async Task<IActionResult> AtualizarVenda(VendasModel model)
        {
            if (ModelState.IsValid) 
            {
                var response = await _vendasService.AtualizarVendas(model);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> VendaIndex(long id)
        {
            var model = await _vendasService.FindVendaById(id);
            if(model !=null)return View(model);
            return NotFound();
        }

        public async Task<IActionResult> DeletarVenda(VendasModel model)
        {
            var response = await _vendasService.DeleteVenda(model.Id);
            if(response)return RedirectToAction(nameof(Index));
            return View(model);
        }
    }
}
