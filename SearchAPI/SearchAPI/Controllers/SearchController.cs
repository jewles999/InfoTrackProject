using FluentValidation;
using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Domain.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IValidator<SearchInput> _validator;
        private readonly ISearchServiceProvider _searchService;
        private readonly ISearchDtoMapper _mapper;
        public SearchController(IValidator<SearchInput> validator, ISearchServiceProvider searchService,
            ISearchDtoMapper mapper)
        {
            _validator = validator;
            _searchService = searchService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> SearchByKeywords(SearchInput input)
        {
            var validationResult = await _validator.ValidateAsync(input);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var dto = _mapper.Map(input);

            var res = await _searchService.GetSearchResult(dto);
            return Ok(res);
        }
    }
}
