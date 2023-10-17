using ControleDeEstoqueWeb.Models;

namespace ControleDeEstoqueWeb.Services.IServices
{
	public interface IVendasService
	{
		Task<IEnumerable<VendasModel>> FindAllVenda();
		Task<VendasModel> FindVendaById(long id);
		Task<VendasModel> CriarVenda(VendasModel model);
		Task<VendasModel> AtualizarVenda(VendasModel model);
		Task<bool> DeleteVenda(long id);
	}
}
