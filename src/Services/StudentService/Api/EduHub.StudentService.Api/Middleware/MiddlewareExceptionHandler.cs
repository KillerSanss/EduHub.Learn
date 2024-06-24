using System.Net;
using FluentValidation;
using EduHub.StudentService.Api.Middleware.Models;
using EduHub.StudentService.Application.Services.Exceptions.Base;

namespace EduHub.StudentService.Api.Middleware;

/// <summary>
/// Обработчик исключений
/// </summary>
public class MiddlewareExceptionHandler
{
    private readonly RequestDelegate _next;

    public MiddlewareExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var httpStatusCode = exception switch
        {
            ValidationException => HttpStatusCode.BadRequest,
            BaseNotFoundException => HttpStatusCode.NotFound,
            BaseConflictException => HttpStatusCode.Conflict,
            _ => HttpStatusCode.InternalServerError
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)httpStatusCode;

        var exceptionDetails = new ExceptionResponse
        {
            Type = exception.GetType().Name,
            Message = GetInnerException(exception),
            StackTrace = exception.StackTrace,
            Data = exception.Data
        };

        await context.Response.WriteAsJsonAsync(exceptionDetails);
    }

    private string GetInnerException(Exception exception)
    {
        var messages = new List<string>();
        while (exception != null)
        {
            messages.Add(exception.Message);
            exception = exception.InnerException;
        }

        return string.Join(" => ", messages);
    }
}