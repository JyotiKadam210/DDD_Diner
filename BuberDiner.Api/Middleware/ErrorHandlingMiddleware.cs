using BuberDiner.Application.Common.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuberDiner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {         

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        public static Task HandleExceptionAsync(HttpContext context, Exception ex) 
        {
            var (statusCode, message) = ex switch
            {
                IServiceException e => ( (int)e.StatusCode  , e.EoorMessage),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured.")
            };

            var exceptionsResult = new ProblemDetails
            {
                Status = statusCode,
                Title = message
            };

            var errordetails = JsonSerializer.Serialize(exceptionsResult);

            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(errordetails);
        }
    }
}
