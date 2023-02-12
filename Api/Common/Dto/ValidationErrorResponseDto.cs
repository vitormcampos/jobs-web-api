namespace Jobs.Api.Common.Dto;

public class ValidationErrorResponseDto : ErrorResponseDto
{
    public IDictionary<string, string[]>? Errors { get; set; }
}