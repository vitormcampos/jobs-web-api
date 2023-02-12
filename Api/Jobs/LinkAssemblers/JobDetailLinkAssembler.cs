using Jobs.Api.Common.Dto;
using Jobs.Api.Common.LinkAssembler;
using Jobs.Api.Jobs.Dtos;

namespace Jobs.Api.Jobs.LinkAssemblers;

public class JobDetailLinkAssembler : ILinkAssembler<JobDetailResponseDto>
{
    private readonly LinkGenerator _linkGenerator;

    public JobDetailLinkAssembler(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public JobDetailResponseDto ToResource(JobDetailResponseDto body, HttpContext context)
    {
        var selfLink = new LinkResponseDto(
            _linkGenerator.GetUriByName(context, "FindJobById", new { Id = body.Id })!,
            "GET",
            "self"
        );
        var updateLink = new LinkResponseDto(
            _linkGenerator.GetUriByName(context, "UpdateJobById", new { Id = body.Id })!,
            "UPDATE",
            "update"
        );
        var deleteLink = new LinkResponseDto(
            _linkGenerator.GetUriByName(context, "DeleteJobById", new { Id = body.Id })!,
            "DELETE",
            "delete"
        );
        
        body.AddLinks(selfLink, updateLink, deleteLink);
        return body;
    }
}