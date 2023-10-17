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

        public async Task<IActionResult> VendasIndex()
        {
            var vendas = await _vendasService.FindAllVenda();
            return View(vendas);
        }
        public async Task<IActionResult> CriarVendas()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarVendas(VendasModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vendasService.CriarVenda(model);
                if (response != null) return RedirectToAction(nameof(VendasIndex));
            }
            return View(model);
        }
        public async Task<IActionResult> AtualizarVenda(long id)
        {
            var model = await _vendasService.FindVendaById(id);
            if (model != null) return View(model);
            return NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarVenda(VendasModel model)
        {
            if (ModelState.IsValid) 
            {
                var response = await _vendasService.AtualizarVenda(model);
                if (response != null) return RedirectToAction(nameof(VendasIndex));
            }
            return View(model);
        }
        public async Task<IActionResult> DeleteVenda(long id)
        {
            var model = await _vendasService.FindVendaById(id);
            if(model !=null)return View(model);
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteVenda(VendasModel model)
        {
            var response = await _vendasService.DeleteVenda(model.Id);
            if(response)return RedirectToAction(nameof(VendasIndex));
            return View(model);
        }
    }
}
