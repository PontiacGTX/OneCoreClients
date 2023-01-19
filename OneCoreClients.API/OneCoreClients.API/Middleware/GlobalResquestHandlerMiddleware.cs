using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OneCoreClients.Shared.Helpers;
using System.Net;
using System.Threading.Tasks;
using System;

namespace OneCoreClients.API.Middleware
{
    public class GlobalResquestHandlerMiddleware
    {
        readonly RequestDelegate _next;
        readonly ILogger<GlobalResquestHandlerMiddleware> logger;
        public GlobalResquestHandlerMiddleware(RequestDelegate next, ILogger<GlobalResquestHandlerMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "application/json";
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.Body.WriteAsync(Factory.ErrorResponse().GetBytes());

            }
        }
    }
}
