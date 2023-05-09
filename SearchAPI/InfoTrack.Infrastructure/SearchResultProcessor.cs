using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Application.Helpers;
using InfoTrack.Domain.Dto;

namespace InfoTrack.Infrastructure
{
    public class SearchResultProcessor : ISearchResultProcessor
    {

        public Task<string> ProcessSearchResults(SearchInputDto dto)
        {
            if (!dto.PageSource.Contains(dto.ParentDivPattern)) throw new Exception("Search not available");

            return Task.Run(() => StringHelper.GetReturnValue(dto));
        }


    }
}
