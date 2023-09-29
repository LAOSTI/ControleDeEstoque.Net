using ControleDeEstoqueWeb.Models;

namespace ControleDeEstoqueWeb.Services.IServices
{
	public interface IClienteServices
	{
		Task<IEnumerable<ClienteModel>> FindAllClientes();
		Task<ClienteModel> FindClientesById(long id);
		Task<ClienteModel> CreateClientes(ClienteModel model);
		Task<ClienteModel> UpdateClientes(ClienteModel model);
		Task<bool> DeleteClientes(long id);
	}
}
