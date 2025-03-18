using LocalAIAssist.Models;
using System.Text.Json;

namespace LocalAIAssist.Helpers
{
    internal static class OllamaHelper
    {
        public static async Task<ModelInfo[]?> GetAvailableModelsAsync()
        {
            using HttpClient client = new HttpClient();
            string url = "http://localhost:11434/api/tags";

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var models = JsonSerializer.Deserialize<OllamaModelsResponse>(jsonResponse, options);

                return models?.Models;
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode}");
            }
        }
    }
}
