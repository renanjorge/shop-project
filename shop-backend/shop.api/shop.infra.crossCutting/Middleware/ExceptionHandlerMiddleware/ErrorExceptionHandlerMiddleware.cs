using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace shop.infra.crossCutting.Middleware.ExceptionHandlerMiddleware;

public class ErrorExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
{
    public ErrorExceptionHandlerMiddleware(RequestDelegate next) : base(next) { }

    public override (HttpStatusCode code, string message) GetResponse(Exception exception)
    {
        return (HttpStatusCode.InternalServerError, JsonConvert.SerializeObject("Ops! Tivemos um probleminha aqui."));
    }
}
