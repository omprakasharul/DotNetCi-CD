using BOL;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace DAL.DBContext
{
    public class DALDbContext : DbContext
    {
        public DALDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Users> users { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Inventory> inventories { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Order_Item> orderItems { get; set; }
        public DbSet<Items> items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
