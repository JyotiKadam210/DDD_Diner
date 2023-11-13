using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDiner.Api.Filters
{
    public class ErrorHandlingFilterAttributes : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetails = new ProblemDetails
            {
                Type = "",
                Title = "An error occured while processing your request..",
                Status = (int)HttpStatusCode.InternalServerError
            };
            
            context.Result = new ObjectResult(problemDetails)
            { 
                StatusCode = 500 
            };

            context.ExceptionHandled = true;
        }
    }
}
