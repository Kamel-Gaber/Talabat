using System.Net;
using System.Text.Json;
using Talabat.APIs.Errors;

namespace Talabat.APIs.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next ,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context); //move to next middleware 
            }
            catch (Exception ex)
            {
                logger.LogError(ex,ex.Message); //log exciption at database

                context.Response.ContentType= "application/json";
                context.Response.StatusCode =  (int) HttpStatusCode.InternalServerError;


                var ExceptionErrorResponse = env.IsDevelopment() ?
                    new ApiExceptionResponse(500, ex.Message, ex.StackTrace.ToString())
                    :
                    new ApiExceptionResponse(500);

                var options = new JsonSerializerOptions() { PropertyNamingPolicy=JsonNamingPolicy.CamelCase};

                var json =JsonSerializer.Serialize(ExceptionErrorResponse ,options);
                await context.Response.WriteAsync(json);

            }
        }

    }
}
