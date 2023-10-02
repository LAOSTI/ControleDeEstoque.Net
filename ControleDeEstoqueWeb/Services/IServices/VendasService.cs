using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using ControleDeEstoqueWeb.Utils;

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
		public async Task<IEnumerable<VendasModel>> FindAll()
		{
			var response = await _client.GetAsync(BasePath);
			return await response.ReadContentAs<List<VendasModel>>();
		}
		public Task<VendasModel> FindById(long id)
		{
			throw new NotImplementedException();
		}
		public Task<VendasModel> Create(VendasModel model)
		{
			throw new NotImplementedException();
		}
		public Task<VendasModel> Update(VendasModel model)
		{
			throw new NotImplementedException();
		}
		public Task<bool> Delete(long id)
		{
			throw new NotImplementedException();
		}
	}
}
