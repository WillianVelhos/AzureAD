using Location.App_Start;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(Startup))]
namespace Location.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            var azureAdBearearAuthOptions = new WindowsAzureActiveDirectoryBearerAuthenticationOptions
            {
                Tenant = ConfigurationManager.AppSettings["Tenant"]
            };

            azureAdBearearAuthOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidAudience = ConfigurationManager.AppSettings["Audience"]
            };

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(azureAdBearearAuthOptions);
        }
    }
}
