using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;

namespace InternProject.Persistence.Repositories;

public class EducationRepository : IEducationService
{
    private readonly IGenericRepository<Education> _genericRepository;

    public EducationRepository(IGenericRepository<Education> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<Education>? AddEducation(EducationDto educationDto)
    {
        var education = new Education()
        {
            Name = educationDto.Name,
            Duration = educationDto.Duration,
            Type = educationDto.Type,
            Status = educationDto.Status,
            EducationCategoryId = educationDto.EducationCategoryId,
            AppUserId = educationDto.AppUserId
        };

        await _genericRepository.AddAsync(education);

        return education;
    }



    public async Task UpdateEducation(EducationUpdateDto request)
    {
        var findEducation = await _genericRepository.GetByIdAsync(request.Id);
        
        if ( !string.IsNullOrWhiteSpace(request.Name))
            if (findEducation != null)
                findEducation.Name = request.Name;

        if ( !string.IsNullOrWhiteSpace(request.Type) && !request.Type.Equals("string"))
            if (findEducation != null)
                findEducation.Type = request.Type;

        if (request.Duration != 0)
            if (findEducation != null)
                findEducation.Duration = request.Duration;
        if (request.EducationCategoryId != 0)
            if (findEducation != null)
                findEducation.EducationCategoryId = request.EducationCategoryId;
        if (findEducation != null && request.Status != findEducation.Status)
            findEducation.Status = request.Status;

        if (findEducation != null) await _genericRepository.Update(findEducation);
    }

    public async Task DeleteEducation(int  id)
    {

        var deletedEducation = await _genericRepository.GetByIdAsync(id);

        if (deletedEducation != null)
        {
            deletedEducation.IsDeleted = true;

            await _genericRepository.Update(deletedEducation);
        }
    }

   
}