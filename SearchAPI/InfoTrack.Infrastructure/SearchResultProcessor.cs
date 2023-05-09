using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Domain.Dto;

namespace InfoTrack.Infrastructure
{
    public class SearchResultProcessor : ISearchResultProcessor
    {
        private const string EmptyResult = "0";
        public Task<string> ProcessSearchResults(SearchInputDto dto)
        {

            var element = System.Text.RegularExpressions.Regex.Unescape(dto.ParentDivPattern);
            if (!dto.PageSource.Contains(element)) throw new Exception("Search not available");

            return Task.Run(() => GetReturnValue(dto));
        }

        private static string GetReturnValue(SearchInputDto dto)
        {
            var array = dto.PageSource.Split(new string[] { dto.ParentDivPattern }, StringSplitOptions.None);
            var list = new List<string>();

            if (array.Length == 0) return EmptyResult;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains(dto.Input.DomainName)) list.Add((i + 1).ToString());
            }

            return string.Join(',', list);
        }
    }
}
