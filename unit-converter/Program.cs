using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using unit_converter.Converters;
using unit_converter.Exceptions;
using unit_converter.Models;
using unit_converter.Registry;
using unit_converter.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ConversionService>();
builder.Services.AddSingleton<UnitRegistry>();
builder.Services.AddSingleton<LinearUnitConverter>();
builder.Services.AddSingleton<TemperatureConverter>();
builder.Services.AddSingleton<UnitConverterFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();


}
    app.UseSwagger();
    app.UseSwaggerUI();
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionFeature?.Error;
        var response = new ErrorResponse();

        switch (exception)
        {
            case UnknownUnitException:
            case UnitMismatchException:
                context.Response.StatusCode =
                    (int)HttpStatusCode.BadRequest;

                response.Message = exception.Message;
                break;

            default:
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                response.Message =
                    "An unexpected error occurred.";
                break;
        }

        await context.Response.WriteAsJsonAsync(response);
    });
});
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

