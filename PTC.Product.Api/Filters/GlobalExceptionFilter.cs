using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PTC.Product.Domain.Exceptions;

namespace PTC.Product.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            switch (exception)
            {
                case EntityNotFoundException notFoundException:
                    context.Result = new NotFoundObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
                case NameUniqueException nameNotUniqueException:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
                case UniqueException uniqueException:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
                case InvalidDataException invalidDataException:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
                default:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, exception.Message });
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}
