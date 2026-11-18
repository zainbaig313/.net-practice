
using Hangfire;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class BackgroundWorkerController : ControllerBase
{
    [HttpPost]
    public IActionResult getJob()
    {
        Console.WriteLine(Environment.ProcessorCount * 5);
        //fire and forget
        BackgroundJob.Enqueue(() => Console.WriteLine("hello from controller"));
        return Ok("background job done");

    }

    [HttpPost("delay")]
    public IActionResult DelayJob()
    {
        Console.WriteLine(Environment.ProcessorCount * 5);
        ///delay/Schedule
        BackgroundJob.Schedule(() => Console.WriteLine("hello from controller"), TimeSpan.FromSeconds(5));
        return Ok("background job done");

    }

    [HttpPost("Recurring")]
    public IActionResult Recurring()
    {
        //RecurringJob
        RecurringJob.AddOrUpdate(() => Console.WriteLine("hello from controller"), Cron.Minutely);
        return Ok("background job done");
    }

    [HttpPost("continue")]
    public IActionResult ContinueJob()
    {
        //Continue job or job channing .
        var jobid = BackgroundJob.Schedule(() => Console.WriteLine("you are about to take off"), TimeSpan.FromSeconds(10));
        BackgroundJob.ContinueJobWith(jobid, () => Console.WriteLine("Going Hot"));
        return Ok("background job done");

    }
    [HttpPost("upload")]
    public IActionResult Upload(IFormFile file)
    {
        try
        {
            
        
        Console.WriteLine(file.FileName);
        Console.WriteLine(file.Length);
        Console.WriteLine(file.ContentType);
        if(file.Length<=100000) return Ok($"Name : {file.FileName} \nLength : {file.Length} \nContentType : {file.ContentType}");
        else return Ok("file size must be less than 100KB");
        }
        catch (Exception ex)
        {
            return Ok($"internal error : {ex.Message}");
        }
    }
}