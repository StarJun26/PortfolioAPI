using Portfolio.Persistence;
using Portfolio.Application;
using Portfolio.API.Extensions;
using Portfolio.Persistence.Context;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplicationLayer();

builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

// configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var serviceScope = app.Services.CreateScope();
var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
dataContext?.Database.EnsureCreated();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//app.UseSwagger(o =>
//{
//    o.RouteTemplate = "{documentName}/swagger.json";
//});
//app.UseSwaggerUI(o =>
//{
//    o.SwaggerEndpoint("/v1/swagger.json", "My Clean API");
//    o.RoutePrefix = string.Empty;
//});

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseErrorHandler();
app.UseCors();
app.MapControllers();
app.Run();
