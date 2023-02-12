using Jobs.Api.Common.Dto;

namespace Jobs.Api.Common.LinkAssembler;

public interface ILinkAssembler<T> where T : ResourceResponseDto
{
    T ToResource(T body, HttpContext context);

    ICollection<T> ToResourceList(ICollection<T> resourceList, HttpContext context)
    {
        return resourceList.Select(r => ToResource(r, context)).ToList();
    }
}