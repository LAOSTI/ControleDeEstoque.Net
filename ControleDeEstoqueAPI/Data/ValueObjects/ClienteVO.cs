using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControleDeEstoqueAPI.Data.ValueObjects
{
	public class ClienteVO
	{
        public long Id { get; set; }
        public string name { get; set; }
		public string cpf_cnpj { get; set; }
		public string rg { get; set; }
		public string rua { get; set; }
		public int numero { get; set; }
		public string bairro { get; set; }
		public string cidade { get; set; }
		public string estado { get; set; }
		public string pais { get; set; }
		public string telefone { get; set; }
	}
}
