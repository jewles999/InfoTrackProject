using InfoTrack.Application.Contracts.Infrastructure;

namespace InfoTrack.Infrastructure
{
    public class WebSearcher : IWebSearcher
    {
        private readonly HttpClient _client = new();
        public async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
