using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Application.Helpers;
using InfoTrack.Domain.Dto;
using InfoTrack.Domain.InputModels;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace InfoTrack.SearchAPI.Config
{
    public class SearchDtoMapper : ISearchDtoMapper
    {
        private readonly GoogleSettings _googleSettings;
        public SearchDtoMapper(IOptions<GoogleSettings> googleSettings)
        {
            _googleSettings = googleSettings.Value;
        }
        public SearchInputDto Map(SearchInput input)
        {
            var url = _googleSettings.URL;
            var parentDiv = _googleSettings.PatternMatch;
            parentDiv = StringHelper.ReplaceQuot(parentDiv);

            var dto = new SearchInputDto
            {
                PageSource = string.Empty,
                Input = input,
                ParentDivPattern = @parentDiv,
                Url = string.Concat(url, UrlEncoder.Default.Encode(input.SearchTerm))
            };

            return dto;
        }
    }
}
