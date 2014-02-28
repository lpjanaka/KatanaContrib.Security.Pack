using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Moq;

namespace KatanaContrib.Security.LinkedIn.Tests
{
    public static class MockCreator
    {
        private static MockingFactory mockFactory = new MockingFactory();

        public static IOwinContext CreateOwinContext()
        {
            //MockingFactory mockFactory = new MockingFactory();
            return mockFactory.CreateStubOwinContext();
        }

        public static IAppBuilder CreateAppBuilder()
        {
            //MockingFactory mockFactory = new MockingFactory();
            return mockFactory.CreateStubAppBuilder();
        }

        public static OwinMiddleware CreateOwinMiddleware()
        {
            //MockingFactory mockFactory = new MockingFactory();
            return mockFactory.CreateStubOwinMiddleware();
        }
    }
}
