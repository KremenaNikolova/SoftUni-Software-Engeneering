namespace VaporStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using VaporStore.Data.Models;

    public class VaporStoreDbContext : DbContext
    {
        public VaporStoreDbContext()
        {
        }

        public VaporStoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; } = null!;

        public DbSet<Developer> Developers { get; set; } = null!;

        public DbSet<Game> Games { get; set; } = null!;

        public DbSet<GameTag> GameTags { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Purchase> Purchases { get; set; } = null!;

        public DbSet<Tag> Tags { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameTag>(e =>
            {
                e.HasKey(gt => new { gt.TagId, gt.GameId });
            });
        }
    }
}