namespace Jobs.Api.Common.Dto;

public class LinkResponseDto
{
    public string Href { get; set; }
    public string Type { get; set; }
    public string Rel { get; set; }

    public LinkResponseDto(string href, string type, string rel)
    {
        Href = href;
        Type = type;
        Rel = rel;
    }
}