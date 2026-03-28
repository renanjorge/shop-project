using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace shop.infra.crossCutting.Middleware.ExceptionHandlerMiddleware;

public class ErrorExceptionHandlerMiddleware : AbstractExceptionHandlerMiddleware
{
    public ErrorExceptionHandlerMiddleware(RequestDelegate next) : base(next) { }

    public override (HttpStatusCode code, string message) GetResponse(Exception exception)
    {
        return exception switch
        {
            DbUpdateConcurrencyException    => (HttpStatusCode.Conflict,             Serialize("O recurso foi modificado por outro processo. Tente novamente.")),
            DbUpdateException               => (HttpStatusCode.InternalServerError,  Serialize("Não foi possível persistir os dados. Verifique as informações enviadas.")),
            OperationCanceledException      => ((HttpStatusCode) 499,                Serialize("A requisição foi cancelada pelo cliente.")),
            _                               => (HttpStatusCode.InternalServerError,  Serialize("Ops! Tivemos um probleminha aqui."))
        };
    }

    private static string Serialize(string message) => JsonConvert.SerializeObject(message);
}
