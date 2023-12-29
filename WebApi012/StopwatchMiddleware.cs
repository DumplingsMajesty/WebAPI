using System;
using System.Diagnostics;

namespace WebApi012
{
	public class StopwatchMiddleware
	{

		private readonly RequestDelegate next;

        public StopwatchMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			await next(httpContext);

			stopWatch.Stop();
			Console.WriteLine(stopWatch.ElapsedMilliseconds);
		}
	}
}

