using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;


namespace EntityFramworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {

        private string Dbpath;
        public FootballLeagueDbContext()
        {
            var path = Directory.GetCurrentDirectory();
            Dbpath = Path.Combine(path, "FootballLeague_EfCore.db");
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Dbpath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "realmadrid",
                    DateCreated = new DateTime(2026, 9, 25),
                },
                new Team
                {
                    TeamId = 2,
                    Name = "barcelona",
                    DateCreated = new DateTime(2026, 9, 25),
                },
                new Team
                {
                    TeamId = 3,
                    Name = "manchester city",
                    DateCreated = new DateTime(2026, 9, 26),
                },
                new Team
                {
                    TeamId = 4,
                    Name = "manchester united",
                    DateCreated = new DateTime(2026, 9, 26),
                },
                new Team
                {
                    TeamId = 5,
                    Name = "liverpool",
                    DateCreated = new DateTime(2026, 9, 27),
                },
                new Team
                {
                    TeamId = 6,
                    Name = "arsenal",
                    DateCreated = new DateTime(2026, 9, 27),
                },
                new Team
                {
                    TeamId = 7,
                    Name = "chelsea",
                    DateCreated = new DateTime(2026, 9, 28),
                },
                new Team
                {
                    TeamId = 8,
                    Name = "tottenham",
                    DateCreated = new DateTime(2026, 9, 28),
                },
                new Team
                {
                    TeamId = 9,
                    Name = "bayern munich",
                    DateCreated = new DateTime(2026, 9, 29),
                },
                new Team
                {
                    TeamId = 10,
                    Name = "borussia dortmund",
                    DateCreated = new DateTime(2026, 9, 29),
                },
                new Team
                {
                    TeamId = 11,
                    Name = "inter milan",
                    DateCreated = new DateTime(2026, 9, 30),
                },
                new Team
                {
                    TeamId = 12,
                    Name = "ac milan",
                    DateCreated = new DateTime(2026, 9, 30),
                },
                new Team
                {
                    TeamId = 13,
                    Name = "juventus",
                    DateCreated = new DateTime(2026, 10, 1),
                },
                new Team
                {
                    TeamId = 14,
                    Name = "napoli",
                    DateCreated = new DateTime(2026, 10, 1),
                },
                new Team
                {
                    TeamId = 15,
                    Name = "psg",
                    DateCreated = new DateTime(2026, 10, 2),
                },
                new Team
                {
                    TeamId = 16,
                    Name = "marseille",
                    DateCreated = new DateTime(2026, 10, 2),
                },
                new Team
                {
                    TeamId = 17,
                    Name = "realmadrid",
                    DateCreated = new DateTime(2026, 10, 3),
                },
                new Team
                {
                    TeamId = 18,
                    Name = "barcelona",
                    DateCreated = new DateTime(2026, 10, 3),
                },
                new Team
                {
                    TeamId = 19,
                    Name = "liverpool",
                    DateCreated = new DateTime(2026, 10, 4),
                },
                new Team
                {
                    TeamId = 20,
                    Name = "arsenal",
                    DateCreated = new DateTime(2026, 10, 4),
                }
            );
        }
    }
}