using ControleDeEstoqueAPI.Data.ValueObjects;

namespace ControleDeEstoqueAPI.Repository
{
	public interface IVendasRepository
	{
		Task<IEnumerable<VendasVO>> FindAll();
		Task<VendasVO> FindById(long id);
		Task<VendasVO> Create(VendasVO vo);
		Task<VendasVO> Update(VendasVO vo);
		Task<bool> Delete(long id);
	}
}
