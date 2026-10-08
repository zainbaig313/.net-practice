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


// //group by
// var groupedItems  = context.Teams
//  //           .Where(q => q.Name == "realmadrid") //transalte into Where 
//             .GroupBy(q=>q.DateCreated.Date)
//             .Where( q=>q.Count()>2);   //translate into having class 

//  foreach (var item in groupedItems)
//  {
//     // Console.WriteLine(item.Key);
//     foreach (var team in item)
//     {
//         Console.WriteLine(team.Name);
//     }
//  }

//orderby 
var ascorder = await context.Teams
            .OrderBy( q=> q.Name)
            .ToListAsync();


foreach (var item in ascorder)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine("--------------------------------------");
var desccorder = await context.Teams
            .OrderByDescending( q=> q.Name)
            .ToListAsync();


foreach (var item in desccorder)
{
    Console.WriteLine(item.Name);
}