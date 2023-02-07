namespace Jobs.Api.Jobs.Dtos;

public class JobRequestDto
{
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public IEnumerable<string> Requirements { get; set; } = new List<string>();
}