using Microsoft.AspNetCore.Mvc;

namespace  Practice.Controllers
{
    public class WeatherforeCast
    {
        public DateTime Date {get;set;}
         
         public int Temprature {get;set;}

         public string? Summary {get; set;}
    }

    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        public static readonly string[] Summaries = new[]
        {
             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

        };


        [HttpGet]

        public IEnumerable<WeatherforeCast> Get()
        {
            var rng = new Random();

            return Enumerable.Range(1, 5).Select( index=> new WeatherforeCast
            {
                Date = DateTime.Now.AddDays(index),
                Temprature = rng.Next(-20,55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherforeCast forecast)
        {
            return Ok(forecast);
        }




        // #####################################
        [HttpGet("search")]
        public string Get(string? q , int page =1 )
        {
            return $"searcing for {q} in page {page}";
        }

        [HttpGet("product/{id:int:min(0)}")]
        public string Get(int id )
        {
            return $"your id is {id}";
        }



        [HttpGet("services")]
        public IActionResult GetService(IMySerivce myservice)
        {
            myservice.LogCreation("root");
            return Ok("cheack the console for services creation log");
        }
    }

}