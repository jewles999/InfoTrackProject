using InfoTrack.Domain.Dto;

namespace InfoTrack.Application.Contracts.Infrastructure
{
    public interface ISearchServiceProvider
    {
        Task<string> GetSearchResult(SearchInputDto s);
    }
}
