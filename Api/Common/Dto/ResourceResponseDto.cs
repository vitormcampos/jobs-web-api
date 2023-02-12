namespace Jobs.Api.Common.Dto;

public class ResourceResponseDto
{
    public ICollection<LinkResponseDto> Links { get; set; } = new List<LinkResponseDto>();

    public void AddLink(LinkResponseDto link)
    {
        Links.Add(link);
    }
    
    public void AddLinks(params LinkResponseDto[] links)
    {
        foreach (var link in links)
        {
            Links.Add(link);
        }
    }
}