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
        public DbSet<Team> Teams {get;set;}
        public DbSet<Coach> Coaches {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Dbpath}");
        }
    }
}