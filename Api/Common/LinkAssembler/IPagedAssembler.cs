using Jobs.Api.Common.Dto;

namespace Jobs.Api.Common.LinkAssembler;

public interface IPagedAssembler<T> where T : ResourceResponseDto
{
    PagedResponse<T> ToPagedResource(PagedResponse<T> response, HttpContext context);
}