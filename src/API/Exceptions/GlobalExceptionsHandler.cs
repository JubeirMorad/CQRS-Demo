
using Application.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace API.Exceptions
{
    public class GlobalExceptionsHandler (IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails problem = exception switch
            {
                ValidationException ex => new ValidationProblemDetails(
                    ex.Errors.GroupBy(e => e.PropertyName)
                             .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray()))
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation Error!"
                },

                NotFoundException ex => new ProblemDetails()
                {
                    Title = "Not Found!",
                    Status = StatusCodes.Status404NotFound,
                    Detail = ex.Message
                },

                _ => new ProblemDetails()
                {
                    Title = "Server Error!",
                    Status = 500,
                    Detail = "Internal server error!"
                }
            };

            httpContext.Response.StatusCode = problem.Status!.Value;
            await problemDetailsService.WriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                ProblemDetails = problem
            });

            return true;
        }
    }
}