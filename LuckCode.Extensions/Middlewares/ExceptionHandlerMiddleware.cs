using LuckCode.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LuckCode.Extensions
{
    /// <summary>
    /// 异常处理中间件 应用层面
    /// </summary>
    public class ExceptionHandlerMiddleware:IMiddleware
    {
        public ExceptionHandlerMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }catch (Exception ex)
            {
                await HandleExceptionAsync(context,ex);
            }
        }
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private async Task HandleExceptionAsync(HttpContext context,Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            var message = ex.Message;
            switch (ex)
            {
                case UnauthorizedAccessException:

                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            await context.Response
                .WriteAsync(JsonSerializer.Serialize(new ApiResponse(StatusCode.CODE500, message).MessageModel))
                .ConfigureAwait(false);
        }
    }
}
