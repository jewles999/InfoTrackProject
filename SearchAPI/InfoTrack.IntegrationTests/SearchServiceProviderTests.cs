using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Application.Helpers;
using InfoTrack.Domain.Dto;
using InfoTrack.Domain.InputModels;
using InfoTrack.Infrastructure;
using Moq;
using System.Text.Encodings.Web;

namespace InfoTrack.IntegrationTests
{
    public class SearchServiceProviderTests
    {
        [Fact]
        public void GetSearchResult_ReturnsNonEmptyString()
        {
            var parentDiv = "<div class=&quot;Gx5Zad fP1Qef xpd EtOod pkphOe&quot;>";
            var url = "https://www.google.com/search?num=100&q=";
            var input = new SearchInput
            {
                DomainName = "infotrack.com",
                SearchTerm = "efiling integration"
            };
            var dto = new SearchInputDto
            {
                PageSource = string.Empty,
                Input = input,
                ParentDivPattern = StringHelper.ReplaceQuot(parentDiv),
                Url = string.Concat(url, UrlEncoder.Default.Encode(input.SearchTerm))
            };

            var webSearcher = new WebSearcher();
            var notifier = new Mock<INotifier>();
            var resultProcessor = new SearchResultProcessor(notifier.Object);
            var sut = new SearchServiceProvider(webSearcher, resultProcessor);
            var result = sut.GetSearchResult(dto).Result;

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}