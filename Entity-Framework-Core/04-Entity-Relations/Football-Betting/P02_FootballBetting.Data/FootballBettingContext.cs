using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Common;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;

public class FootballBettingContext : DbContext
{
	public FootballBettingContext()
	{

	}

	public FootballBettingContext(DbContextOptions options):base(options)
	{

	}


    DbSet<Team> Teams { get; set; } = null!;

    DbSet<Color> Colors { get; set; } = null!;

    DbSet<Town> Towns { get; set; } = null!;

    DbSet<Country> Countries { get; set; } = null!;

    DbSet<Player> Players { get; set; } = null!;

    DbSet<Position> Positions { get; set; } = null!;

    DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;

    DbSet<Game> Games { get; set; } = null!;

    DbSet<Bet> Bets { get; set; } = null!;

    DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
		}
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<PlayerStatistic>(entity =>
		{
			entity.HasKey(ps => new
			{
				ps.GameId,
				ps.PlayerId
			});
		});

		modelBuilder.Entity<Game>(entity =>
		{
			entity.HasOne(g => g.AwayTeam)
			.WithMany(t => t.AwayGames)
			.HasForeignKey(g => g.AwayTeamId)
            .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(g => g.HomeTeam)
			.WithMany(t => t.HomeGames)
			.HasForeignKey(g => g.HomeTeamId)
			.OnDelete(DeleteBehavior.NoAction);
		});

		modelBuilder.Entity<Team>(entity =>
		{
			entity.HasOne(t => t.PrimaryKitColor)
			.WithMany(c => c.PrimaryKitTeams)
			.HasForeignKey(t => t.PrimaryKitColorId)
			.OnDelete(DeleteBehavior.NoAction);

			entity.HasOne(t=>t.SecondaryKitColor)
			.WithMany(c=>c.SecondaryKitTeams)
			.HasForeignKey(t=>t.PrimaryKitColorId)
			.OnDelete(DeleteBehavior.NoAction);

		});

    }
}