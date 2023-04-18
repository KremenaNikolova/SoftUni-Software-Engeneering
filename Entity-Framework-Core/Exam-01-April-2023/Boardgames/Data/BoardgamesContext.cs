﻿namespace Boardgames.Data
{
    using Boardgames.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BoardgamesContext : DbContext
    {
        public BoardgamesContext()
        {
        }

        public BoardgamesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Boardgame> Boardgames { get; set; } = null!;

        public DbSet<BoardgameSeller> BoardgamesSellers { get; set; } = null!;

        public DbSet<Creator> Creators { get; set; } = null!;

        public DbSet<Seller> Sellers { get; set; } = null!;

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
            modelBuilder.Entity<BoardgameSeller>(e =>
            {
                e.HasKey(bs => new { bs.BoardgameId, bs.SellerId });
            });
        }
    }
}
