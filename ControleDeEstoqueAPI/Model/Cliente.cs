using ControleDeEstoqueAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueAPI.Model
{
    [Table("Cliente")]
	public class Cliente : BaseEntity
	{
        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string name { get; set; }

        [Column("CpfCnpj")]
        [Required]
        [StringLength(14)]
        public string CpfCnpj { get; set; }

        [Column("Rg")]
        [Required]
        [StringLength(10)]
        public string Rg { get; set; }

        [Column("Rua")]
        [Required]
        [StringLength(50)]
        public string Rua { get; set; }

        [Column("Numero")]
        [Required]
        [StringLength(10)]
        public int Numero { get; set; }

        [Column("Bairro")]
        [Required]
        [StringLength(150)]
        public string Bairro { get; set; }

        [Column("Cidade")]
        [Required]
        [StringLength(150)]
        public string Cidade { get; set; }

        [Column("Estado")]
        [Required]
        [StringLength(150)]
        public string Estado { get; set; }

        [Column("Pais")]
        [Required]
        [StringLength(100)]
        public string Pais { get; set; }

        [Column("Telefone")]
        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }
    }
}
