using ControleDeEstoqueWeb.Models;

namespace ControleDeEstoqueWeb.Services.IServices
{
	public interface IVendasService
	{
		Task<IEnumerable<VendasModel>> FindAll();
		Task<VendasModel> FindById(long id);
		Task<VendasModel> Create(VendasModel model);
		Task<VendasModel> Update(VendasModel model);
		Task<bool> Delete(long id);
	}
}
