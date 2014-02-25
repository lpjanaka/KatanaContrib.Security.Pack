using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace KatanaContrib.Security.LinkedIn.Tests
{
    public static class MockCreator
    {
        public static IOwinContext CreateOwinContext()
        {
            MockOwinContext mockLab = new MockOwinContext();
            return mockLab.CreateStubOwinContext();
        }
    }
}
