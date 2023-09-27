using AutoMapper;
using ControleDeEstoqueAPI.Data.ValueObjects;
using ControleDeEstoqueAPI.Model;
using ControleDeEstoqueAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueAPI.Repository
{
	public class VendasRepository : IVendasRepository
	{
		private readonly MySQLContext _context;
		private IMapper _mapper;
        public VendasRepository(MySQLContext context,IMapper mapper)
        {
			_context = context;
            _mapper = mapper;
        }
		public async Task<IEnumerable<VendasVO>> FindAll()
		{
			List<Vendas> vendas = await _context.Vendas.ToListAsync();
			return _mapper.Map<List<VendasVO>>(vendas);
		}
		public async Task<VendasVO> FindById(long id)
		{
			Vendas vendas = await _context.Vendas.Where(v=>v.Id==id).FirstOrDefaultAsync();
			return _mapper.Map<VendasVO>(vendas);
		}
		public async Task<VendasVO> Create(VendasVO vo)
		{
			Vendas vendas = _mapper.Map<Vendas>(vo);
			_context.Vendas.Add(vendas);
			await _context.SaveChangesAsync();
			return _mapper.Map<VendasVO>(vendas);
		}
		public async Task<VendasVO> Update(VendasVO vo)
		{
			Vendas vendas = _mapper.Map<Vendas>(vo);
			_context.Vendas.Update(vendas);
			await _context.SaveChangesAsync();
			return _mapper.Map<VendasVO>(vendas);
		}
		public async Task<bool> Delete(long id)
		{
			try
			{
				Vendas vendas = await _context.Vendas.Where(v => v.Id == id).FirstOrDefaultAsync();
				if (vendas == null) return false;
				_context.Vendas.Remove(vendas);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
