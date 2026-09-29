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
                     Name = "city",
                     DateCreated = new DateTime(2026, 9, 25),
                 }
            );
        }
    }
}