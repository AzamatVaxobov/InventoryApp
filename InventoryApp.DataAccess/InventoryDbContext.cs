using InventoryApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.DataAccess;

public class InventoryDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().ToTable("Products");
    }
}
