using Jobs.Api.Common.Dto;
using Jobs.Api.Common.LinkAssembler;
using Jobs.Api.Jobs.Dtos;

namespace Jobs.Api.Jobs.LinkAssemblers;

public class JobSummaryPagedLinkAssembler : IPagedAssembler<JobResponseDto>
{
    private readonly LinkGenerator _linkGenerator;
    private readonly ILinkAssembler<JobResponseDto> _jobAssembler;

    public JobSummaryPagedLinkAssembler(LinkGenerator linkGenerator, ILinkAssembler<JobResponseDto> jobAssembler)
    {
        _linkGenerator = linkGenerator;
        _jobAssembler = jobAssembler;
    }

    public PagedResponse<JobResponseDto> ToPagedResource(PagedResponse<JobResponseDto> response, HttpContext context)
    {
        response.Items = _jobAssembler.ToResourceList(response.Items, context);

        var firstPageLink = new LinkResponseDto(
            _linkGenerator.GetUriByName(
                context,
                "FindAllJobs", new
                {
                    page = response.FirstPage,
                    size = response.PageSize
                }               
            )!,
            "GET",
            "firstPage"
        );
        var lastPageLink = new LinkResponseDto(
            _linkGenerator.GetUriByName(
                context,
                "FindAllJobs", new
                {
                    page = response.LastPage,
                    size = response.PageSize
                }               
            )!,
            "GET",
            "lastPage"
        );
        
        response.AddLinks(firstPageLink, lastPageLink);
        return response;
    }
}