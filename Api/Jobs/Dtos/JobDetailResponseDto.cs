using Jobs.Api.Common.Dto;

namespace Jobs.Api.Jobs.Dtos;

public class JobDetailResponseDto : ResourceResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public IEnumerable<string> Requirements { get; set; } = new List<string>();
}