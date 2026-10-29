
using Hangfire;
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
        BackgroundJob.Schedule(() => Console.WriteLine("hello from controller"),TimeSpan.FromSeconds(5));
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
        var jobid = BackgroundJob.Schedule(()=> Console.WriteLine("you are about to take off"),TimeSpan.FromSeconds(10));
        BackgroundJob.ContinueJobWith(jobid,()=>Console.WriteLine("Going Hot"));
        return Ok("background job done");

    }
}