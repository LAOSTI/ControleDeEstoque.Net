using ControleDeEstoqueAPI.Data.ValueObjects;
using ControleDeEstoqueAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace ControleDeEstoqueAPI.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private IClienteRepository _repository;

		public ClienteController(IClienteRepository repository)
		{
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}
		[HttpGet]
		public async Task<ActionResult<ClienteVO>> FindAll()
		{
			var cliente = await _repository.FindAll();
			return Ok(cliente);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult> FindById(long id)
		{
			var cliente = await _repository.FindById(id);
			if(cliente == null)return NotFound();
			return Ok(cliente);
		}
		[HttpPost]
		public async Task<ActionResult<ClienteVO>> Create([FromBody]ClienteVO vo)
		{
			if(vo == null) return BadRequest();
			var cliente = await _repository.Create(vo);
			return Ok(cliente);
		}
		[HttpPut]
		public async Task<ActionResult<ClienteVO>> Update([FromBody]ClienteVO vo)
		{
			if (vo == null) return BadRequest();
			var cliente = await _repository.Update(vo);
			return Ok(cliente);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(long id)
		{
			var status = await _repository.Delete(id);
			if(!status)return BadRequest();
			return Ok(status);
		}
	}
}
