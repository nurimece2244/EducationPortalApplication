using InternProject.Application.Dto;
using InternProject.Domain.Entities;

namespace InternProject.Application.Interfaces;

public interface IEducationService
{
    Task<Education>? AddEducation(EducationDto educationDto);

    Task UpdateEducation( EducationUpdateDto educationUpdateDto);

    Task DeleteEducation( int id );


}