using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using ControleDeEstoqueWeb.Utils;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoqueWeb.Services
{
	public class VendasService : IVendasService
	{
		private readonly HttpClient _client;
		public const string BasePath = "api/v1/Vendas";

		public VendasService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}
		public async Task<IEnumerable<VendasModel>> FindAllVenda()
		{
			var response = await _client.GetAsync(BasePath);
			return await response.ReadContentAs<List<VendasModel>>();
		}
		public async Task<VendasModel> FindVendaById(long id)
		{
			var response = await _client.GetAsync($"{BasePath}/{id}");
			return await response.ReadContentAs<VendasModel>();
		}
		public async Task<VendasModel> CriarVenda(VendasModel model)
		{
			var response = await _client.PostAsJson<VendasModel>(BasePath, model);
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<VendasModel>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
		public async Task<VendasModel> AtualizarVenda(VendasModel model)
		{
			var response = await _client.PutAsJson<VendasModel>(BasePath, model);
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<VendasModel>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
		public async Task<bool> DeleteVenda(long id)
		{
			var response = await _client.DeleteAsync($"{BasePath}/{id}");
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<bool>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
	}
}
