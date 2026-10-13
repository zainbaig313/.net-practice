

using EntityFrameworkCore.Domain;
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
// var ascorder = await context.Teams
//             .OrderBy( q=> q.Name)
//             .ToListAsync();


// foreach (var item in ascorder)
// {
//     Console.WriteLine(item.Name);
// }
// Console.WriteLine("--------------------------------------");
// var desccorder = await context.Teams
//             .OrderByDescending( q=> q.Name)
//             .ToListAsync();


// foreach (var item in desccorder)
// {
//     Console.WriteLine(item.Name);
// }



//skip and take for pagination . 
// var page = 0;
// var recordcount = 3;
// var next = true;

// while (next)
// {

//     var record = await context.Teams.Skip(page * recordcount).Take(recordcount).ToListAsync();
//     foreach (var item in record)
//     {
//         Console.WriteLine(item.Name);
//     }
//     Console.WriteLine("enter 'true' for next record or 'false' for stop");
//     bool userenter = Convert.ToBoolean(Console.ReadLine());

//     if (!userenter) return;
//     page++;

// }



//select and projection 

// var teamNames  = await context.Teams
//                 .Select(q=>q.Name)
//                 .ToListAsync();

// foreach (var name in teamNames)
// {
//     Console.WriteLine(name);
// }

// //proejcyion is the creation of new object if you want o access multiple colums
// var teamdata  = await context.Teams
//                 .Select(q => new Info{ name= q.Name , id= q.TeamId})
//                 .ToListAsync();

// //forloop here


// public class Info
// {
//     public int id {get;set;}
//     public string name {get;set;}
// }


// ASNOTRACKING or ASTRACKING
// var teamNames  = await context.Teams
//                 .AsNoTracking()
//                 .Select(q=>q.Name)
//                 .ToListAsync();

// foreach (var name in teamNames)
// {
//     Console.WriteLine(name);
// }

// IQueryables and LIST 


//List async use and execure the whole query .and all data of the table;
// Console.WriteLine("1 for id and 2 for F.C");
// var options = Convert.ToInt32(Console.ReadLine());
// List<Team> teamsAsList = new List<Team>();
// teamsAsList = await context.Teams.ToListAsync();
// if (options == 1)
// {
//    teamsAsList = teamsAsList.Where(q=> q.TeamId == 1).ToList();
// }
// else if ( options == 2)
// {
//     teamsAsList = teamsAsList.Where(q => EF.Functions.Like(q.Name , "%adr%")).ToList();
// }
// foreach (var teams in teamsAsList)
// {
//     Console.WriteLine($"team name are {teams.Name}");
// }


// // Iqurables .Builds the query and adds the selected filter without fetching the records yet.
// var teamQuerable  =  context.Teams.AsQueryable();
// //can also
// //IQueryable<Team> teamQuerable =context.Teams;
// if (options == 1)
// {
//    teamQuerable = teamQuerable.Where(q=> q.TeamId == 1);
// }
// else if ( options == 2)
// {
//     teamQuerable = teamQuerable.Where(q => q.Name.Contains("dri"));
// }

// var teamlist = await teamQuerable.ToListAsync();
// foreach (var teams in teamlist)
// {
//     Console.WriteLine($"team name are {teams.Name}");
// }
