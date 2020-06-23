using Dominio._1_Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura._0_Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {

        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Animal> Animais { get; set; }
    }
}
