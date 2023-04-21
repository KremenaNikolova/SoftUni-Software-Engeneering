namespace Footballers.Data
{
    using Footballers.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Coach> Coaches { get; set; } = null!;

        public DbSet<Footballer> Footballers { get; set; } = null!;

        public DbSet<Team> Teams { get; set; } = null!;

        public DbSet<TeamFootballer> TeamsFootballers { get; set; } = null!;


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
            modelBuilder.Entity<TeamFootballer>(e =>
            {
                e.HasKey(tf => new { tf.TeamId, tf.FootballerId });
            });
        }
    }
}
