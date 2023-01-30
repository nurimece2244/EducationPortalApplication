using InternProject.Application.Dto;
using InternProject.Domain.Entities;

namespace InternProject.Application.Interfaces;

public interface IEducationCategory
{
    Task<EducationCategoryDto> AddEducationCategory(EducationCategoryDto educationCategoryDto);

    Task UpdateEducationCategory(EducationCategoryUpdateDto educationCategoryUpdateDto);

    Task DeleteEducationCategory(int id);
}