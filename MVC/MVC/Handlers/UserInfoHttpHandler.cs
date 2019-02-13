using System.Web;

namespace MVC.Handlers
{
	public class UserInfoHttpHandler : IHttpHandler
	{
		public bool IsReusable => false;

		public void ProcessRequest(HttpContext context)
		{
			string result = "<p>Your IP: " + context.Request.UserHostAddress + "</p>";
			result += "<p>UserAgent: " + context.Request.UserAgent + "</p>";
			context.Response.Write(result);
		}
	}
}