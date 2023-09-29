using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueAPI.Data.ValueObjects
{
	public class VendasVO
	{
		public DateTime data_venda { get; set; }
		public double valor { get; set; }
		public string produto { get; set; }
		public int quantidade { get; set; }
	}
}
