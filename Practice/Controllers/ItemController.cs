using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/item")]
public class ItemController : ControllerBase
{
    private static List<Item> items = new List<Item>();

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetAll()
    {

        return items;
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetById(int id)
    {
        var item  = items.FirstOrDefault(i=>i.Id == id);

        return item != null ? Ok(item) : NotFound();
    }

    [HttpPost]
    public ActionResult<Item> Create([FromBody] Item item)
    {
        item.Id = items.Count + 1 ;
        items.Add(item);
        return Ok(item);
    }

    [HttpPut("{id}")]
    public ActionResult<Item> Update(int id, [FromBody] Item item)
    {
        var updateitem = items.FirstOrDefault(i => i.Id == id);
        if(updateitem == null) return NotFound();

        updateitem.Name = item.Name;
        updateitem.Des = item.Des;

        return Ok(updateitem);
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteItem(int id)
    {
        var deleteItem = items.FirstOrDefault(i=> i.Id == id);
        if (deleteItem == null) return NoContent() ;

        
        items.Remove(deleteItem);
        return Ok();;
    }
  
}