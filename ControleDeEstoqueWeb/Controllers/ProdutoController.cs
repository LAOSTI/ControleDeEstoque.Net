using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueWeb.Controllers
{
	public class ProdutoController : Controller
	{
		private readonly IProductServices _productServices;

		public ProdutoController(IProductServices productServices)
		{
			_productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
		}

		public async Task<IActionResult> Index()
		{
			var Produtos = await _productServices.FindAllProducts();
			return View(Produtos);
		}
		public IActionResult CriarProduto()
		{
			return View();
		}

		public async Task<IActionResult> InserirProduto(ProductModel model)
		{
			if (ModelState.IsValid)
			{
                var response = await _productServices.CriarProduto(model);
				if (response != null) return RedirectToAction(nameof(Index));
                
            }
            return View(model);
        }
		public async Task<IActionResult> AtualizarProduto(int id)
		{
            var model = await _productServices.FindProductById(id);
			if (model != null) return View(model);
            return NotFound();
		}

		public async Task<IActionResult> EditarProduto(ProductModel model)
		{
			if (ModelState.IsValid)
			{
                var response = await _productServices.AtualizarProduto(model);
				if (response != null) return RedirectToAction(nameof(Index));
                
            }
            return View(model);
        }
		public async Task<IActionResult> DeleteProduto(int id)
		{
            var model = await _productServices.FindProductById(id);
			if (model != null) return View(model);
            return NotFound();
		}

		public async Task<IActionResult> DeletarProduto(ProductModel model)
		{
                var response = await _productServices.DeleteProductById(model.Id);
				if (response) return RedirectToAction(nameof(Index));

            return View(model);
        }
	}
}
