using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{

    public class WeatherForecast

    {

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

    }

    [ApiController]

    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase

    {

        private static readonly string[] Summaries = new[]

        {

        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

    };

        // Method implementations go here

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()

        {

            var rng = new Random();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast

            {

                Date = DateTime.Now.AddDays(index),

                TemperatureC = rng.Next(-20, 55),

                Summary = Summaries[rng.Next(Summaries.Length)]

            }).ToArray();

        }

        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecast forecast)
        {
            // Add data to storage (e.g., database)
            return Ok(forecast);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeatherForecast forecast)
        {
            // Update data for the given ID
            // Example: Find and update an item with a matching ID
            // var existingForecast = /* fetch the data */;
            // existingForecast.Date = forecast.Date
        
        return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delete data for the given ID
            return NoContent();
        }

    }


    // ###################################################################################



    public class Blog
    {
        public required string Title {get;set;}
        public required  string Body {get;set;}
      
    }

    [ApiController]
    [Route("[controller]")]

    public class BlogController : ControllerBase
    {
        private static List<Blog> blogs = new List<Blog>
        {
            new Blog { Title = "my first blog ", Body = "this is my first blog " },
            new Blog { Title = "my second blog ", Body = "this is my second blog " },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            return Ok(blogs);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Blog>> Post([FromBody] Blog blog)
        {
            blogs.Add(blog);
            return Ok(blog);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Blog> Delete(int id)
        {
            if(id < 0|| id >= blogs.Count)
            {
                return BadRequest();
            }
            else
            {
                blogs.RemoveAt(id);
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Blog> Put(int id,[FromBody] Blog updateblog)
        {
            if(id < 0|| id >= blogs.Count)
            {
                return NotFound();
            }
            else
            {
                blogs[id] = updateblog;
                return Ok(updateblog);
            }
            
        }
    
    }
    

}
