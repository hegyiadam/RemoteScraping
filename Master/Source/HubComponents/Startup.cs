using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

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