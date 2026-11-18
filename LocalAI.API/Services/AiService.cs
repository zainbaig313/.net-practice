using System.Text.Json;

public class AiService : IAiService
{
    private readonly HttpClient _httpClient;
    public AiService(HttpClient httpclient)
    {
        _httpClient = httpclient;
    }

    public async Task<ChatResponceDto> GetResponseAsync(ChatRequestDto request)
    {
        var ollamRequest = new
        {
            model = "qwen3:0.6b",
            system = "You are a helpful assistant. Always respond in English",
            Prompt = request.Prompt,
            stream = false,
            think = false
        };

        var response = await _httpClient.PostAsJsonAsync(
            "api/generate",
            ollamRequest
        );

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();

        return new ChatResponceDto
        {
            Response = result.GetProperty("response").GetString() ?? string.Empty
        };


    }
}