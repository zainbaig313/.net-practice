
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SwaggerController : ControllerBase
{
    public static List<Item> items =  new List<Item>{
        new Item {Id = 1 , Title = "book1"},
        new Item {Id = 22 , Title = "book2"}
    };
    [HttpGet]
    public IActionResult GetAllItems()
    {
        return Ok(items);
    }

     [HttpGet("{id}")]
    public IActionResult GEtItemById(int id)
    {
        var item = items.FirstOrDefault(i=> i.Id == id);
        if(item == null)
        {
            return NotFound("there is not book matching the id");
        }
        return Ok(item);
    }
    [HttpPost]
    public IActionResult AddItem([FromBody] Item item)
    {
        items.Add(item);
        return Ok(items);
    }
    [HttpDelete("{id}")]
    public IActionResult DeketeItem(int id)
    {
        var item = items.FirstOrDefault(i=> i.Id == id);
        if(item == null)
        {
            return NotFound("there is not book matching the id");
        }
        else
        {    
            items.Remove(item);
             return Ok("the book is deleted");
        }
       
    }

}