using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(
        [FromBody] EmailRequest request)
    {
        await _emailService.SendEmailAsync(
            request.Recipient,
            request.Subject,
            request.Body);

        return Ok("Email sent successfully.");
    }
}

