using AutoMapper;
using FluentValidation;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Exceptions;
using Jobs.Core.Models;
using Jobs.Core.Repositories.Jobs;

namespace Jobs.Api.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<JobRequestDto> _jobRequestValidator;

    public JobService(
        IJobRepository jobRepository,
        IMapper mapper,
        IValidator<JobRequestDto> jobRequestValidator
    )
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
        _jobRequestValidator = jobRequestValidator;
    }

    public IEnumerable<Job> FindAll()
    {
        return _jobRepository.FindAll();
    }

    public Job FindById(int id)
    {
        var job = _jobRepository.FindById(id);
        if (job is null)
        {
            throw new RecordNotFoudException();
        }

        return job;
    }

    public Job Create(JobRequestDto jobRequest)
    {
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        var job = _mapper.Map<Job>(jobRequest);
        return _jobRepository.Create(job);
    }

    public Job UpdateById(int id, JobRequestDto jobRequest)
    {
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        
        var job = _mapper.Map<Job>(jobRequest);
        var jobExists = _jobRepository.ExistsById(id);
        if (!jobExists) throw new RecordNotFoudException();
        job.Id = id;
        return _jobRepository.Update(job);
    }

    public void DeleteById(int id)
    {
        var jobExists = _jobRepository.ExistsById(id);
        if (!jobExists) throw new RecordNotFoudException();

        _jobRepository.DeleteById(id);
    }
}