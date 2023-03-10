using System.Text.Json;
using FluentValidation;
using Jobs.Api.Common.Dto;
using Jobs.Core.Exceptions;

namespace Jobs.Core.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;

        _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RecordNotFoudException e)
        {
            await HandleModelExceptionAsync(context, e);
        }
        catch (ValidationException e)
        {
            await HandleValidationExceptionAsync(context, e);
        }
        catch (LoginFailedException e)
        {
            await HandleLoginFailedExceptionAsync(context, e);
        }
        catch (RegisterFailedExeception e)
        {
            await HandleRegisterFailedExceptionAsync(context, e);
        }
    }

    private Task HandleModelExceptionAsync(HttpContext context, RecordNotFoudException exception)
    {
        var response = new ErrorResponseDto
        {
            Cause = exception.GetType().Name,
            Message = exception.Message,
            Status = StatusCodes.Status404NotFound,
            Error = "Not Found",
            Timestamp = DateTime.Now
        };

        context.Response.StatusCode = response.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonSerializerOptions));
    }

    private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        var response = new ValidationErrorResponseDto
        {
            Cause = exception.GetType().Name,
            Message = exception.Message,
            Status = StatusCodes.Status400BadRequest,
            Error = "Bad Request",
            Timestamp = DateTime.Now,
            Errors = exception.Errors
                .GroupBy(g => g.PropertyName)
                .ToDictionary(
                    vf =>
                        vf.Key,
                    g =>
                        g.Select(e => e.ErrorMessage)
                            .ToArray()
                )
        };

        context.Response.StatusCode = response.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonSerializerOptions));
    }
    
    private Task HandleLoginFailedExceptionAsync(HttpContext context, LoginFailedException exception)
    {
        var response = new ErrorResponseDto
        {
            Cause = exception.GetType().Name,
            Message = exception.Message,
            Status = StatusCodes.Status401Unauthorized,
            Error = "Unauthorized",
            Timestamp = DateTime.Now,
        };

        context.Response.StatusCode = response.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonSerializerOptions));
    }
    
    private Task HandleRegisterFailedExceptionAsync(HttpContext context, RegisterFailedExeception exception)
    {
        var response = new ErrorResponseDto
        {
            Cause = exception.GetType().Name,
            Message = exception.Message,
            Status = StatusCodes.Status401Unauthorized,
            Error = "Unauthorized",
            Timestamp = DateTime.Now,
        };

        context.Response.StatusCode = response.Status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonSerializerOptions));
    }
}