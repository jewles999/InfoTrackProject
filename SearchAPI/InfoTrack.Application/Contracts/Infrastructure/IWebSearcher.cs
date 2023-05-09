namespace InfoTrack.Application.Contracts.Infrastructure
{
    public interface IWebSearcher
    {
        Task<string> GetAsync(string url);
    }
}
