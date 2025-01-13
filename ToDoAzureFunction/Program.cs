using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using ToDoApp.Core;
using ToDoApp.Infrastructure;
using ToDoAzureFunction;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


        // Register the request handler 
        services.AddScoped<IRequestHandler<GetAllTodosQuery, IEnumerable<ToDoItemDto>>, GetAllToDosQueryHandler>();

        services.AddSingleton(new List<ToDoItem>());
        services.AddScoped<IToDoReadRepository, ToDoReadRepository>();
        services.AddScoped<CustomExceptionMiddleware>();
        services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
             });
    })
   
    .Build();
host.Run();