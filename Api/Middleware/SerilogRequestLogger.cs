using Serilog.Context;
using Serilog;
using System.Text;

namespace Api.Middleware;

public class SerilogRequestLogger
{
	readonly RequestDelegate _next;

	public SerilogRequestLogger(RequestDelegate next)
	{
		if (next == null) throw new ArgumentNullException(nameof(next));
		_next = next;
	}

	public async Task Invoke(HttpContext httpContext)
	{
		if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

		LogContext.PushProperty("UserName", httpContext.User.Identity.Name);

		string requestBody = "";
		httpContext.Request.EnableBuffering();
		Stream body = httpContext.Request.Body;
		byte[] buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
		await httpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
		requestBody = Encoding.UTF8.GetString(buffer);
		body.Seek(0, SeekOrigin.Begin);
		httpContext.Request.Body = body;

		Log.ForContext("RequestHeaders", httpContext.Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
		   .ForContext("RequestBody", requestBody)
		   .Debug("Request information {RequestMethod} {RequestPath} information", httpContext.Request.Method, httpContext.Request.Path);

		using (var responseBodyMemoryStream = new MemoryStream())
		{
			var originalResponseBodyReference = httpContext.Response.Body;
			httpContext.Response.Body = responseBodyMemoryStream;

			await _next(httpContext);

			httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
			var responseBody = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
			httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

			Log.ForContext("RequestBody", requestBody)
			   .ForContext("ResponseBody", responseBody)
			   .Debug("Response information {RequestMethod} {RequestPath} {statusCode}", httpContext.Request.Method, httpContext.Request.Path, httpContext.Response.StatusCode);

			await responseBodyMemoryStream.CopyToAsync(originalResponseBodyReference);
		}
	}
}