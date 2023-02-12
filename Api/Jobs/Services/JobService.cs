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

    public ICollection<JobResponseDto> FindAll()
    {
        var jobs = _jobRepository.FindAll();
        var jobsDto = _mapper.Map<ICollection<JobResponseDto>>(jobs);
        return jobsDto;
    }

    public JobDetailResponseDto FindById(int id)
    {
        var job = _jobRepository.FindById(id);
        if (job is null)
        {
            throw new RecordNotFoudException();
        }
        
        return _mapper.Map<JobDetailResponseDto>(job);
    }

    public JobDetailResponseDto Create(JobRequestDto jobRequest)
    {
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        var job = _mapper.Map<Job>(jobRequest);
        var data = _jobRepository.Create(job);
        return _mapper.Map<JobDetailResponseDto>(data);
    }

    public JobDetailResponseDto UpdateById(int id, JobRequestDto jobRequest)
    {
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        
        var job = _mapper.Map<Job>(jobRequest);
        var jobExists = _jobRepository.ExistsById(id);
        if (!jobExists) throw new RecordNotFoudException();
        job.Id = id;
        var data = _jobRepository.Update(job);
        return _mapper.Map<JobDetailResponseDto>(data);
    }

    public void DeleteById(int id)
    {
        var jobExists = _jobRepository.ExistsById(id);
        if (!jobExists) throw new RecordNotFoudException();

        _jobRepository.DeleteById(id);
    }
}