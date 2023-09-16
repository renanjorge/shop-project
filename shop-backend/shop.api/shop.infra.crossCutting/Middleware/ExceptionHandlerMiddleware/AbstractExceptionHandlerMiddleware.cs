using Microsoft.AspNetCore.Http;
using System.Net;

namespace shop.infra.crossCutting.Middleware.ExceptionHandlerMiddleware;

public abstract class AbstractExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public AbstractExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var (status, message) = GetResponse(exception);
            response.StatusCode = (int) status;
            await response.WriteAsync(message);
        }
    }

    public abstract (HttpStatusCode code, string message) GetResponse(Exception exception);
}
