using Jobs.Api.Common.Dto;
using Jobs.Api.Common.LinkAssembler;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.Services;
using Jobs.Core.Models;
using Jobs.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Api.Jobs.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly ILinkAssembler<JobDetailResponseDto> _jobDetailLinkAssembler;
    private readonly IPagedAssembler<JobResponseDto> _jobPagedAssembler;

    public JobController(
        IJobService jobService,
        ILinkAssembler<JobDetailResponseDto> jobDetailLinkAssembler, IPagedAssembler<JobResponseDto> jobPagedAssembler)
    {
        _jobService = jobService;
        _jobDetailLinkAssembler = jobDetailLinkAssembler;
        _jobPagedAssembler = jobPagedAssembler;
    }

    [HttpGet(Name = "FindAllJobs")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<JobResponseDto>))]
    public IActionResult FindAll([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var body = _jobService.FindAll(page, size);
        return Ok(_jobPagedAssembler.ToPagedResource(body, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponseDto))]
    public async Task<IActionResult> FindById([FromRoute] int id)
    {
        var job = await _jobService.FindById(id);
        return Ok(_jobDetailLinkAssembler.ToResource(job, HttpContext));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponseDto))]
    public async Task<IActionResult> Create([FromBody] JobRequestDto job)
    {
        var newJob = await _jobService.Create(job);
        return Ok(_jobDetailLinkAssembler.ToResource(newJob, HttpContext));
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponseDto))]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] JobRequestDto job)
    {
        var updatedJob = await _jobService.UpdateById(id, job);
        return Ok(_jobDetailLinkAssembler.ToResource(updatedJob, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponseDto))]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}