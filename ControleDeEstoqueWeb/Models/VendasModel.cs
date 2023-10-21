namespace ControleDeEstoqueWeb.Models
{
	public class VendasModel
	{
        public long Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataVenda { get; set; }
        public double Valor { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public string? NomeProduto { get; set; }
    }
}
