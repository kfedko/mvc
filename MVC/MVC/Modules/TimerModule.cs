using System;
using System.Diagnostics;
using System.Web;

namespace MVC.Modules
{
	public class TimerModule : IHttpModule
	{
		private Stopwatch timer;

		private void HandleBeginRequest(object src, EventArgs args) {
			timer = Stopwatch.StartNew();
		}
		private void HandleEndRequest(object src, EventArgs args) {
			HttpContext context = HttpContext.Current;
			context.Response.Write(string.Format(
				"<div style='color:red;'>Time for request processing is: {0:F5} seconds</div>",
				((float)timer.ElapsedTicks) / Stopwatch.Frequency));
		}
		public void Init(HttpApplication context)
		{
			context.BeginRequest += HandleBeginRequest;
			context.EndRequest += HandleEndRequest;
		}

		public void Dispose(){}
	}
}