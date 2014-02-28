using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Owin;
using System.Net.Http;
using System.Threading;
using Owin;

namespace KatanaContrib.Security.LinkedIn.Tests
{
    public  class MockingFactory
    {
        public IOwinContext CreateStubOwinContext()
        {
            return this.CreateOwinContextMock().Object;
        }

        public IAppBuilder CreateStubAppBuilder()
        {
            return this.CreateAppBuilderMock().Object;
        }

        public OwinMiddleware CreateStubOwinMiddleware()
        {
            return this.CreateOwinMiddlewareMock().Object;
        }

        public Mock<IOwinContext> CreateOwinContextMock()
        {
            Mock<IOwinContext> mock = new Mock<IOwinContext>(MockBehavior.Strict);
            mock.Setup(c => c.Request).Returns(this.CreateDummyOwinRequest());
            return mock;
        }

        public Mock<IAppBuilder> CreateAppBuilderMock()
        {
            LinkedInAuthenticationOptions options = new LinkedInAuthenticationOptions();

            Mock<IAppBuilder> mockApp = new Mock<IAppBuilder>(MockBehavior.Strict);
            mockApp.Setup(m => m.Use(typeof(LinkedInAuthenticationMiddleware), mockApp, options)).Returns(mockApp.Object);
            return mockApp;
            
        }

        public Mock<OwinMiddleware> CreateOwinMiddlewareMock()
        {
            IOwinContext context = this.CreateStubOwinContext();

            Mock<OwinMiddleware> middleware = new Mock<OwinMiddleware>(MockBehavior.Strict, null);
            middleware.Setup(m => m.Invoke(It.IsAny<IOwinContext>())).Returns(Task.FromResult(0));
            return middleware;
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