namespace ControleDeEstoqueWeb.Models
{
	public class VendasModel
	{
        public long Id { get; set; }
        public DateTime data_venda { get; set; }
        public double valor { get; set; }
        public string produto { get; set; }
        public int quantidade { get; set; }
    }
}
