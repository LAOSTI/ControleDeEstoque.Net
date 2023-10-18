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
		public async Task<ClienteModel> FindClientesById(long id)
		{
			var response = await _client.GetAsync($"{BasePath}/{id}");
			return await response.ReadContentAs<ClienteModel>();
		}
		public async Task<ClienteModel> CreateClientes(ClienteModel model)
		{
			var response = await _client.PostAsJson(BasePath, model);
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<ClienteModel>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
		public async Task<ClienteModel> UpdateClientes(ClienteModel model)
		{
			var response = await _client.PutAsJson(BasePath, model);
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<ClienteModel>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
		public async Task<bool> DeleteClientes(long id)
		{
			var response = await _client.DeleteAsync($"{BasePath}/{id}");
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<bool>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
	}
}
