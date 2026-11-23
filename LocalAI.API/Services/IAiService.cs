public interface IAiService
{
    Task<ChatResponseDto> GetResponseAsync(ChatRequestDto request);
}