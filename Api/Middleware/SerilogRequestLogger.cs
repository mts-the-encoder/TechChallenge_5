namespace Api.Middleware;

public class SerilogRequestLogger
{
	private readonly RequestDelegate _next;
	private readonly ILogger<SerilogRequestLogger> _logger;

	public SerilogRequestLogger(RequestDelegate next, ILogger<SerilogRequestLogger> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		// Log Headers
		var headers = context.Request.Headers.Select(h => $"{h.Key}: {h.Value}").ToList();
		_logger.LogInformation("Request Headers: {Headers}", string.Join(", ", headers));

		// Log Body
		context.Request.EnableBuffering(); // Allows us to read the body stream
		var bodyStream = new StreamReader(context.Request.Body);
		var bodyText = await bodyStream.ReadToEndAsync();
		context.Request.Body.Position = 0; // Reset the stream position after reading

		_logger.LogInformation("Request Body: {Body}", bodyText);

		await _next(context);
	}
}