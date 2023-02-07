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

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_jobService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        return Ok(_jobService.FindById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] JobRequestDto job)
    {
        var newJob = _jobService.Create(job);
        return CreatedAtAction(nameof(FindById), new { Id = newJob.Id }, newJob);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] JobRequestDto job)
    {
        return Ok(_jobService.UpdateById(id, job));
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.DeleteById(id);
        return NoContent();
    }
}