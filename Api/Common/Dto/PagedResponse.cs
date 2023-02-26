namespace Jobs.Api.Common.Dto;

public class PagedResponse<T> : ResourceResponseDto
{
    public ICollection<T> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int FirstPage { get; set; }
    public int LastPage { get; set; }
    public int TotalElements { get; set; }
}