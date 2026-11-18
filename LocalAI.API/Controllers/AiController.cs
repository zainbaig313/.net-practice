using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class AiController : ControllerBase
{
    private readonly IAiService _aiService;

    public AiController(IAiService aiService)
    {
        _aiService = aiService;

    }

    [HttpPost("chat")]
    public async Task<ActionResult<ChatResponceDto>> Chat(ChatRequestDto request)
    {
        var result  = await _aiService.GetResponseAsync(request);

        return Ok(result);
    }
}