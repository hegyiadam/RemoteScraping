using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(HubComponents.Startup))]
namespace HubComponents
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseCors(CorsOptions.AllowAll);

            HubConfiguration hubConfiguration = new HubConfiguration
            {
                EnableDetailedErrors = true
            };

            appBuilder.MapSignalR(hubConfiguration);
        }
    }

}