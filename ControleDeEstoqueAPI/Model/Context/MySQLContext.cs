using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueAPI.Model.Context
{
	public class MySQLContext : DbContext
	{
        public MySQLContext(){}
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}
        public DbSet<Product> Products { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vendas> Vendas { get; set; }
    }
}
