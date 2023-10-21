using ControleDeEstoqueAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoqueAPI.Model
{
    [Table("Vendas")]
    public class Vendas : BaseEntity
    {
        [Column("NomeCliente")]
        [Required]
        [StringLength(150)]
        public string NomeCliente { get; set; }

        [Column("DataVenda")]
        [StringLength(20)]
        public DateTime DataVenda { get; set; }

        [Column("Valor")]
        [Required]
        [StringLength(10)]
        public double Valor { get; set; }

        [Column("IdProduto")]
        [Required]
        [StringLength(150)]
        public int IdProduto { get; set; }

        [Column("Quantidade")]
        [Required]
        [StringLength(150)]
        public int Quantidade { get; set; }

    }
}
