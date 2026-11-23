using System.Text.Json;

public class AiService : IAiService
{
    private readonly HttpClient _httpClient;
    public AiService(HttpClient httpclient)
    {
        _httpClient = httpclient;
    }

    public async Task<ChatResponseDto> GetResponseAsync(ChatRequestDto request)
    {
        var ollamaRequest = new
        {
            model = "qwen3:1.7b",

            messages = new[]
             {
                new
                {
                    role = "system",
                    content = "You are a helpful assistant. Always respond in English."
                },
                new
                {
                    role = "user",
                    content = request.Prompt
                }
            },

            stream = false,
            think = false
        };

        var tools = new[]
        {
    new
    {
        type = "function",

        function = new
        {
            name = "get_product_count",

            description =
                "Get the total number of products in inventory.",

            parameters = new
            {
                type = "object",

                properties = new { },

                required = Array.Empty<string>()
            }
        }
    }
};


        var response = await _httpClient.PostAsJsonAsync(
            "api/chat",
            ollamaRequest
        );

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<JsonElement>();

        var content = result
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return new ChatResponseDto
        {
            Response = content ?? string.Empty
        };


    }
}