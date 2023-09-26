using ControleDeEstoqueAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ControleDeEstoqueAPI.Model
{
	[Table("cliente")]
	public class Cliente : BaseEntity
	{
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [Column("cpf_cnpj")]
        [Required]
        [StringLength(14)]
        public string cpf_cnpj { get; set; }

        [Column("rg")]
        [Required]
        [StringLength(10)]
        public string rg { get; set; }

        [Column("rua")]
        [Required]
        [StringLength(50)]
        public string rua { get; set; }

        [Column("numero")]
        [Required]
        [StringLength(10)]
        public int numero { get; set; }

        [Column("bairro")]
        [Required]
        [StringLength(150)]
        public string bairro { get; set; }

        [Column("cidade")]
        [Required]
        [StringLength(150)]
        public string cidade { get; set; }

        [Column("estado")]
        [Required]
        [StringLength(150)]
        public string estado { get; set; }

        [Column("pais")]
        [Required]
        [StringLength(100)]
        public string pais { get; set; }

        [Column("telefone")]
        [Required]
        [StringLength(15)]
        public string telefone { get; set; }
    }
}
