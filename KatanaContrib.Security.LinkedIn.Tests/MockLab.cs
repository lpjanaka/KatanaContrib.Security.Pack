using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Owin;
using System.Net.Http;
using System.Threading;

namespace KatanaContrib.Security.LinkedIn.Tests
{
    public  class MockLab
    {
        public IOwinContext CreateStubOwinContext()
        {
            return this.CreateOwinContextMock().Object;
        }

        public Mock<IOwinContext> CreateOwinContextMock()
        {
            Mock<IOwinContext> mock = new Mock<IOwinContext>(MockBehavior.Strict);
            mock.Setup(c => c.Request).Returns(this.CreateDummyOwinRequest());
            return mock;
        }

        public IOwinRequest CreateDummyOwinRequest()
        {
            return new Mock<IOwinRequest>(MockBehavior.Strict).Object;
        }
    }

    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private HttpResponseMessage response;

        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            this.response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var responseTask =
                new TaskCompletionSource<HttpResponseMessage>();
            responseTask.SetResult(response);

            return responseTask.Task;
        }
    }
}