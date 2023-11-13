using BuberDiner.Api;
using BuberDiner.Api.Errors;
using BuberDiner.Api.Mapping;
using BuberDiner.Application.DependecyInjection;
using BuberDiner.Infrastructure.DependecyInjection;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttributes>());



builder.Services
    .AddPresentation()
    .AddAplication()
    .AddInfrastructure(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();

/*
app.Map("/error", (HttpContext context) =>
{

    Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    return Results.Problem();
});*/

//app.UseExceptionHandler("/error");


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
