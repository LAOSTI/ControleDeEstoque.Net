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

		public async Task<IActionResult> ProdutoIndex()
		{
			var produtos = await _productServices.FindAllProducts();
			return View(produtos);
		}
		public async Task<IActionResult> CriarProduto()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CriarProduto(ProductModel model)
		{
			if (ModelState.IsValid)
			{
                var response = await _productServices.CreateProduct(model);
				if (response != null) return RedirectToAction(nameof(ProdutoIndex));
                
            }
            return View(model);
        }
		public async Task<IActionResult> AtualizarProduto(int id)
		{
            var model = await _productServices.FindProductById(id);
			if (model != null) return View(model);
            return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> AtualizarProduto(ProductModel model)
		{
			if (ModelState.IsValid)
			{
                var response = await _productServices.UpdateProduct(model);
				if (response != null) return RedirectToAction(nameof(ProdutoIndex));
                
            }
            return View(model);
        }
		public async Task<IActionResult> DeleteProduto(int id)
		{
            var model = await _productServices.FindProductById(id);
			if (model != null) return View(model);
            return NotFound();
		}
		[HttpPost]
		public async Task<IActionResult> DeleteProduto(ProductModel model)
		{
                var response = await _productServices.DeleteProductById(model.Id);
				if (response) return RedirectToAction(nameof(ProdutoIndex));

            return View(model);
        }
	}
}
