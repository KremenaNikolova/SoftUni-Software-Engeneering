
namespace Theatre.Data
{
    using Microsoft.EntityFrameworkCore;
    using Theatre.Data.Models;

    public class TheatreContext : DbContext
    {
        public TheatreContext() 
        {
        }

        public TheatreContext(DbContextOptions options)
        : base(options) 
        { 
        }

        public DbSet<Cast> Casts { get; set; } = null!;

        public DbSet<Play> Plays { get; set; } = null!;

        public DbSet<Theatre> Theatres { get; set; } = null!;

        public DbSet<Ticket> Tickets { get; set; } = null!;

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
            base.OnModelCreating(modelBuilder); 
        }
    }
}