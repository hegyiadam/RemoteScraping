using Owin;
using System.Web.Http;

namespace MasterService
{
    public class RestApi
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "MethodOne",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.EnableCors();
            SwaggerConfig.Register(config);

            appBuilder.UseWebApi(config);
        }
    }
}