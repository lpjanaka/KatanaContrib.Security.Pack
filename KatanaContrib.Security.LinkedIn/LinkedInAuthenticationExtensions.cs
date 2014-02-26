using Owin;
using System;

namespace KatanaContrib.Security.LinkedIn
{    
    public static class LinkedInAuthenticationExtensions
    {       
        public static IAppBuilder UseLinkedInAuthentication(this IAppBuilder app, LinkedInAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app", "app parameter is null");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options", "options parameter is null");
            }

            app.Use(typeof(LinkedInAuthenticationMiddleware), app, options);
            return app;
        }

        public static IAppBuilder UseLinkedInAuthentication(
            this IAppBuilder app,
            string apiKey,
            string secretKey)
        {
            if(String.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException("apiKey", "apiKey parameter is not provided");
            }

            if(String.IsNullOrWhiteSpace(secretKey))
            {
                throw new ArgumentNullException("secretKey", "secretKey parameter is not provided");
            }

            return UseLinkedInAuthentication(
                app,
                new LinkedInAuthenticationOptions
                {
                    AppId = apiKey,
                    AppSecret = secretKey
                });
        }
    }
}
