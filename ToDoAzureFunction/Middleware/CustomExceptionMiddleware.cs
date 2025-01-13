

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

public class CustomExceptionMiddleware : IFunctionsWorkerMiddleware
{
    private readonly ILogger<CustomExceptionMiddleware> _logger;

    public CustomExceptionMiddleware(ILogger<CustomExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred.");
            var errorMessage = new { error = "An unexpected error occurred. Please try again later." };

            var requestDataTask = context.GetHttpRequestDataAsync();
            var request = await requestDataTask;
            if (request != null)
            {
                var response = request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Headers.Add("Content-Type", "application/json");
                await response.WriteStringAsync(JsonSerializer.Serialize(errorMessage));
                context.GetInvocationResult().Value = response;
            }
        }
    }
}
