using FluentValidation;
using InfoTrack.Domain.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IValidator<SearchInput> _validator;
        public SearchController(IValidator<SearchInput> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> SearchByKeywords(SearchInput input)
        {
            var validationResult = await _validator.ValidateAsync(input);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            return Ok(input);
        }
    }
}
