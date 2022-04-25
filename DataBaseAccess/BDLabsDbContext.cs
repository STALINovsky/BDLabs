using Microsoft.EntityFrameworkCore;
using Model;

namespace DataBaseAccess
{
    public class BDLabsDbContext : DbContext
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=CourseDb;Integrated Security=True;";
        public BDLabsDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Emploee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    }
}