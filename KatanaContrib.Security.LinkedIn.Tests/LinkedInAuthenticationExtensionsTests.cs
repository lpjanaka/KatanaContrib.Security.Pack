using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KatanaContrib.Security.LinkedIn;
using Owin;

namespace KatanaContrib.Security.LinkedIn.Tests
{
    [TestClass]
    public class LinkedInAuthenticationExtensionsTests
    {
        [TestMethod]
        public void UseLinkedInAuthentication_WithOptions_WhenAppParameterIsNull_ShouldThrowArgumentNull()
        {
            var options = new LinkedInAuthenticationOptions();
            IAppBuilder app = null;

            try
            {
                app.UseLinkedInAuthentication(options);
            }
            catch(ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "app parameter is null");
                return;
            }

            Assert.Fail("No exception was thrown");            
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WithAPIKey_WhenAppParameterIsNull_ShouldThrowArgumentNull()
        {
            string apiKey = "12636sdhgfkshf863483";
            string apiSecret = "384ghshf87436kfhs457";
            IAppBuilder app = null;

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch(ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "app parameter is null");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenOptionsParameterIsNull_ShouldThrowArgumentNullException()
        {
            LinkedInAuthenticationOptions options = null;
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(options);
            }
            catch(ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "options parameter is null");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenAPIKeyIsNull_ShouldThrowArgumentNullException()
        {
            string apiKey = null;
            string apiSecret = "674gfhrg8346kjhgfrhre";
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "apiKey parameter is not provided");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenAPIKeyIsWhiteSpaces_ShouldThrowArgumentNullException()
        {
            string apiKey = "   ";
            string apiSecret = "674gfhrg8346kjhgfrhre";
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "apiKey parameter is not provided");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenAPIKeyIsEmpty_ShouldThrowArgumentNullException()
        {
            string apiKey = "";
            string apiSecret = "674gfhrg8346kjhgfrhre";
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "apiKey parameter is not provided");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenSecretKeyIsNull_ShouldThrowArgumentNullException()
        {
            string apiKey = "764ewytfrewu32646kghhi";
            string apiSecret = null;
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "secretKey parameter is not provided");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenSecretKeyIsWhiteSpaces_ShouldThrowArgumentNullException()
        {
            string apiKey = "764ewytfrewu32646kghhi";
            string apiSecret = "    ";
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "secretKey parameter is not provided");
                return;
            }

            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void UseLinkedInAuthentication_WhenSecretKeyIsEmpty_ShouldThrowArgumentNullException()
        {
            string apiKey = "764ewytfrewu32646kghhi";
            string apiSecret = "";
            IAppBuilder app = MockCreator.CreateAppBuilder();

            try
            {
                app.UseLinkedInAuthentication(apiKey, apiSecret);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "secretKey parameter is not provided");
                return;
            }

            Assert.Fail("No exception was thrown");
        }
    }
}
