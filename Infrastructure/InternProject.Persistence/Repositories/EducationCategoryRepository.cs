using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;

namespace InternProject.Persistence.Repositories;

public class EducationCategoryRepository: IEducationCategory
{
    private readonly IGenericRepository<EducationCategory> _genericRepository;

    public EducationCategoryRepository(IGenericRepository<EducationCategory> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public async Task<EducationCategoryDto> AddEducationCategory(EducationCategoryDto request)
    {
        var category = new EducationCategory
        {
            Name = request.Name
        };
        await _genericRepository.AddAsync(category);
        return new EducationCategoryDto()
        {
            Name = request.Name
        };
    }

    public async Task UpdateEducationCategory(EducationCategoryUpdateDto request)
    {
        var categoryFind = await _genericRepository.GetByIdAsync(request.Id);

        if (categoryFind != null)
        {
            categoryFind.Name = request.Name;
            await _genericRepository.Update(categoryFind);
        }
    }

    public async Task DeleteEducationCategory(int id)
    {
        var categoryFind = await _genericRepository.GetByIdAsync(id);
        if (categoryFind != null)
        {
            categoryFind.IsDeleted = true;

           await _genericRepository.Update(categoryFind);
        }
    }
}