using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using JobSeeking.BE.ApplicationCore;
using System.Threading.Tasks;
using JobSeeking.BE.ApplicationCore.Entities.Base;
using static JobSeeking.BE.ApplicationCore.Enums.Enumeration;

namespace JobSeeking.BE.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        /// <summary>
        /// ErrorHandle
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
            this.next = next;
        }
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(
                new ActionServiceResult
                {
                    Success = false,
                    Message = ApplicationCore.Properties.Resources.Exception,
                    SystemCode = SystemCode.Exception,
                    Data = ex
                });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            logger.LogError("Exception : {result}", result);
            return context.Response.WriteAsync(result);
        }
    }
}
