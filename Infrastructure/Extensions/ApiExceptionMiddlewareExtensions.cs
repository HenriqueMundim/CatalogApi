using CatalogApi.Domain.Entities;
using CatalogApi.Domain.Errors;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace CatalogApi.Infrastructure.Extensions;

public static class ApiExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;
                    int statusCode;

                    if (exception is NotFoundException)
                    {
                        statusCode = (int)HttpStatusCode.NotFound;  
                    } else
                    {
                        statusCode = 500;
                    }

                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = statusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    }.ToString());
                }
            });
        });
    }
}
