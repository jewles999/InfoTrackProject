using InfoTrack.Application.Contracts.Infrastructure;
using InfoTrack.Application.CustomErrorMessages;
using InfoTrack.Application.Exceptions;
using InfoTrack.Domain.Dto;
using InfoTrack.Domain.InputModels;
using InfoTrack.Infrastructure;
using Moq;

namespace InfoTrack.UnitTests
{
    public class SearchServiceProviderTests
    {
        [Fact]
        public async void Valid_Input_Returns_Correct_Result()
        {
            var input = new SearchInput
            {
                DomainName = "infotrack.com",
                SearchTerm = "test"
            };
            var dto = new SearchInputDto
            {
                PageSource = string.Empty,
                Input = input,
                ParentDivPattern = "*separator*",
                Url = "google.com"
            };
            var mockSearcher = HttpClientMocks.MockWebSearcher();
            var notifier = new Mock<INotifier>();

            var processor = new SearchResultProcessor(notifier.Object);
            var searchServiceProvider = new SearchServiceProvider(mockSearcher.Object, processor);
            var expected = "1,2,3";

            var result = await searchServiceProvider.GetSearchResult(dto);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void InValid_Pattern_Throws_Error()
        {
            var input = new SearchInput
            {
                DomainName = "infotrack.com",
                SearchTerm = "test"
            };
            var dto = new SearchInputDto
            {
                PageSource = string.Empty,
                Input = input,
                ParentDivPattern = "*invalid*",
                Url = "google.com"
            };
            var mockSearcher = HttpClientMocks.MockWebSearcher();
            var notifier = new Mock<INotifier>();

            var processor = new SearchResultProcessor(notifier.Object);
            var searchServiceProvider = new SearchServiceProvider(mockSearcher.Object, processor);

            var ex = Assert.ThrowsAsync<ServiceUnavailableException>(() => searchServiceProvider.GetSearchResult(dto));
            Assert.True(ex.Result.Message.Equals(ExceptionMessages.SystemUnavailableMessage));
        }
    }
}
