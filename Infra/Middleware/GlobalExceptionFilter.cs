using Forward_Solutions_Test_BE.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Forward_Solutions_Test_BE.Infra.Middleware
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                CalculationNotFoundException => 404,
                _ => 500
            };

            var response = new
            {
                error = context.Exception.Message,
                details = context.Exception.InnerException?.Message
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }
    }
}
