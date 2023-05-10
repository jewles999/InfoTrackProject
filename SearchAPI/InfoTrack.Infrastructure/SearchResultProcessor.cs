using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Application.Exceptions;
using InfoTrack.Application.Helpers;
using InfoTrack.Domain.Dto;

namespace InfoTrack.Infrastructure
{
    public class SearchResultProcessor : ISearchResultProcessor
    {
        private readonly INotifier _notifier;
        public SearchResultProcessor(INotifier notifier)
        {
            _notifier = notifier;
        }

        public Task<string> ProcessSearchResults(SearchInputDto dto)
        {
            if (!dto.PageSource.Contains(dto.ParentDivPattern))
            {
                _notifier.NotifyTechSupport(dto.ParentDivPattern);

                throw new ServiceUnavailableException();
            }

            return Task.Run(() => StringHelper.GetReturnValue(dto));
        }


    }
}
