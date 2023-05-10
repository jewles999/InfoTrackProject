using InfoTrack.Application.Contracts.Infrastructure;
using Moq;
using Moq.Protected;
using System.Net;

namespace InfoTrack.UnitTests
{
    public class HttpClientMocks
    {
        public static Mock<HttpMessageHandler> MockHttpClient()
        {
            var mockSearcher = new Mock<HttpMessageHandler>();
            const string testContent = @"*separator* Lorem ipsum dolor sit amet, infotrack.com consectetur test adipiscing elit, sed do eiusmod tempor incididunt
                                        *separator* ut labore et dolore magna aliqua. infotrack.com Ut test enim ad
                                        *separator* minim veniam, quis nostrud exercitation infotrack.com ullamco test laboris nisi";
            mockSearcher.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            return mockSearcher;
        }

        public static Mock<IWebSearcher> MockWebSearcher()
        {
            var mockSearcher = new Mock<IWebSearcher>();
            const string testContent = @"*separator* Lorem ipsum dolor sit amet, infotrack.com consectetur test adipiscing elit, sed do eiusmod tempor incididunt
                                        *separator* ut labore et dolore magna aliqua. infotrack.com Ut test enim ad
                                        *separator* minim veniam, quis nostrud exercitation infotrack.com ullamco test laboris nisi";
            mockSearcher.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(testContent);

            return mockSearcher;
        }
    }
}
