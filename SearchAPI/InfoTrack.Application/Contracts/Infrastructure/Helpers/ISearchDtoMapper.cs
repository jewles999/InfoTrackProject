using InfoTrack.Domain.Dto;
using InfoTrack.Domain.InputModels;

namespace InfoTrack.Application.Contracts.Infrastructure
{
    public interface ISearchDtoMapper
    {
        public SearchInputDto Map(SearchInput input);
    }
}
