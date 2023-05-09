using Moq;
using Moq.Protected;
using System.Net;

namespace InfoTrack.UnitTests
{
    public class HttpClientMocks
    {
        public static Mock<HttpMessageHandler> MockWebSearcher()
        {
            var mockSearcher = new Mock<HttpMessageHandler>();
            const string testContent = "test content";
            mockSearcher.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(testContent)
                });
            return mockSearcher;
        }
    }
}
