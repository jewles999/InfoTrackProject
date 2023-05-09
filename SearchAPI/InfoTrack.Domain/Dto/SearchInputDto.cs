using InfoTrack.Domain.InputModels;

namespace InfoTrack.Domain.Dto
{
    public class SearchInputDto
    {
        public string PageSource { get; set; } = default!;
        public SearchInput Input { get; set; } = default!;
        public string ParentDivPattern { get; set; } = default!;
        public string Url { get; set; } = default!;
        public char ResultSeparator { get; set; } = ',';

    }
}
