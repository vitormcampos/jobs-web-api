using Jobs.Api.Common.LinkAssembler;
using Jobs.Api.Jobs.Dtos;
using Jobs.Api.Jobs.Services;
using Jobs.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jobs.Api.Jobs.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly ILinkAssembler<JobDetailResponseDto> _jobDetailLinkAssembler;
    private readonly ILinkAssembler<JobResponseDto> _jobSummaryLinkAssembler;

    public JobController(
        IJobService jobService,
        ILinkAssembler<JobDetailResponseDto> jobDetailLinkAssembler,
        ILinkAssembler<JobResponseDto> jobSummaryLinkAssembler
    )
    {
        _jobService = jobService;
        _jobDetailLinkAssembler = jobDetailLinkAssembler;
        _jobSummaryLinkAssembler = jobSummaryLinkAssembler;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        var jobs = _jobService.FindAll();
        return Ok(_jobSummaryLinkAssembler.ToResourceList(jobs, HttpContext));
    }

    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult FindById([FromRoute] int id)
    {
        var job = _jobService.FindById(id);
        return Ok(_jobDetailLinkAssembler.ToResource(job, HttpContext));
    }

    [HttpPost]
    public IActionResult Create([FromBody] JobRequestDto job)
    {
        var newJob = _jobService.Create(job);
        return Ok(_jobDetailLinkAssembler.ToResource(newJob, HttpContext));
    }

    [HttpPut("{id}", Name = "UpdateJobById")]
    public IActionResult Update([FromRoute] int id, [FromBody] JobRequestDto job)
    {
        var updatedJob = _jobService.UpdateById(id, job);
        return Ok(_jobDetailLinkAssembler.ToResource(updatedJob, HttpContext));
    }

    [HttpDelete("{id}", Name = "DeleteJobById")]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}