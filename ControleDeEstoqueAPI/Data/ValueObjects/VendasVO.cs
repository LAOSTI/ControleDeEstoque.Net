using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueAPI.Data.ValueObjects
{
	public class VendasVO
	{
        public long Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataVenda { get; set; }
		public double Valor { get; set; }
		public int IdProduto { get; set; }
		public int Quantidade { get; set; }
	}
}
