using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JadooTravel.Services;

public class GenerateContentRequest
{
    [JsonPropertyName("contents")]
    public IEnumerable<Content> Contents { get; set; } = new List<Content>();

}

public class Content
{
    [JsonPropertyName("role")]
    public string Role { get; set; } = "user";

    [JsonPropertyName("parts")]
    public IEnumerable<Part> Parts { get; set; } = new List<Part>();
}

public class Part
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}

public class GeminiService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;
    private readonly string _model;

    public GeminiService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["Gemini:ApiKey"] ?? "";

        _model = config["Gemini:Model"] ?? "gemini-2.5-flash";
    }

    public async Task<string> GenerateItineraryAsync(string city, int stops = 5)
    {
        var url = $"https://generativelanguage.googleapis.com/v1/models/{_model}:generateContent?key={_apiKey}";

        var promptText = $@"{city} için {stops} maddelik gezi rotası oluştur. 
Her madde kısa başlık + açıklama + ipucu içersin. 
Cevabı JSON array olarak döndür. 
Alanlar: title, description, tip.";

        var body = new GenerateContentRequest
        {
            Contents = new List<Content>
            {
                new Content
                {
                    Role = "user",
                    Parts = new List<Part>
                    {
                        new Part { Text = promptText }
                    }
                }
            }
        };

        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var json = JsonSerializer.Serialize(body, options);
        var req = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        var res = await _http.SendAsync(req);
        var resString = await res.Content.ReadAsStringAsync();

        if (!res.IsSuccessStatusCode)
            throw new HttpRequestException($"Gemini API error: {res.StatusCode} - {resString}");

        return resString;
    }
}