namespace Jobs.Core.Repositories;

public class PagedResult<Model>
{
    public ICollection<Model> Items { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int FirstPage { get; set; }
    public int LastPage { get; set; }
    public int TotalElements { get; set; }

    public PagedResult(
        ICollection<Model> items,
        int pageNumber,
        int pageSize,
        int totalElements
    )
    {
        Items = items;
        PageNumber = pageNumber;
        PageSize = pageSize;
        FirstPage = 1;
        LastPage = (int) Math.Ceiling(totalElements / (double)pageSize);
        TotalElements = totalElements;
    }
}