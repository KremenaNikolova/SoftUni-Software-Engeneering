namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CategoryProduct> CategoryProducts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ProductId});
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .HasMany(e => e.ProductsBought)
                    .WithOne(e => e.Buyer)
                    .HasForeignKey(e => e.BuyerId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasMany(e => e.ProductsSold)
                    .WithOne(e => e.Seller)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .Property(e => e.Price)
                    .HasColumnType("decimal(18,4)");
            });
        }
    }
}