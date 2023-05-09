using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Domain.Dto;

namespace InfoTrack.Infrastructure
{
    public class SearchServiceProvider : ISearchServiceProvider
    {
        private readonly IWebSearcher _webSearcher;
        private readonly ISearchResultProcessor _resultProcessor;
        public SearchServiceProvider(IWebSearcher webSearcher, ISearchResultProcessor processor)
        {
            _webSearcher = webSearcher;
            _resultProcessor = processor;
        }
        public async Task<string> GetSearchResult(SearchInputDto dto)
        {
            dto.PageSource = await _webSearcher.GetAsync(dto.Url);
            return await _resultProcessor.ProcessSearchResults(dto);
        }
    }
}
