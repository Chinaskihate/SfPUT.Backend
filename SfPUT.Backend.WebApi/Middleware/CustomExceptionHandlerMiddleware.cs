using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SfPUT.Backend.Application.Common.Exceptions;

namespace SfPUT.Backend.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case EditingNotUserOwnPostException editingNotUserOwnPostException:
                    code = HttpStatusCode.Forbidden;
                    break;
                case PostAlreadyExistsException postAlreadyExistsException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case PostEditTimeoutException postEditTimeoutException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case PostNotFoundException postNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case SectionNotFoundException sectionNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UserNotFoundException userNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "Application/json";
            context.Response.StatusCode = (int)code;
            if (string.IsNullOrEmpty(result))
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
