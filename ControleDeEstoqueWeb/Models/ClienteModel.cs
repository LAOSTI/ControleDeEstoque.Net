namespace ControleDeEstoqueWeb.Models
{
	public class ClienteModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string CpfCnpj { get; set; }
		public string Rg { get; set; }
		public string Rua { get; set; }
		public int Numero { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Pais { get; set; }
		public string Telefone { get; set; }
	}
}
