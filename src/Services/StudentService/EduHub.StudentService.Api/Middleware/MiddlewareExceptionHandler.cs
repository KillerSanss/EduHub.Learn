using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using EduHub.StudentService.Application.Services.Exceptions;
using Eduhub.StudentService.Domain.Entities.Base;

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
                    EntityNotFoundException<BaseEntity> => HttpStatusCode.NotFound,
                    EntityConflictException<BaseEntity> => HttpStatusCode.Conflict,
                    _ => HttpStatusCode.InternalServerError
                };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) httpStatusCode;
        
        var exceptionDetails = new ExceptionResponse
        {
            Type = exception.GetType().Name,
            Message = exception.Message,
            StackTrace = GetFullStackTrace(exception),
            Data = exception.Data
        };
        
        await context.Response.WriteAsJsonAsync(exceptionDetails);
    }
    
    private string GetFullStackTrace(Exception exception)
    {
        var stackTrace = new StackTrace(exception, true);
        var frames = stackTrace.GetFrames();
        var stackTraceString = string.Empty;

        foreach (var frame in frames)
        {
            stackTraceString += frame + Environment.NewLine;
        }

        return stackTraceString;
    }
}