using AutoMapper;
using ControleDeEstoqueAPI.Data.ValueObjects;
using ControleDeEstoqueAPI.Model;
using ControleDeEstoqueAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueAPI.Repository
{
	public class ClienteRepository : IClienteRepository
	{
		private readonly MySQLContext _context;
		private IMapper _mapper;
        public ClienteRepository(MySQLContext context,IMapper mapper)
        {
            _context = context;
			_mapper = mapper;
        }
		public async Task<IEnumerable<ClienteVO>> FindAll()
		{
			List<Cliente> cliente = await _context.Cliente.ToListAsync();
			return _mapper.Map < List<ClienteVO>>(cliente);
		}

		public async Task<ClienteVO> FindById(long id)
		{
			Cliente cliente = await _context.Cliente.Where(c => c.Id == id).FirstOrDefaultAsync();
			return _mapper.Map<ClienteVO>(cliente);
		}
		public async Task<ClienteVO> Create(ClienteVO vo)
		{
			Cliente cliente = _mapper.Map<Cliente>(vo);
			_context.Cliente.Add(cliente);
			await _context.SaveChangesAsync();
			return _mapper.Map<ClienteVO>(cliente);
		}
		public async Task<ClienteVO> Update(ClienteVO vo)
		{
			Cliente cliente = _mapper.Map<Cliente>(vo);
			_context.Cliente.Update(cliente);
			await _context.SaveChangesAsync();
			return _mapper.Map<ClienteVO>(cliente);
		}
		public async Task<bool> Delete(long id)
		{
			try
			{
				Cliente cliente = await _context.Cliente.Where(c=>c.Id==id).FirstOrDefaultAsync();
				if (cliente == null) return false;
				_context.Cliente.Remove(cliente);
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
