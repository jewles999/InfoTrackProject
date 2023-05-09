using FluentValidation;
using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Domain.Dto;
using InfoTrack.Domain.InputModels;
using InfoTrack.SearchAPI.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IValidator<SearchInput> _validator;
        private readonly ISearchServiceProvider _searchService;
        private readonly GoogleSettings _googleSettings;
        public SearchController(IValidator<SearchInput> validator, ISearchServiceProvider searchService,
            IOptions<GoogleSettings> googleSettings)
        {
            _validator = validator;
            _searchService = searchService;
            _googleSettings = googleSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SearchByKeywords(SearchInput input)
        {
            var validationResult = await _validator.ValidateAsync(input);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var url = _googleSettings.URL;
            var parentDiv = _googleSettings.PatternMatch;
            parentDiv = parentDiv.Replace("&quot;", @"""");

            var dto = new SearchInputDto
            {
                PageSource = string.Empty,
                Input = input,
                ParentDivPattern = @parentDiv,
                Url = string.Concat(url, UrlEncoder.Default.Encode(input.SearchTerm))
            };

            var res = await _searchService.GetSearchResult(dto);
            return Ok(res);
        }
    }
}
