using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading;

namespace ToDoAzureFunction
{
   
    public class GetToDoFunction
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GetToDoFunction> _logger;

        public GetToDoFunction(ILogger<GetToDoFunction> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Function("GetToDos")]
        public async Task<IActionResult> GetTodos(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todos")] HttpRequestData req, FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var query = new GetAllTodosQuery();
            var result = await _mediator.Send(query);
            return new OkObjectResult(result);
        }

        //[Function("GetToDoById")]
        //public async Task<IActionResult> GetTodoById(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todos/{id}")] HttpRequestData req, Guid id, FunctionContext executionContext)
        //{
        //    var logger = executionContext.GetLogger("GetToDoFunction");
        //    try
        //    {
        //        _logger.LogInformation("C# HTTP trigger function processed a request.");

        //        logger.LogInformation("C# HTTP trigger function processed a request.");

        //        var query = new GetToDoByIdQuery { Id = id };
        //        var result = await _mediator.Send(query);
        //        return result != null ? new OkObjectResult(result) : new NotFoundResult();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "An error occurred while processing the request."); 
        //        var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError); 
        //        await errorResponse.WriteStringAsync("An unexpected error occurred. Please try again later."); 
        //        return (IActionResult)errorResponse;
        //    }
        //}
    }
}
