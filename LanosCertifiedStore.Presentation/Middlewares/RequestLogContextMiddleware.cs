using Serilog.Context;

namespace API.Middlewares;

internal sealed class RequestLogContextMiddleware(RequestDelegate next)
{
    public Task InvokeAsync(HttpContext context)
    {
        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            return next(context);
        }
    }
}