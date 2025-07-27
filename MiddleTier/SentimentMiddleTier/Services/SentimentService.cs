using SentimentMiddleTier.Models;

namespace SentimentMiddleTier.Services
{
    public class SentimentService(HttpClient httpClient, IConfiguration configuration)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _mlEndpoint = configuration["MLApiBaseUrl"] ?? "http://127.0.0.1:8000";

        public async Task<SentimentResponse> PredictAsync(SentimentRequest input)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_mlEndpoint}/analyze", input);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SentimentResponse>() ?? new SentimentResponse { Sentiment="None" };
        }
    }
}
