using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;


namespace EntityFramworkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams {get;set;}
        public DbSet<Coach> Coaches {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=FootballLeague_EfCore.db");
        }
    }
}