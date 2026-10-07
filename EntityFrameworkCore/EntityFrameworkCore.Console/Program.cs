using EntityFramworkCore.Data;
using Microsoft.EntityFrameworkCore;

var context = new FootballLeagueDbContext();

// var teams = context.Teams.ToList();

// foreach (var team in teams)
// {
//     Console.WriteLine(team.Name);
// }


// var filterTeams  = await context.Teams
//                     .Where(p => p.Name == "realmadrid")
//                     .ToListAsync();

// foreach (var filterteam in filterTeams)
// {
//     Console.WriteLine(filterteam.Name);
// }
// Console.WriteLine("hello i am in program.cs");
// var likeTeams = await context.Teams
//                 .Where(d => EF.Functions.Like(d.Name , "%dr%"))
//                 .ToListAsync();


// foreach (var like in likeTeams)
// {
//     Console.WriteLine(like.Name);
// }

//SUM
// var sumTeamId = await context.Teams.SumAsync(q=> q.TeamId);

// //avg
// var avgTeamId = await context.Teams.AverageAsync(q=> q.TeamId);

// //max
// var MaxTeamId = await context.Teams.MaxAsync(q=> q.TeamId);

// //min 
// var minTeamId = await context.Teams.MinAsync(q => q.TeamId);

// //count 
// var countTeams =  await context.Teams.CountAsync();

// ///count with condition 

// var countWithName = await context.Teams.CountAsync(q => q.Name == "realmadrid");

// // count wiht the wildcard

// var countwithWildCard = await context.Teams.CountAsync(q=>EF.Functions.Like(q.Name , "%drid%"));