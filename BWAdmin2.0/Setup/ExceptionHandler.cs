using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Models.Exceptions;
using Newtonsoft.Json;
using NLog;
using LogLevel = NLog.LogLevel;

namespace BWAdmin2._0.Setup
{
    public static class ExceptionHandler
    {
        public static IApplicationBuilder UseBwExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.UseCors("AllowSpecificOrigin");
                builder.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error?.Error is BusinessValidationException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await HandleDomainException(error, context);
                    }
                    else if (error?.Error is NotFoundException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await HandleObjectNotFoundException(error, context);
                    }
                    else if (error?.Error is UnauthorizedAccessException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await HandleUnauthorizedAccessException(error, context);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await HandleUnhandledException(error, context);
                    }
                });
            });

            return app;
        }

        private static async Task HandleDomainException(IExceptionHandlerFeature error, HttpContext context)
        {
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError()
            {
                HttpStatus = ((int)HttpStatusCode.InternalServerError).ToString(),
                Title = "An error occurred!",
                Detail = JsonConvert.SerializeObject(error.Error.Message, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }),
                Details = error.Error.GetType().Name
            })).ConfigureAwait(false);
        }

        private static async Task HandleObjectNotFoundException(IExceptionHandlerFeature error, HttpContext context)
        {
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError
            {
                HttpStatus = ((int)HttpStatusCode.NotFound).ToString(),
                Title = "This action is invalid.",
                Detail = $"Object not found."
            })).ConfigureAwait(false);
        }

        private static async Task HandleUnauthorizedAccessException(IExceptionHandlerFeature error, HttpContext context)
        {
            var aggNotFoundException = (UnauthorizedAccessException)error.Error;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError
            {
                HttpStatus = ((int)HttpStatusCode.Unauthorized).ToString(),
                Title = "This action is invalid.",
                Detail = $"No rights."
            })).ConfigureAwait(false);
        }

        private static async Task HandleUnhandledException(IExceptionHandlerFeature error, HttpContext context)
        {
            if (error?.Error != null)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Error, error.Error.ToString());
            }

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ApiError
            {
                HttpStatus = ((int)HttpStatusCode.InternalServerError).ToString(),
                Title = "An error occurred!",
                Detail = string.Empty
            })).ConfigureAwait(false);
        }
    }
}
