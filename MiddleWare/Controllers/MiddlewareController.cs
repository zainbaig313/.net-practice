using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/")]


public class MiddlewareController : ControllerBase
{

    public class Blog
    {
        public required string title { get; set; }
        public required string body { get; set; }
    }

    List<Blog> blogs = new List<Blog>
    {
        new Blog { title = "this is 1 title" , body = "this is 1 body"},
        new Blog { title = "this is 2 title" , body = "this is 2 body"},

    };

    [HttpGet]
    public IActionResult GetMessage()
    {
        return Ok(blogs);
    }

    [HttpPost]
    public IActionResult add([FromBody] Blog blog)
    {
        blogs.Add(blog);
        return Ok(blogs);
    }
}