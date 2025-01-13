using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoAPI;
using ToDoApp.Core;
using ToDoApp.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddSingleton(new List<ToDoItem>());
builder.Services.AddScoped<IToDoWriteRepository, ToDoWriteRepository>();
builder.Services.AddScoped<IToDoReadRepository, ToDoReadRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure CORS
builder.Services.AddCors(
    options => 
    { 
        options.AddPolicy("ToDoAPP_CORS_Policy", 
            builder => 
            { 
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod(); 
            }); 
    }
);



var app = builder.Build();
// Register the custom ExceptionMiddleware
app.UseMiddleware<ExceptionMiddleware>();

// Use the configured CORS policy 
app.UseCors("ToDoAPP_CORS_Policy");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
