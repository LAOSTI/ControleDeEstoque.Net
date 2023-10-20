using ControleDeEstoqueAPI.Data.ValueObjects;
using ControleDeEstoqueAPI.Model;
using ControleDeEstoqueAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class VendaController : ControllerBase
	{
		private IVendasRepository _repository;

		public VendaController(IVendasRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
		[HttpGet]
		public async Task<ActionResult<VendasVO>> FindAll()
		{
			var venda = await _repository.FindAll();
			return Ok(venda);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult> FindById(long id)
		{
			var venda = await _repository.FindById(id);
			if (venda == null) return NotFound();
			return Ok(venda);
		}
		[HttpPost]
		public async Task<ActionResult<VendasVO>> Create([FromBody]VendasVO vo)
		{
			if(vo==null) return BadRequest();
			var venda = await _repository.Create(vo);
			return Ok(venda);
		}
		[HttpPut]
		public async Task<ActionResult<VendasVO>> Update([FromBody]VendasVO vo)
		{
			if(vo==null) return BadRequest();
			var venda = await _repository.Update(vo);
			return Ok(venda);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id)
		{
			var status = await _repository.Delete(id);
			if(!status) return BadRequest();
			return Ok(status);
		}
	}
}
