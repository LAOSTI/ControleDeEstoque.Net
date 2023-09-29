using ControleDeEstoqueAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueAPI.Model
{
    [Table("vendas")]
    public class Vendas : BaseEntity
    {
        [Column("data_venda")]
        [StringLength(20)]
        public DateTime data_venda { get; set; }
        [Column("valor")]
        [Required]
        [StringLength(10)]
        public double valor { get; set; }
        [Column("produto")]
        [Required]
        [StringLength(150)]
        public string produto { get; set; }
        [Column("quantidade")]
        [Required]
        [StringLength(150)]
        public int quantidade { get; set; }

    }
}
