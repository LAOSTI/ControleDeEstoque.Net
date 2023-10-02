using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using ControleDeEstoqueWeb.Utils;

namespace ControleDeEstoqueWeb.Services
{
	public class ClienteService : IClienteServices
	{
		private readonly HttpClient _client;
		public const string BasePath = "api/v1/Cliente";

		public ClienteService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}

		public async Task<IEnumerable<ClienteModel>> FindAllClientes()
		{
			var response = await _client.GetAsync(BasePath);
			return await response.ReadContentAs<List<ClienteModel>>();
		}

		public Task<ClienteModel> FindClientesById(long id)
		{
			throw new NotImplementedException();
		}
		
		public Task<ClienteModel> CreateClientes(ClienteModel model)
		{
			throw new NotImplementedException();
		}
		public Task<ClienteModel> UpdateClientes(ClienteModel model)
		{
			throw new NotImplementedException();
		}
		public Task<bool> DeleteClientes(long id)
		{
			throw new NotImplementedException();
		}
	}
}
