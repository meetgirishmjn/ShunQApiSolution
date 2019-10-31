using BusinessCore.AppHandlers.Contracts;
using BusinessCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.AppHandlers
{
    public class GlobaleExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public GlobaleExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is BusinessException)
            {

            }
            else
            {
                //critical error
                var msg = exception.Message;
                if (exception.InnerException != null)
                    msg += Environment.NewLine + " InnerException:" + exception.InnerException.Message;
                msg += Environment.NewLine + " StackTrace:" + exception.StackTrace;
                _logger.LogError("\"logType\":\"Exception\",\"Data\":" + msg);
            }

            return context.Response.WriteAsync($"{{\"statusCode\":{context.Response.StatusCode},\"message\":\"{exception.Message}\"}}");
        }

    }

    public static class ConfigureGlobalExceptionExtension
    {
        public static void ConfigureGlobaleException(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobaleExceptionMiddleware>();
        }
    }

    
}
