using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoqueWeb.Controllers
{
    public class VendaController : Controller
    {
        private IVendasService _vendasService;
        private IProductServices _productServices;

        public VendaController(IVendasService vendasService, IProductServices productServices)
        {
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _vendasService = vendasService ?? throw new ArgumentNullException(nameof(vendasService));
        }

        public async Task<IActionResult> Index()
        {
            //var produto = await _productServices.FindAllProducts();
            var vendas = await _vendasService.FindAllVenda();
            return View(vendas);
        }
        public async Task<IActionResult> CadastrarVendas()
        {
            var listProducts = await _productServices.FindAllProducts();
            ViewBag.Produtos = new SelectList(listProducts, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> InserirVenda(VendasModel model)
        {
            var produto = await _productServices.FindProductById(model.IdProduto);
            model.NomeProduto = produto.Name;
            if (ModelState.IsValid)
            {
                var response = await _vendasService.CriarVenda(model);

                await _productServices.DarBaixaNoEstoque(model.IdProduto, model.Quantidade);

                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> EditarVenda(long id)
        {
            var model = await _vendasService.FindVendaById(id);
            var listProducts = await _productServices.FindAllProducts();
            ViewBag.Produtos = new SelectList(listProducts, "Id", "Name");
            if (model != null) return View(model);
            return NotFound();
        }

        public async Task<IActionResult> AtualizarVenda(VendasModel model)
        {
            var produto = await _productServices.FindProductById(model.IdProduto);
            model.NomeProduto = produto.Name;
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
