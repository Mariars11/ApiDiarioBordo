using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DiarioBordo.Filters;

public class CustomExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger<CustomExceptionFilter> _logger;

    public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Houve um erro.");

        HttpStatusCode statusCode;
        string userMessage;

        switch (context.Exception)
        {
            case ArgumentException:
                statusCode = HttpStatusCode.BadRequest;
                userMessage = "Requisição inválida.";
                break;
            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                userMessage = "Acesso não autorizado.";
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                userMessage = "Recurso não encontrado.";
                break;
            default:
                statusCode = HttpStatusCode.InternalServerError;
                userMessage = "Entre em contato com o administrador do sistema.";
                break;
        }

        var errorDetails = new
        {
            Message = userMessage,
            DetailedMessage = context.Exception.Message,
            ExceptionType = context.Exception.GetType().FullName
        };

        context.Result = new ObjectResult(errorDetails)
        {
            StatusCode = (int)statusCode
        };

        context.ExceptionHandled = true; // Impede propagação do erro
    }
}
