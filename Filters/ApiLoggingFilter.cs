using Microsoft.AspNetCore.Mvc.Filters;

namespace DiarioBordo.Filters;

public class ApiLoggingFilter : IActionFilter
{
    private readonly ILogger<ApiLoggingFilter> _logger;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
        _logger = logger;
    }

   public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation("Executando ação: {ActionName}", context.ActionDescriptor.DisplayName);
    }

    // Método obrigatório
    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation("Ação executada: {ActionName}", context.ActionDescriptor.DisplayName);
    }
}