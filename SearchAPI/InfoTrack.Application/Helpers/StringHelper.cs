using InfoTrack.Domain.Dto;

namespace InfoTrack.Application.Helpers
{
    public static class StringHelper
    {
        private const string EmptyResult = "0";
        public static string GetReturnValue(SearchInputDto dto)
        {
            var array = dto.PageSource.Split(new string[] { dto.ParentDivPattern }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<string>();

            if (array.Length == 0) return EmptyResult;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Contains(dto.Input.DomainName)) list.Add((i + 1).ToString());
            }

            return list.Count == 0 ? EmptyResult : string.Join(dto.ResultSeparator, list);
        }

        public static string ReplaceQuot(string s)
        {
            return s.Replace("&quot;", @"""");
        }
    }
}
