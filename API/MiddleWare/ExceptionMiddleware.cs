using API.Errors;
using Azure;
using System.Net;
using System.Text.Json;

namespace API.MiddleWare
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var respounse = env.IsDevelopment()
                    ? new ApiExceptions(context.Response.StatusCode, e.Message, e.StackTrace?.ToString())
                    : new ApiExceptions(context.Response.StatusCode, "Internal Server Error");


                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };


                var json = JsonSerializer.Serialize(respounse, option);

            }
        }
    }
}