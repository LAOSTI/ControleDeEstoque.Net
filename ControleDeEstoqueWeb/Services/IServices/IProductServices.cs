using ControleDeEstoqueWeb.Models;

namespace ControleDeEstoqueWeb.Services.IServices
{
	public interface IProductServices
	{
		Task<IEnumerable<ProductModel>> FindAllProducts();
		Task<ProductModel> FindProductById(long id);
		Task<ProductModel> CriarProduto(ProductModel model);
		Task<ProductModel> AtualizarProduto(ProductModel model);
		Task<bool> DeleteProductById(long id);
		Task<bool> DarBaixaNoEstoque(int idProduto, int quantidade);
	}
}
