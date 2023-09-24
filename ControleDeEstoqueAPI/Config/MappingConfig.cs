using AutoMapper;
using ControleDeEstoqueAPI.Data.ValueObjects;
using ControleDeEstoqueAPI.Model;

namespace ControleDeEstoqueAPI.Config
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config => {
				config.CreateMap<ProductVO, Product>();
				config.CreateMap<Product, ProductVO>();
			});
			return mappingConfig;
		}
	}
}
