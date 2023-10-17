using ControleDeEstoqueAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueAPI.Model
{
	[Table("product")]
	public class Product : BaseEntity
	{
		[Column("name")]
        [Required]
        [StringLength(150)]
		public string Name { get; set; }

		[Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("amount")]
		[Required]
        [Range(1, 10000)]
		public int Amount { get; set; }

        [Column("classification")]
        [StringLength(50)]
        public string Classification { get; set; }

        [Column("mark")]
        [StringLength(50)]
        public string Mark { get; set; }

    }
}
