using CalculatorDataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace CalculatorDataLayer.Data
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperaionsTypes> OperaionsTypes { get; set; }

        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Operation>().ToTable("Operation");
            builder.Entity<OperaionsTypes>().ToTable("OperaionsTypes");
        }
    }
}