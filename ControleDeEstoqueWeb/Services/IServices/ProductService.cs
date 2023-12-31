﻿using ControleDeEstoqueWeb.Models;
using ControleDeEstoqueWeb.Services.IServices;
using ControleDeEstoqueWeb.Utils;
using Microsoft.VisualBasic;
using System.Text.Json;

namespace ControleDeEstoqueWeb.Services
{
    public class ProductService : IProductServices
    {
		private readonly HttpClient _client;
		public const string BasePath = "api/v1/Product";

		public ProductService(HttpClient client)
		{
			_client = client ?? throw new ArgumentNullException(nameof(client));
		}

		public async Task<IEnumerable<ProductModel>> FindAllProducts()
		{
			var response = await _client.GetAsync(BasePath);
			var result = JsonSerializer.Deserialize<IEnumerable<ProductModel>>(response.Content.ReadAsStringAsync().Result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			
			if(result == null)
				return new List<ProductModel>();

			return result;
		}
		public async Task<ProductModel> FindProductById(long id)
		{
			var response = await _client.GetAsync($"{BasePath}/{id}");
			return await response.ReadContentAs<ProductModel>();
		}
		public async Task<ProductModel> CriarProduto(ProductModel model)
        {
			var response = await _client.PostAsJson(BasePath, model);
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<ProductModel>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
		public async Task<ProductModel> AtualizarProduto(ProductModel model)
		{
			var response = await _client.PutAsJson(BasePath, model);
			if (response.IsSuccessStatusCode)
				return await response.ReadContentAs<ProductModel>();
			else throw new Exception("Algo deu errado na chamada da API");
		}
		public async Task<bool> DeleteProductById(long id)
        {
			var response = await _client.DeleteAsync($"{BasePath}/{id}");
			if (response.IsSuccessStatusCode)
			return await response.ReadContentAs<bool>();
			else throw new Exception("Algo deu errado na chamada da API");
		}

        public async Task<bool> DarBaixaNoEstoque(int idProduto, int quantidade)
        {
			var product = await FindProductById(idProduto);

			product.Amount -= quantidade;

			await AtualizarProduto(product);

			return true;
        }
    }
}
