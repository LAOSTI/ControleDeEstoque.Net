using ControleDeEstoqueAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueAPI.Model
{
    [Table("Product")]
	public class Product : BaseEntity
	{
		[Column("Name")]
        [Required]
        [StringLength(150)]
		public string Name { get; set; }

		[Column("Price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("Amount")]
		[Required]
        [Range(1, 10000)]
		public int Amount { get; set; }

        [Column("Classification")]
        [StringLength(50)]
        public string Classification { get; set; }

        [Column("Mark")]
        [StringLength(50)]
        public string Mark { get; set; }

    }
}
