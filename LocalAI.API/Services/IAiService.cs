public interface IAiService
{
    Task<ChatResponceDto> GetResponseAsync(ChatRequestDto request);
}