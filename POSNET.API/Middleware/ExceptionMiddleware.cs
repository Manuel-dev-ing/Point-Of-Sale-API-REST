using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using POSNet.Application.Common.Exceptions;

namespace POSNET.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                await WriteProblemDetails(context, 400, ex.Errors);
            }
            catch (NotFoundException ex)
            {
                await WriteProblemDetails(context, 404, ex.Message);
            }
            catch (DomainException ex)
            {
                await WriteProblemDetails(context, 409, ex.Message);
            }
            catch (Exception ex)
            {
                await WriteProblemDetails(context, 500, "Unexpected Server Error");
            }
        
        }

        private async Task WriteProblemDetails(
        HttpContext ctx, int status, object detail)
        {
            ctx.Response.StatusCode = status;
            ctx.Response.ContentType = "application/problem+json";

            var problem = new ProblemDetails
            {
                Status = status,
                Title = ReasonPhrases.GetReasonPhrase(status),
                Detail = detail?.ToString()
            };

            await ctx.Response.WriteAsJsonAsync(problem);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new
            {
                success = false,
                errors = new List<string>()
            };

            switch (exception)
            {
                case ValidationException validationEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = new
                    {
                        success = false,
                        errors = validationEx.Errors.Select(e => e.ErrorMessage).ToList()
                    };
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = new
                    {
                        success = false,
                        errors = new List<string> { "Ocurrió un error interno en el servidor" }
                    };
                    break;
            }

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));

        }
    }
}
