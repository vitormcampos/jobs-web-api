using AutoMapper;
using FluentValidation;
using Jobs.Api.Common.Dto;
using Jobs.Api.Jobs.Dtos;
using Jobs.Core.Exceptions;
using Jobs.Core.Models;
using Jobs.Core.Repositories;
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

    public async Task<ICollection<JobResponseDto>> FindAll()
    {
        var jobs = await _jobRepository.FindAll();
        var jobsDto = _mapper.Map<ICollection<JobResponseDto>>(jobs);
        return jobsDto;
    }

    public PagedResponse<JobResponseDto> FindAll(int page, int size)
    {
        var paginationOptions = new PaginationOptions(page, size);
        var data = _jobRepository.FindAll(paginationOptions);
        return _mapper.Map<PagedResponse<JobResponseDto>>(data);
    }

    public async Task<JobDetailResponseDto> FindById(int id)
    {
        var job = await _jobRepository.FindById(id);
        if (job is null)
        {
            throw new RecordNotFoudException();
        }

        return _mapper.Map<JobDetailResponseDto>(job);
    }

    public async Task<JobDetailResponseDto> Create(JobRequestDto jobRequest)
    {
        _jobRequestValidator.ValidateAndThrow(jobRequest);
        var job = _mapper.Map<Job>(jobRequest);
        var data = await _jobRepository.Create(job);
        return _mapper.Map<JobDetailResponseDto>(data);
    }

    public async Task<JobDetailResponseDto> UpdateById(int id, JobRequestDto jobRequest)
    {
        _jobRequestValidator.ValidateAndThrow(jobRequest);

        var job = _mapper.Map<Job>(jobRequest);
        var jobExists = await _jobRepository.ExistsById(id);
        if (!jobExists) throw new RecordNotFoudException();
        job.Id = id;
        var data = _jobRepository.Update(job);
        return _mapper.Map<JobDetailResponseDto>(data);
    }

    public async Task DeleteById(int id)
    {
        var jobExists = await _jobRepository.ExistsById(id);
        if (!jobExists) throw new RecordNotFoudException();

        await _jobRepository.DeleteById(id);
    }
}