namespace ControleDeEstoqueWeb.Models
{
	public class ProductModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Amount { get; set; }
		public string Classification { get; set; }
		public string Mark { get; set; }
	}
}
