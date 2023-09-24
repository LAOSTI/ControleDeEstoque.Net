using AutoMapper;
using ControleDeEstoqueAPI.Data.ValueObjects;
using ControleDeEstoqueAPI.Model;
using ControleDeEstoqueAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueAPI.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly MySQLContext _context;
		private IMapper _maper;
        public ProductRepository(MySQLContext context,IMapper mapper)
        {
            _context = context;
			_maper = mapper;
        }
		public async Task<IEnumerable<ProductVO>> FindAll()
		{
			List<Product> products = await _context.Products.ToListAsync();
			return _maper.Map<List<ProductVO>>(products);
		}

		public async Task<ProductVO> FindById(long id)
		{
			Product products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
			return _maper.Map<ProductVO>(products);
		}

		public async Task<ProductVO> Create(ProductVO vo)
		{
			Product product = _maper.Map<Product>(vo);
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return _maper.Map<ProductVO>(product);
		}
		public async Task<ProductVO> Update(ProductVO vo)
		{
			Product product = _maper.Map<Product>(vo);
			_context.Products.Update(product);
			await _context.SaveChangesAsync();
			return _maper.Map<ProductVO>(product);
		}

		public async Task<bool> DeleteById(long id)
		{
			try
			{
				Product products = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
				if (products == null)return false;
				_context.Products.Remove(products);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
