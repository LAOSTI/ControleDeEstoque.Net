using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueAPI.Data.ValueObjects
{
	public class ProductVO
	{
        public long Id { get; set; }
        public string Name { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public string Classification { get; set; }
		public string Mark { get; set; }
	}
}
