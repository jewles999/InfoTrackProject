namespace InfoTrack.Domain.InputModels
{
    public class SearchInput
    {
        public string SearchTerm { get; set; } = default!;
        public string DomainName { get; set; } = default!;
    }
}
