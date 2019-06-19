using System;
using Microsoft.Owin;
using Owin;
using TokenAuthentication.Models;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(TokenAuthentication.Startup))]

namespace TokenAuthentication
{
    // In this class we will Configure the OAuth Authorization Server.
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*
             * Use Postman or other services 
             * 
             *As we don’t have any user with the name test, so let’s try to create the Access Token for the test user.

                Select the method type as POST (1), 
                enter the URL as http://localhost:PortNumber/token (2) and then click on body tab
                (3) and then select x-www-form-urlencoded (4) and then enter 3 parameters (5)

                username (value : test)
                password (value: test)
                grant_type (value: password)
                And then click on the send button (6).
             */
            // Enable CORS (cross origin resource sharing) for making request using browser from different domains
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //The Path For generating the Toekn
                TokenEndpointPath = new PathString("/token"),

                //Setting the Token Expired Time (24 hours)
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //MyAuthorizationServerProvider class will validate the user credentials
                Provider = new MyAuthorizationServerProvider()
            };

            //Token Generations
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseCors(CorsOptions.AllowAll);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }
    }
}
