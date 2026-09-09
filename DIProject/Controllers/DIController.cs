using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/DI")]

public class DIController : ControllerBase
{
    [HttpGet]
    public ActionResult GetService(IMyService myService)
    {
       myService.LogCreation("Root");
       return Ok("check the console for log");
    }

    public IActionResult GetDivisionResult(int num1, int num2)
    {
        try
        {
            float result = num1/num2 ;
            return Ok("here is the result :" + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("divided by zero");
            return BadRequest("cannot divide by zero");
        }
    }
}