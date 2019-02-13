using MVC.Handlers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			//#httpHandler option #1 with Web.config
			//routes.IgnoreRoute("handler/{*path}");

			//#httpHandler option #2
			routes.Add(new Route("handler/{*path}", new CustomRouteHandler()));

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}

		class CustomRouteHandler : IRouteHandler
		{
			//#httpHandler
			public IHttpHandler GetHttpHandler(RequestContext requestContext)
			{
				return new UserInfoHttpHandler();
			}
		}
	}
}
