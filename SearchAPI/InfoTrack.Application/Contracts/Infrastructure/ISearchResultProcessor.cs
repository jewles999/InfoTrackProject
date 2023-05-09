using InfoTrack.Domain.Dto;

namespace InfoTrack.Application.Contracts.Infrastructure
{
    public interface ISearchResultProcessor
    {
        Task<string> ProcessSearchResults(SearchInputDto dto);
    }
}
