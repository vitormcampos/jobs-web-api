namespace Jobs.Api.Common.Dto;

public class ErrorResponseDto
{
    public int Status { get; set; }
    public string Error { get; set; } = String.Empty;
    public string Cause { get; set; } = String.Empty;
    public string Message { get; set; } = String.Empty;
    public DateTime Timestamp { get; set; }
}