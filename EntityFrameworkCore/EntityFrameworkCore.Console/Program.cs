using EntityFramworkCore.Data;

var context = new FootballLeagueDbContext();

var teams = context.Teams.ToList();

foreach (var team in teams)
{
    Console.WriteLine(team.Name);
}
